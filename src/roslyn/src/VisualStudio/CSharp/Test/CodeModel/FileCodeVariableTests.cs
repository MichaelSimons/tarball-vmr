// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#nullable disable

using System;
using System.Runtime.InteropServices;
using EnvDTE;
using Microsoft.CodeAnalysis.Test.Utilities;
using Roslyn.Test.Utilities;
using Xunit;

namespace Microsoft.VisualStudio.LanguageServices.CSharp.UnitTests.CodeModel
{
    public class FileCodeVariableTests : AbstractFileCodeElementTests
    {
        public FileCodeVariableTests()
            : base(@"using System;

public class A
{
    // This is a comment.
    public int intA;

   /// <summary>
   /// This is a summary.
   /// </summary>
    protected int intB;

    [Serializable]
    private int intC = 4;
    int intD;

    public static const int FORTYTWO = 42;
}

unsafe public struct DevDivBugs70194
{
    fixed char buffer[100];
}")
        {
        }

        private CodeVariable GetCodeVariable(params object[] path)
        {
            return (CodeVariable)GetCodeElement(path);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void Access_Public()
        {
            var testObject = GetCodeVariable("A", "intA");

            Assert.Equal(vsCMAccess.vsCMAccessPublic, testObject.Access);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void Access_Protected()
        {
            var testObject = GetCodeVariable("A", "intB");

            Assert.Equal(vsCMAccess.vsCMAccessProtected, testObject.Access);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void Access_Private()
        {
            var testObject = GetCodeVariable("A", "intC");

            Assert.Equal(vsCMAccess.vsCMAccessPrivate, testObject.Access);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void Attributes_Count()
        {
            var testObject = GetCodeVariable("A", "intC");

            Assert.Equal(1, testObject.Attributes.Count);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void Children_Count()
        {
            var testObject = GetCodeVariable("A", "intC");

            Assert.Equal(1, testObject.Children.Count);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void Comment()
        {
            var testObject = GetCodeVariable("A", "intA");

            Assert.Equal("This is a comment.\r\n", testObject.Comment);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void DocComment()
        {
            var testObject = GetCodeVariable("A", "intB");

            var expected = "<doc>\r\n<summary>\r\nThis is a summary.\r\n</summary>\r\n</doc>";

            Assert.Equal(expected, testObject.DocComment);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void InitExpressions_NoExpression()
        {
            var testObject = GetCodeVariable("A", "intB");

            Assert.Null(testObject.InitExpression);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void InitExpression()
        {
            var testObject = GetCodeVariable("A", "intC");

            Assert.Equal("4", testObject.InitExpression);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void InitExpression_FixedBuffer()
        {
            var testObject = GetCodeVariable("DevDivBugs70194", "buffer");

            Assert.Null(testObject.InitExpression);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void IsConstant_True()
        {
            var testObject = GetCodeVariable("A", "FORTYTWO");

            Assert.True(testObject.IsConstant);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void IsConstant_False()
        {
            var testObject = GetCodeVariable("A", "intC");

            Assert.False(testObject.IsConstant);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void IsShared_True()
        {
            var testObject = GetCodeVariable("A", "FORTYTWO");

            Assert.True(testObject.IsShared);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void IsShared_False()
        {
            var testObject = GetCodeVariable("A", "intC");

            Assert.False(testObject.IsShared);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void Kind()
        {
            var testObject = GetCodeVariable("A", "intC");

            Assert.Equal(vsCMElement.vsCMElementVariable, testObject.Kind);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void Parent()
        {
            var testObject = GetCodeVariable("A", "intC");

            var testObjectParent = testObject.Parent as CodeClass;

            Assert.Equal("A", testObjectParent.Name);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void Type()
        {
            var testObject = GetCodeVariable("A", "intC");

            Assert.Equal("System.Int32", testObject.Type.AsFullName);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void GetStartPoint_Attributes()
        {
            var testObject = GetCodeVariable("A", "intC");
            Assert.Throws<NotImplementedException>(() => testObject.GetStartPoint(vsCMPart.vsCMPartAttributes));
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void GetStartPoint_AttributesWithDelimiter()
        {
            var testObject = GetCodeVariable("A", "intC");

            var startPoint = testObject.GetStartPoint(vsCMPart.vsCMPartAttributesWithDelimiter);

            Assert.Equal(13, startPoint.Line);
            Assert.Equal(5, startPoint.LineCharOffset);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void GetStartPoint_Body()
        {
            var testObject = GetCodeVariable("A", "intC");
            Assert.Throws<COMException>(() => testObject.GetStartPoint(vsCMPart.vsCMPartBody));
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void GetStartPoint_BodyWithDelimiter()
        {
            var testObject = GetCodeVariable("A", "intC");
            Assert.Throws<NotImplementedException>(() => testObject.GetStartPoint(vsCMPart.vsCMPartBodyWithDelimiter));
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void GetStartPoint_Header()
        {
            var testObject = GetCodeVariable("A", "intC");
            Assert.Throws<NotImplementedException>(() => testObject.GetStartPoint(vsCMPart.vsCMPartHeader));
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void GetStartPoint_HeaderWithAttributes()
        {
            var testObject = GetCodeVariable("A", "intC");
            Assert.Throws<NotImplementedException>(() => testObject.GetStartPoint(vsCMPart.vsCMPartHeaderWithAttributes));
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void GetStartPoint_Name()
        {
            var testObject = GetCodeVariable("A", "intC");
            Assert.Throws<NotImplementedException>(() => testObject.GetStartPoint(vsCMPart.vsCMPartName));
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void GetStartPoint_Navigate()
        {
            var testObject = GetCodeVariable("A", "intC");

            var startPoint = testObject.GetStartPoint(vsCMPart.vsCMPartNavigate);

            Assert.Equal(14, startPoint.Line);
            Assert.Equal(17, startPoint.LineCharOffset);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void GetStartPoint_Whole()
        {
            var testObject = GetCodeVariable("A", "intC");
            Assert.Throws<NotImplementedException>(() => testObject.GetStartPoint(vsCMPart.vsCMPartWhole));
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void GetStartPoint_WholeWithAttributes()
        {
            var testObject = GetCodeVariable("A", "intC");

            var startPoint = testObject.GetStartPoint(vsCMPart.vsCMPartWholeWithAttributes);

            Assert.Equal(13, startPoint.Line);
            Assert.Equal(5, startPoint.LineCharOffset);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void GetEndPoint_Attributes()
        {
            var testObject = GetCodeVariable("A", "intC");
            Assert.Throws<NotImplementedException>(() => testObject.GetEndPoint(vsCMPart.vsCMPartAttributes));
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void GetEndPoint_AttributesWithDelimiter()
        {
            var testObject = GetCodeVariable("A", "intC");

            var endPoint = testObject.GetEndPoint(vsCMPart.vsCMPartAttributesWithDelimiter);

            Assert.Equal(13, endPoint.Line);
            Assert.Equal(19, endPoint.LineCharOffset);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void GetEndPoint_Body()
        {
            var testObject = GetCodeVariable("A", "intC");
            Assert.Throws<COMException>(() => testObject.GetEndPoint(vsCMPart.vsCMPartBody));
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void GetEndPoint_BodyWithDelimiter()
        {
            var testObject = GetCodeVariable("A", "intC");
            Assert.Throws<NotImplementedException>(() => testObject.GetEndPoint(vsCMPart.vsCMPartBodyWithDelimiter));
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void GetEndPoint_Header()
        {
            var testObject = GetCodeVariable("A", "intC");
            Assert.Throws<NotImplementedException>(() => testObject.GetEndPoint(vsCMPart.vsCMPartHeader));
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void GetEndPoint_HeaderWithAttributes()
        {
            var testObject = GetCodeVariable("A", "intC");
            Assert.Throws<NotImplementedException>(() => testObject.GetEndPoint(vsCMPart.vsCMPartHeaderWithAttributes));
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void GetEndPoint_Name()
        {
            var testObject = GetCodeVariable("A", "intC");
            Assert.Throws<NotImplementedException>(() => testObject.GetEndPoint(vsCMPart.vsCMPartName));
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void GetEndPoint_Navigate()
        {
            var testObject = GetCodeVariable("A", "intC");

            var endPoint = testObject.GetEndPoint(vsCMPart.vsCMPartNavigate);

            Assert.Equal(14, endPoint.Line);
            Assert.Equal(21, endPoint.LineCharOffset);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void GetEndPoint_Whole()
        {
            var testObject = GetCodeVariable("A", "intC");
            Assert.Throws<NotImplementedException>(() => testObject.GetEndPoint(vsCMPart.vsCMPartWhole));
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void GetEndPoint_WholeWithAttributes()
        {
            var testObject = GetCodeVariable("A", "intC");

            var endPoint = testObject.GetEndPoint(vsCMPart.vsCMPartWholeWithAttributes);

            Assert.Equal(14, endPoint.Line);
            Assert.Equal(26, endPoint.LineCharOffset);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void StartPoint()
        {
            var testObject = GetCodeVariable("A", "intC");

            var startPoint = testObject.StartPoint;

            Assert.Equal(13, startPoint.Line);
            Assert.Equal(5, startPoint.LineCharOffset);
        }

        [WpfFact]
        [Trait(Traits.Feature, Traits.Features.CodeModel)]
        public void EndPoint()
        {
            var testObject = GetCodeVariable("A", "intC");

            var endPoint = testObject.EndPoint;

            Assert.Equal(14, endPoint.Line);
            Assert.Equal(26, endPoint.LineCharOffset);
        }
    }
}
