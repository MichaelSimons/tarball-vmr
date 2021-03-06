// Copyright (c) Microsoft Corporation.  All Rights Reserved.  See License.txt in the project root for license information.
module FSharp.Core.UnitTests.Collections.ArrayProperties

open System
open System.Collections.Generic

open Xunit
open FsCheck
open Utils

let isStable sorted = sorted |> Seq.pairwise |> Seq.forall (fun ((ia, a),(ib, b)) -> if a = b then ia < ib else true)
 
let distinctByStable<'a when 'a : comparison> (xs : 'a []) =
    let indexed = xs |> Seq.indexed |> Seq.toArray
    let sorted = indexed |> Array.distinctBy snd
    isStable sorted
 
[<Fact>]
let ``Array.distinctBy is stable`` () =
    Check.QuickThrowOnFailure distinctByStable<int>
    Check.QuickThrowOnFailure distinctByStable<string>
 
let blitWorksLikeCopy<'a when 'a : comparison> (source : 'a [], sourceIndex, target : 'a [], targetIndex, count) =
    let target1 = Array.copy target
    let target2 = Array.copy target
    let a = runAndCheckIfAnyError (fun () -> Array.blit source sourceIndex target1 targetIndex count)
    let b = runAndCheckIfAnyError (fun () -> Array.Copy(source, sourceIndex, target2, targetIndex, count))
    a = b && target1 = target2
 
[<Fact>]
let ``Array.blit works like Array.Copy`` () =
    Check.QuickThrowOnFailure blitWorksLikeCopy<int>
    Check.QuickThrowOnFailure blitWorksLikeCopy<string>
