
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern FSharp.Core
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 5:0:0:0
}
.assembly Testfunction22g
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.FSharpInterfaceDataVersionAttribute::.ctor(int32,
                                                                                                      int32,
                                                                                                      int32) = ( 01 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 ) 

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 01 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.mresource public FSharpSignatureData.Testfunction22g
{
  // Offset: 0x00000000 Length: 0x00000159
}
.mresource public FSharpOptimizationData.Testfunction22g
{
  // Offset: 0x00000160 Length: 0x00000056
}
.module Testfunction22g.exe
// MVID: {611C4D9E-CA89-74DB-A745-03839E4D1C61}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x04D30000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed Testfunction22g
       extends [mscorlib]System.Object
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
} // end of class Testfunction22g

.class private abstract auto ansi sealed '<StartupCode$Testfunction22g>'.$Testfunction22g
       extends [mscorlib]System.Object
{
  .field static assembly int32 init@
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public static void  main@() cil managed
  {
    .entrypoint
    // Code size       19 (0x13)
    .maxstack  8
    .language '{AB4F38C9-B6E6-43BA-BE3B-58080B2CCCE3}', '{994B45C4-E6E9-11D2-903F-00C04FA302A1}', '{5A869D0B-6611-11D3-BD2A-0000F80849BD}'
    .line 3,3 : 1,13 'C:\\GitHub\\dsyme\\fsharp\\tests\\fsharpqa\\source\\CodeGen\\EmittedIL\\TestFunctions\\Testfunction22g.fs'
    IL_0000:  nop
    .line 100001,100001 : 0,0 ''
    IL_0001:  ldc.i4.1
    IL_0002:  brfalse.s  IL_000c

    .line 3,3 : 14,40 ''
    IL_0004:  call       void [mscorlib]System.Console::WriteLine()
    .line 100001,100001 : 0,0 ''
    IL_0009:  nop
    IL_000a:  br.s       IL_0012

    .line 3,3 : 46,72 ''
    IL_000c:  call       void [mscorlib]System.Console::WriteLine()
    .line 100001,100001 : 0,0 ''
    IL_0011:  nop
    IL_0012:  ret
  } // end of method $Testfunction22g::main@

} // end of class '<StartupCode$Testfunction22g>'.$Testfunction22g


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
