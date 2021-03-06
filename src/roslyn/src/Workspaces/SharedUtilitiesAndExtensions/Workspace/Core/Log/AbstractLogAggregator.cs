// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#nullable disable

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.Internal.Log
{
    /// <summary>
    /// helper class to aggregate some numeric value log in client side
    /// </summary>
    internal abstract class AbstractLogAggregator<T> : IEnumerable<KeyValuePair<object, T>>
    {
        private static int s_globalId;

        private readonly ConcurrentDictionary<object, T> _map = new(concurrencyLevel: 2, capacity: 2);
        private readonly Func<object, T> _createCounter;

        protected AbstractLogAggregator()
        {
            _createCounter = _ => CreateCounter();
        }

        protected abstract T CreateCounter();

        public static int GetNextId()
            => Interlocked.Increment(ref s_globalId);

        public static StatisticResult GetStatistics(List<int> values)
        {
            if (values.Count == 0)
            {
                return default;
            }

            var max = int.MinValue;
            var min = int.MaxValue;

            var total = 0;
            for (var i = 0; i < values.Count; i++)
            {
                var current = values[i];
                max = max < current ? current : max;
                min = min > current ? current : min;

                total += current;
            }

            var mean = total / values.Count;
            var median = values[values.Count / 2];

            var range = max - min;
            var mode = values.GroupBy(i => i).OrderByDescending(g => g.Count()).FirstOrDefault().Key;

            return new StatisticResult(max, min, median, mean, range, mode, values.Count);
        }

        public bool IsEmpty => _map.IsEmpty;

        public IEnumerator<KeyValuePair<object, T>> GetEnumerator()
            => _map.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        [PerformanceSensitive("https://devdiv.visualstudio.com/DevDiv/_workitems/edit/1279909", AllowCaptures = false)]
        protected T GetCounter(object key)
            => _map.GetOrAdd(key, _createCounter);

        protected bool TryGetCounter(object key, out T counter)
        {
            if (_map.TryGetValue(key, out counter))
            {
                return true;
            }

            return false;
        }
    }

    internal struct StatisticResult
    {
        /// <summary>
        /// maximum value
        /// </summary>
        public readonly int Maximum;

        /// <summary>
        /// minimum value
        /// </summary>
        public readonly int Minimum;

        /// <summary>
        /// middle value of the total data set
        /// </summary>
        public readonly int? Median;

        /// <summary>
        /// average value of the total data set
        /// </summary>
        public readonly int Mean;

        /// <summary>
        /// most frequent value in the total data set
        /// </summary>
        public readonly int? Mode;

        /// <summary>
        /// difference between max and min value
        /// </summary>
        public readonly int Range;

        /// <summary>
        /// number of data points in the total data set
        /// </summary>
        public readonly int Count;

        public StatisticResult(int max, int min, int? median, int mean, int range, int? mode, int count)
        {
            this.Maximum = max;
            this.Minimum = min;
            this.Median = median;
            this.Mean = mean;
            this.Range = range;
            this.Mode = mode;
            this.Count = count;
        }
    }
}
