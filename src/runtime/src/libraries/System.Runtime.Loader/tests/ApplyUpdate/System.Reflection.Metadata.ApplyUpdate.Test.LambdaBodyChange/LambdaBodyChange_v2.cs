// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using System;

namespace System.Reflection.Metadata.ApplyUpdate.Test
{
    public class LambdaBodyChange {

        public LambdaBodyChange () {}

        public string MethodWithLambda () {
            Func<string,string> fn = static (s) => s + " STRING!";
            return fn("NEWEST");
        }
    }
}