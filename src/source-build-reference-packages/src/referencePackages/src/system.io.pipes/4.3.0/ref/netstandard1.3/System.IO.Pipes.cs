// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// ------------------------------------------------------------------------------
// Changes to this file must follow the http://aka.ms/api-review process.
// ------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;

[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AllowPartiallyTrustedCallers]
[assembly: ReferenceAssembly]
[assembly: AssemblyTitle("System.IO.Pipes")]
[assembly: AssemblyDescription("System.IO.Pipes")]
[assembly: AssemblyDefaultAlias("System.IO.Pipes")]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyProduct("Microsoft® .NET Framework")]
[assembly: AssemblyCopyright("© Microsoft Corporation.  All rights reserved.")]
[assembly: AssemblyFileVersion("1.0.24212.01")]
[assembly: AssemblyInformationalVersion("1.0.24212.01 built by: SOURCEBUILD")]
[assembly: CLSCompliant(true)]
[assembly: AssemblyMetadata("", "")]
[assembly: AssemblyVersion("4.0.0.0")]




namespace Microsoft.Win32.SafeHandles
{
    public sealed partial class SafePipeHandle : System.Runtime.InteropServices.SafeHandle
    {
        public SafePipeHandle(System.IntPtr preexistingHandle, bool ownsHandle) : base (default(System.IntPtr), default(bool)) { }
        public override bool IsInvalid { get { throw null; } }
        protected override bool ReleaseHandle() { throw null; }
    }
}
namespace System.IO.Pipes
{
    public sealed partial class AnonymousPipeClientStream : System.IO.Pipes.PipeStream
    {
        public AnonymousPipeClientStream(System.IO.Pipes.PipeDirection direction, Microsoft.Win32.SafeHandles.SafePipeHandle safePipeHandle) : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public AnonymousPipeClientStream(System.IO.Pipes.PipeDirection direction, string pipeHandleAsString) : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public AnonymousPipeClientStream(string pipeHandleAsString) : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public override System.IO.Pipes.PipeTransmissionMode ReadMode { set { } }
        public override System.IO.Pipes.PipeTransmissionMode TransmissionMode { get { throw null; } }
        ~AnonymousPipeClientStream() { }
    }
    public sealed partial class AnonymousPipeServerStream : System.IO.Pipes.PipeStream
    {
        public AnonymousPipeServerStream() : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public AnonymousPipeServerStream(System.IO.Pipes.PipeDirection direction) : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public AnonymousPipeServerStream(System.IO.Pipes.PipeDirection direction, Microsoft.Win32.SafeHandles.SafePipeHandle serverSafePipeHandle, Microsoft.Win32.SafeHandles.SafePipeHandle clientSafePipeHandle) : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public AnonymousPipeServerStream(System.IO.Pipes.PipeDirection direction, System.IO.HandleInheritability inheritability) : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public AnonymousPipeServerStream(System.IO.Pipes.PipeDirection direction, System.IO.HandleInheritability inheritability, int bufferSize) : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public Microsoft.Win32.SafeHandles.SafePipeHandle ClientSafePipeHandle { get { throw null; } }
        public override System.IO.Pipes.PipeTransmissionMode ReadMode { set { } }
        public override System.IO.Pipes.PipeTransmissionMode TransmissionMode { get { throw null; } }
        protected override void Dispose(bool disposing) { }
        public void DisposeLocalCopyOfClientHandle() { }
        ~AnonymousPipeServerStream() { }
        public string GetClientHandleAsString() { throw null; }
    }
    public sealed partial class NamedPipeClientStream : System.IO.Pipes.PipeStream
    {
        public NamedPipeClientStream(System.IO.Pipes.PipeDirection direction, bool isAsync, bool isConnected, Microsoft.Win32.SafeHandles.SafePipeHandle safePipeHandle) : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public NamedPipeClientStream(string pipeName) : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public NamedPipeClientStream(string serverName, string pipeName) : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public NamedPipeClientStream(string serverName, string pipeName, System.IO.Pipes.PipeDirection direction) : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public NamedPipeClientStream(string serverName, string pipeName, System.IO.Pipes.PipeDirection direction, System.IO.Pipes.PipeOptions options) : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public NamedPipeClientStream(string serverName, string pipeName, System.IO.Pipes.PipeDirection direction, System.IO.Pipes.PipeOptions options, System.Security.Principal.TokenImpersonationLevel impersonationLevel) : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public int NumberOfServerInstances { get { throw null; } }
        public void Connect() { }
        public void Connect(int timeout) { }
        public System.Threading.Tasks.Task ConnectAsync() { throw null; }
        public System.Threading.Tasks.Task ConnectAsync(int timeout) { throw null; }
        public System.Threading.Tasks.Task ConnectAsync(int timeout, System.Threading.CancellationToken cancellationToken) { throw null; }
        public System.Threading.Tasks.Task ConnectAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        ~NamedPipeClientStream() { }
    }
    public sealed partial class NamedPipeServerStream : System.IO.Pipes.PipeStream
    {
        public NamedPipeServerStream(System.IO.Pipes.PipeDirection direction, bool isAsync, bool isConnected, Microsoft.Win32.SafeHandles.SafePipeHandle safePipeHandle) : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public NamedPipeServerStream(string pipeName) : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public NamedPipeServerStream(string pipeName, System.IO.Pipes.PipeDirection direction) : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public NamedPipeServerStream(string pipeName, System.IO.Pipes.PipeDirection direction, int maxNumberOfServerInstances) : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public NamedPipeServerStream(string pipeName, System.IO.Pipes.PipeDirection direction, int maxNumberOfServerInstances, System.IO.Pipes.PipeTransmissionMode transmissionMode) : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public NamedPipeServerStream(string pipeName, System.IO.Pipes.PipeDirection direction, int maxNumberOfServerInstances, System.IO.Pipes.PipeTransmissionMode transmissionMode, System.IO.Pipes.PipeOptions options) : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public NamedPipeServerStream(string pipeName, System.IO.Pipes.PipeDirection direction, int maxNumberOfServerInstances, System.IO.Pipes.PipeTransmissionMode transmissionMode, System.IO.Pipes.PipeOptions options, int inBufferSize, int outBufferSize) : base (default(System.IO.Pipes.PipeDirection), default(int)) { }
        public void Disconnect() { }
        ~NamedPipeServerStream() { }
        public string GetImpersonationUserName() { throw null; }
        public void WaitForConnection() { }
        public System.Threading.Tasks.Task WaitForConnectionAsync() { throw null; }
        public System.Threading.Tasks.Task WaitForConnectionAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public enum PipeDirection
    {
        In = 1,
        InOut = 3,
        Out = 2,
    }
    [System.FlagsAttribute]
    public enum PipeOptions
    {
        Asynchronous = 1073741824,
        None = 0,
        WriteThrough = -2147483648,
    }
    public abstract partial class PipeStream : System.IO.Stream
    {
        protected PipeStream(System.IO.Pipes.PipeDirection direction, int bufferSize) { }
        protected PipeStream(System.IO.Pipes.PipeDirection direction, System.IO.Pipes.PipeTransmissionMode transmissionMode, int outBufferSize) { }
        public override bool CanRead { get { throw null; } }
        public override bool CanSeek { get { throw null; } }
        public override bool CanWrite { get { throw null; } }
        public virtual int InBufferSize { get { throw null; } }
        public bool IsAsync { get { throw null; } }
        public bool IsConnected { get { throw null; } protected set { } }
        public bool IsMessageComplete { get { throw null; } }
        public override long Length { get { throw null; } }
        public virtual int OutBufferSize { get { throw null; } }
        public override long Position { get { throw null; } set { } }
        public virtual System.IO.Pipes.PipeTransmissionMode ReadMode { get { throw null; } set { } }
        public Microsoft.Win32.SafeHandles.SafePipeHandle SafePipeHandle { get { throw null; } }
        public virtual System.IO.Pipes.PipeTransmissionMode TransmissionMode { get { throw null; } }
        protected override void Dispose(bool disposing) { }
        public override void Flush() { }
        public override int Read(byte[] buffer, int offset, int count) { throw null; }
        public override System.Threading.Tasks.Task<int> ReadAsync(byte[] buffer, int offset, int count, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override int ReadByte() { throw null; }
        public override long Seek(long offset, System.IO.SeekOrigin origin) { throw null; }
        public override void SetLength(long value) { }
        public void WaitForPipeDrain() { }
        public override void Write(byte[] buffer, int offset, int count) { }
        public override System.Threading.Tasks.Task WriteAsync(byte[] buffer, int offset, int count, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override void WriteByte(byte value) { }
    }
    public enum PipeTransmissionMode
    {
        Byte = 0,
        Message = 1,
    }
}
