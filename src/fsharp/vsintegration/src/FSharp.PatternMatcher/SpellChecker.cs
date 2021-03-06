// Copyright (c) Microsoft Corporation.  All Rights Reserved.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Utilities;

namespace Roslyn.Utilities
{
    internal class SpellChecker
    {
        private const string SerializationFormat = "2";

        public VersionStamp Version { get; }
        private readonly BKTree _bkTree;

        public SpellChecker(VersionStamp version, BKTree bKTree)
        {
            Version = version;
            _bkTree = bKTree;
        }

        public SpellChecker(VersionStamp version, IEnumerable<StringSlice> corpus)
            : this(version, BKTree.Create(corpus))
        {
        }

        public IList<string> FindSimilarWords(string value)
        {
            return FindSimilarWords(value, substringsAreSimilar: false);
        }

        public IList<string> FindSimilarWords(string value, bool substringsAreSimilar)
        {
            var result = _bkTree.Find(value, threshold: null);

            using (var spellChecker = new WordSimilarityChecker(value, substringsAreSimilar))
            {
                return result.Where(spellChecker.AreSimilar).ToArray();
            }
        }

#if false
        internal void WriteTo(ObjectWriter writer)
        {
            writer.WriteString(SerializationFormat);
            Version.WriteTo(writer);
            _bkTree.WriteTo(writer);
        }

        internal static SpellChecker ReadFrom(ObjectReader reader)
        {
            try
            {
                var formatVersion = reader.ReadString();
                if (string.Equals(formatVersion, SerializationFormat, StringComparison.Ordinal))
                {
                    var version = VersionStamp.ReadFrom(reader);
                    var bkTree = BKTree.ReadFrom(reader);
                    if (bkTree != null)
                    {
                        return new SpellChecker(version, bkTree);
                    }
                }
            }
            catch
            {
                Logger.Log(FunctionId.SpellChecker_ExceptionInCacheRead);
            }

            return null;
        }
#endif
    }

    internal class WordSimilarityChecker : IDisposable
    {
        private struct CacheResult
        {
            public readonly string CandidateText;
            public readonly bool AreSimilar;
            public readonly double SimilarityWeight;

            public CacheResult(string candidate, bool areSimilar, double similarityWeight)
            {
                CandidateText = candidate;
                AreSimilar = areSimilar;
                SimilarityWeight = similarityWeight;
            }
        }

        // Cache the result of the last call to AreSimilar.  We'll often be called with the same
        // value multiple times in a row, so we can avoid expensive computation by returning the
        // same value immediately.
        private CacheResult _lastAreSimilarResult;

        private string _source;
        private EditDistance _editDistance;
        private readonly int _threshold;

        /// <summary>
        /// Whether or words should be considered similar if one is contained within the other
        /// (regardless of edit distance).  For example if is true then IService would be considered
        /// similar to IServiceFactory despite the edit distance being quite high at 7.
        /// </summary>
        private readonly bool _substringsAreSimilar;

        public WordSimilarityChecker(string text, bool substringsAreSimilar)
        {
            if (text != null)
                _source = text;
            else 
                throw new ArgumentNullException("text");

            _threshold = GetThreshold(_source);
            _editDistance = new EditDistance(text);
            _substringsAreSimilar = substringsAreSimilar;
        }

        public void Dispose()
        {
            _editDistance?.Dispose();
            _editDistance = null;
        }

        public static bool AreSimilar(string originalText, string candidateText)
        {
            return AreSimilar(originalText, candidateText, substringsAreSimilar: false);
        }

        public static bool AreSimilar(string originalText, string candidateText, bool substringsAreSimilar)
        {
            double unused;
            return AreSimilar(originalText, candidateText, substringsAreSimilar, out unused);
        }

        public static bool AreSimilar(string originalText, string candidateText, out double similarityWeight)
        {
            return AreSimilar(
                originalText, candidateText,
                substringsAreSimilar: false, similarityWeight: out similarityWeight);
        }

        /// <summary>
        /// Returns true if 'originalText' and 'candidateText' are likely a misspelling of each other.
        /// Returns false otherwise.  If it is a likely misspelling a similarityWeight is provided
        /// to help rank the match.  Lower costs mean it was a better match.
        /// </summary>
        public static bool AreSimilar(string originalText, string candidateText, bool substringsAreSimilar, out double similarityWeight)
        {
            using (var checker = new WordSimilarityChecker(originalText, substringsAreSimilar))
            {
                return checker.AreSimilar(candidateText, out similarityWeight);
            }
        }

        internal static int GetThreshold(string value)
        {
            return value.Length <= 4 ? 1 : 2;
        }

        public bool AreSimilar(string candidateText)
        {
            double similarityWeight;
            return AreSimilar(candidateText, out similarityWeight);
        }

        public bool AreSimilar(string candidateText, out double similarityWeight)
        {
            if (_source.Length < 3)
            {
                // If we're comparing strings that are too short, we'll find 
                // far too many spurious hits.  Don't even bother in this case.
                similarityWeight = double.MaxValue;
                return false;
            }

            if (_lastAreSimilarResult.CandidateText == candidateText)
            {
                similarityWeight = _lastAreSimilarResult.SimilarityWeight;
                return _lastAreSimilarResult.AreSimilar;
            }

            var result = AreSimilarWorker(candidateText, out similarityWeight);
            _lastAreSimilarResult = new CacheResult(candidateText, result, similarityWeight);
            return result;
        }

        private bool AreSimilarWorker(string candidateText, out double similarityWeight)
        {
            similarityWeight = double.MaxValue;

            // If the two strings differ by more characters than the cost threshold, then there's 
            // no point in even computing the edit distance as it would necessarily take at least
            // that many additions/deletions.
            if (Math.Abs(_source.Length - candidateText.Length) <= _threshold)
            {
                similarityWeight = _editDistance.GetEditDistance(candidateText, _threshold);
            }

            if (similarityWeight > _threshold)
            {
                // it had a high cost.  However, the string the user typed was contained
                // in the string we're currently looking at.  That's enough to consider it
                // although we place it just at the threshold (i.e. it's worse than all
                // other matches).
                if (_substringsAreSimilar && candidateText.IndexOf(_source, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    similarityWeight = _threshold;
                }
                else
                {
                    return false;
                }
            }

            Debug.Assert(similarityWeight <= _threshold);

            similarityWeight += Penalty(candidateText, _source);
            return true;
        }

        private static double Penalty(string candidateText, string originalText)
        {
            int lengthDifference = Math.Abs(originalText.Length - candidateText.Length);
            if (lengthDifference != 0)
            {
                // For all items of the same edit cost, we penalize those that are 
                // much longer than the original text versus those that are only 
                // a little longer.
                //
                // Note: even with this penalty, all matches of cost 'X' will all still
                // cost less than matches of cost 'X + 1'.  i.e. the penalty is in the 
                // range [0, 1) and only serves to order matches of the same cost.
                //
                // Here's the relation of the first few values of length diff and penalty:
                // LengthDiff   -> Penalty
                // 1            -> .5
                // 2            -> .66
                // 3            -> .75
                // 4            -> .8
                // And so on and so forth.
                double penalty = 1.0 - (1.0 / (lengthDifference + 1));
                return penalty;
            }

            return 0;
        }
    }
}
