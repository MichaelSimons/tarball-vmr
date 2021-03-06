// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// ------------------------------------------------------------------------------
// Changes to this file must follow the http://aka.ms/api-review process.
// ------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;

[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AllowPartiallyTrustedCallers]
[assembly: ReferenceAssembly]
[assembly: AssemblyTitle("System.IO")]
[assembly: AssemblyDescription("System.IO")]
[assembly: AssemblyDefaultAlias("System.IO")]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyProduct("Microsoft® .NET Framework")]
[assembly: AssemblyCopyright("© Microsoft Corporation.  All rights reserved.")]
[assembly: AssemblyFileVersion("1.0.24212.01")]
[assembly: AssemblyInformationalVersion("1.0.24212.01 built by: SOURCEBUILD")]
[assembly: CLSCompliant(true)]
[assembly: AssemblyMetadata("", "")]
[assembly: AssemblyVersion("4.1.0.0")]




namespace System.IO
{
    public partial class BinaryReader : System.IDisposable
    {
        public BinaryReader(System.IO.Stream input) { }
        public BinaryReader(System.IO.Stream input, System.Text.Encoding encoding) { }
        public BinaryReader(System.IO.Stream input, System.Text.Encoding encoding, bool leaveOpen) { }
        public virtual System.IO.Stream BaseStream { get { throw null; } }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        protected virtual void FillBuffer(int numBytes) { }
        public virtual int PeekChar() { throw null; }
        public virtual int Read() { throw null; }
        public virtual int Read(byte[] buffer, int index, int count) { throw null; }
        public virtual int Read(char[] buffer, int index, int count) { throw null; }
        protected internal int Read7BitEncodedInt() { throw null; }
        public virtual bool ReadBoolean() { throw null; }
        public virtual byte ReadByte() { throw null; }
        public virtual byte[] ReadBytes(int count) { throw null; }
        public virtual char ReadChar() { throw null; }
        public virtual char[] ReadChars(int count) { throw null; }
        public virtual decimal ReadDecimal() { throw null; }
        public virtual double ReadDouble() { throw null; }
        public virtual short ReadInt16() { throw null; }
        public virtual int ReadInt32() { throw null; }
        public virtual long ReadInt64() { throw null; }
        [System.CLSCompliantAttribute(false)]
        public virtual sbyte ReadSByte() { throw null; }
        public virtual float ReadSingle() { throw null; }
        public virtual string ReadString() { throw null; }
        [System.CLSCompliantAttribute(false)]
        public virtual ushort ReadUInt16() { throw null; }
        [System.CLSCompliantAttribute(false)]
        public virtual uint ReadUInt32() { throw null; }
        [System.CLSCompliantAttribute(false)]
        public virtual ulong ReadUInt64() { throw null; }
    }
    public partial class BinaryWriter : System.IDisposable
    {
        public static readonly System.IO.BinaryWriter Null;
        protected System.IO.Stream OutStream;
        protected BinaryWriter() { }
        public BinaryWriter(System.IO.Stream output) { }
        public BinaryWriter(System.IO.Stream output, System.Text.Encoding encoding) { }
        public BinaryWriter(System.IO.Stream output, System.Text.Encoding encoding, bool leaveOpen) { }
        public virtual System.IO.Stream BaseStream { get { throw null; } }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public virtual void Flush() { }
        public virtual long Seek(int offset, System.IO.SeekOrigin origin) { throw null; }
        public virtual void Write(bool value) { }
        public virtual void Write(byte value) { }
        public virtual void Write(byte[] buffer) { }
        public virtual void Write(byte[] buffer, int index, int count) { }
        public virtual void Write(char ch) { }
        public virtual void Write(char[] chars) { }
        public virtual void Write(char[] chars, int index, int count) { }
        public virtual void Write(decimal value) { }
        public virtual void Write(double value) { }
        public virtual void Write(short value) { }
        public virtual void Write(int value) { }
        public virtual void Write(long value) { }
        [System.CLSCompliantAttribute(false)]
        public virtual void Write(sbyte value) { }
        public virtual void Write(float value) { }
        public virtual void Write(string value) { }
        [System.CLSCompliantAttribute(false)]
        public virtual void Write(ushort value) { }
        [System.CLSCompliantAttribute(false)]
        public virtual void Write(uint value) { }
        [System.CLSCompliantAttribute(false)]
        public virtual void Write(ulong value) { }
        protected void Write7BitEncodedInt(int value) { }
    }
    public sealed partial class BufferedStream : System.IO.Stream
    {
        public BufferedStream(System.IO.Stream stream) { }
        public BufferedStream(System.IO.Stream stream, int bufferSize) { }
        public override bool CanRead { get { throw null; } }
        public override bool CanSeek { get { throw null; } }
        public override bool CanWrite { get { throw null; } }
        public override long Length { get { throw null; } }
        public override long Position { get { throw null; } set { } }
        protected override void Dispose(bool disposing) { }
        public override void Flush() { }
        public override System.Threading.Tasks.Task FlushAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public override int Read(byte[] array, int offset, int count) { throw null; }
        public override System.Threading.Tasks.Task<int> ReadAsync(byte[] buffer, int offset, int count, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override int ReadByte() { throw null; }
        public override long Seek(long offset, System.IO.SeekOrigin origin) { throw null; }
        public override void SetLength(long value) { }
        public override void Write(byte[] array, int offset, int count) { }
        public override System.Threading.Tasks.Task WriteAsync(byte[] buffer, int offset, int count, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override void WriteByte(byte value) { }
    }
    public partial class EndOfStreamException : System.IO.IOException
    {
        public EndOfStreamException() { }
        public EndOfStreamException(string message) { }
        public EndOfStreamException(string message, System.Exception innerException) { }
    }
    public sealed partial class InvalidDataException : System.Exception
    {
        public InvalidDataException() { }
        public InvalidDataException(string message) { }
        public InvalidDataException(string message, System.Exception innerException) { }
    }
    public partial class MemoryStream : System.IO.Stream
    {
        public MemoryStream() { }
        public MemoryStream(byte[] buffer) { }
        public MemoryStream(byte[] buffer, bool writable) { }
        public MemoryStream(byte[] buffer, int index, int count) { }
        public MemoryStream(byte[] buffer, int index, int count, bool writable) { }
        public MemoryStream(byte[] buffer, int index, int count, bool writable, bool publiclyVisible) { }
        public MemoryStream(int capacity) { }
        public override bool CanRead { get { throw null; } }
        public override bool CanSeek { get { throw null; } }
        public override bool CanWrite { get { throw null; } }
        public virtual int Capacity { get { throw null; } set { } }
        public override long Length { get { throw null; } }
        public override long Position { get { throw null; } set { } }
        public override System.Threading.Tasks.Task CopyToAsync(System.IO.Stream destination, int bufferSize, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected override void Dispose(bool disposing) { }
        public override void Flush() { }
        public override System.Threading.Tasks.Task FlushAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public override int Read(byte[] buffer, int offset, int count) { throw null; }
        public override System.Threading.Tasks.Task<int> ReadAsync(byte[] buffer, int offset, int count, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override int ReadByte() { throw null; }
        public override long Seek(long offset, System.IO.SeekOrigin loc) { throw null; }
        public override void SetLength(long value) { }
        public virtual byte[] ToArray() { throw null; }
        public virtual bool TryGetBuffer(out System.ArraySegment<byte> buffer) { throw null; }
        public override void Write(byte[] buffer, int offset, int count) { }
        public override System.Threading.Tasks.Task WriteAsync(byte[] buffer, int offset, int count, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override void WriteByte(byte value) { }
        public virtual void WriteTo(System.IO.Stream stream) { }
    }
    public enum SeekOrigin
    {
        Begin = 0,
        Current = 1,
        End = 2,
    }
    public abstract partial class Stream : System.IDisposable
    {
        public static readonly System.IO.Stream Null;
        protected Stream() { }
        public abstract bool CanRead { get; }
        public abstract bool CanSeek { get; }
        public virtual bool CanTimeout { get { throw null; } }
        public abstract bool CanWrite { get; }
        public abstract long Length { get; }
        public abstract long Position { get; set; }
        public virtual int ReadTimeout { get { throw null; } set { } }
        public virtual int WriteTimeout { get { throw null; } set { } }
        public void CopyTo(System.IO.Stream destination) { }
        public void CopyTo(System.IO.Stream destination, int bufferSize) { }
        public System.Threading.Tasks.Task CopyToAsync(System.IO.Stream destination) { throw null; }
        public System.Threading.Tasks.Task CopyToAsync(System.IO.Stream destination, int bufferSize) { throw null; }
        public virtual System.Threading.Tasks.Task CopyToAsync(System.IO.Stream destination, int bufferSize, System.Threading.CancellationToken cancellationToken) { throw null; }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public abstract void Flush();
        public System.Threading.Tasks.Task FlushAsync() { throw null; }
        public virtual System.Threading.Tasks.Task FlushAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public abstract int Read(byte[] buffer, int offset, int count);
        public System.Threading.Tasks.Task<int> ReadAsync(byte[] buffer, int offset, int count) { throw null; }
        public virtual System.Threading.Tasks.Task<int> ReadAsync(byte[] buffer, int offset, int count, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual int ReadByte() { throw null; }
        public abstract long Seek(long offset, System.IO.SeekOrigin origin);
        public abstract void SetLength(long value);
        public abstract void Write(byte[] buffer, int offset, int count);
        public System.Threading.Tasks.Task WriteAsync(byte[] buffer, int offset, int count) { throw null; }
        public virtual System.Threading.Tasks.Task WriteAsync(byte[] buffer, int offset, int count, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual void WriteByte(byte value) { }
    }
    public partial class StreamReader : System.IO.TextReader
    {
        public static readonly new System.IO.StreamReader Null;
        public StreamReader(System.IO.Stream stream) { }
        public StreamReader(System.IO.Stream stream, bool detectEncodingFromByteOrderMarks) { }
        public StreamReader(System.IO.Stream stream, System.Text.Encoding encoding) { }
        public StreamReader(System.IO.Stream stream, System.Text.Encoding encoding, bool detectEncodingFromByteOrderMarks) { }
        public StreamReader(System.IO.Stream stream, System.Text.Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize) { }
        public StreamReader(System.IO.Stream stream, System.Text.Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen) { }
        public virtual System.IO.Stream BaseStream { get { throw null; } }
        public virtual System.Text.Encoding CurrentEncoding { get { throw null; } }
        public bool EndOfStream { get { throw null; } }
        public void DiscardBufferedData() { }
        protected override void Dispose(bool disposing) { }
        public override int Peek() { throw null; }
        public override int Read() { throw null; }
        public override int Read(char[] buffer, int index, int count) { throw null; }
        public override System.Threading.Tasks.Task<int> ReadAsync(char[] buffer, int index, int count) { throw null; }
        public override int ReadBlock(char[] buffer, int index, int count) { throw null; }
        public override System.Threading.Tasks.Task<int> ReadBlockAsync(char[] buffer, int index, int count) { throw null; }
        public override string ReadLine() { throw null; }
        public override System.Threading.Tasks.Task<string> ReadLineAsync() { throw null; }
        public override string ReadToEnd() { throw null; }
        public override System.Threading.Tasks.Task<string> ReadToEndAsync() { throw null; }
    }
    public partial class StreamWriter : System.IO.TextWriter
    {
        public static readonly new System.IO.StreamWriter Null;
        public StreamWriter(System.IO.Stream stream) { }
        public StreamWriter(System.IO.Stream stream, System.Text.Encoding encoding) { }
        public StreamWriter(System.IO.Stream stream, System.Text.Encoding encoding, int bufferSize) { }
        public StreamWriter(System.IO.Stream stream, System.Text.Encoding encoding, int bufferSize, bool leaveOpen) { }
        public virtual bool AutoFlush { get { throw null; } set { } }
        public virtual System.IO.Stream BaseStream { get { throw null; } }
        public override System.Text.Encoding Encoding { get { throw null; } }
        protected override void Dispose(bool disposing) { }
        public override void Flush() { }
        public override System.Threading.Tasks.Task FlushAsync() { throw null; }
        public override void Write(char value) { }
        public override void Write(char[] buffer) { }
        public override void Write(char[] buffer, int index, int count) { }
        public override void Write(string value) { }
        public override System.Threading.Tasks.Task WriteAsync(char value) { throw null; }
        public override System.Threading.Tasks.Task WriteAsync(char[] buffer, int index, int count) { throw null; }
        public override System.Threading.Tasks.Task WriteAsync(string value) { throw null; }
        public override System.Threading.Tasks.Task WriteLineAsync() { throw null; }
        public override System.Threading.Tasks.Task WriteLineAsync(char value) { throw null; }
        public override System.Threading.Tasks.Task WriteLineAsync(char[] buffer, int index, int count) { throw null; }
        public override System.Threading.Tasks.Task WriteLineAsync(string value) { throw null; }
    }
    public partial class StringReader : System.IO.TextReader
    {
        public StringReader(string s) { }
        protected override void Dispose(bool disposing) { }
        public override int Peek() { throw null; }
        public override int Read() { throw null; }
        public override int Read(char[] buffer, int index, int count) { throw null; }
        public override System.Threading.Tasks.Task<int> ReadAsync(char[] buffer, int index, int count) { throw null; }
        public override System.Threading.Tasks.Task<int> ReadBlockAsync(char[] buffer, int index, int count) { throw null; }
        public override string ReadLine() { throw null; }
        public override System.Threading.Tasks.Task<string> ReadLineAsync() { throw null; }
        public override string ReadToEnd() { throw null; }
        public override System.Threading.Tasks.Task<string> ReadToEndAsync() { throw null; }
    }
    public partial class StringWriter : System.IO.TextWriter
    {
        public StringWriter() { }
        public StringWriter(System.IFormatProvider formatProvider) { }
        public StringWriter(System.Text.StringBuilder sb) { }
        public StringWriter(System.Text.StringBuilder sb, System.IFormatProvider formatProvider) { }
        public override System.Text.Encoding Encoding { get { throw null; } }
        protected override void Dispose(bool disposing) { }
        public override System.Threading.Tasks.Task FlushAsync() { throw null; }
        public virtual System.Text.StringBuilder GetStringBuilder() { throw null; }
        public override string ToString() { throw null; }
        public override void Write(char value) { }
        public override void Write(char[] buffer, int index, int count) { }
        public override void Write(string value) { }
        public override System.Threading.Tasks.Task WriteAsync(char value) { throw null; }
        public override System.Threading.Tasks.Task WriteAsync(char[] buffer, int index, int count) { throw null; }
        public override System.Threading.Tasks.Task WriteAsync(string value) { throw null; }
        public override System.Threading.Tasks.Task WriteLineAsync(char value) { throw null; }
        public override System.Threading.Tasks.Task WriteLineAsync(char[] buffer, int index, int count) { throw null; }
        public override System.Threading.Tasks.Task WriteLineAsync(string value) { throw null; }
    }
    public abstract partial class TextReader : System.IDisposable
    {
        public static readonly System.IO.TextReader Null;
        protected TextReader() { }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public virtual int Peek() { throw null; }
        public virtual int Read() { throw null; }
        public virtual int Read(char[] buffer, int index, int count) { throw null; }
        public virtual System.Threading.Tasks.Task<int> ReadAsync(char[] buffer, int index, int count) { throw null; }
        public virtual int ReadBlock(char[] buffer, int index, int count) { throw null; }
        public virtual System.Threading.Tasks.Task<int> ReadBlockAsync(char[] buffer, int index, int count) { throw null; }
        public virtual string ReadLine() { throw null; }
        public virtual System.Threading.Tasks.Task<string> ReadLineAsync() { throw null; }
        public virtual string ReadToEnd() { throw null; }
        public virtual System.Threading.Tasks.Task<string> ReadToEndAsync() { throw null; }
    }
    public abstract partial class TextWriter : System.IDisposable
    {
        protected char[] CoreNewLine;
        public static readonly System.IO.TextWriter Null;
        protected TextWriter() { }
        protected TextWriter(System.IFormatProvider formatProvider) { }
        public abstract System.Text.Encoding Encoding { get; }
        public virtual System.IFormatProvider FormatProvider { get { throw null; } }
        public virtual string NewLine { get { throw null; } set { } }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public virtual void Flush() { }
        public virtual System.Threading.Tasks.Task FlushAsync() { throw null; }
        public virtual void Write(bool value) { }
        public abstract void Write(char value);
        public virtual void Write(char[] buffer) { }
        public virtual void Write(char[] buffer, int index, int count) { }
        public virtual void Write(decimal value) { }
        public virtual void Write(double value) { }
        public virtual void Write(int value) { }
        public virtual void Write(long value) { }
        public virtual void Write(object value) { }
        public virtual void Write(float value) { }
        public virtual void Write(string value) { }
        public virtual void Write(string format, object arg0) { }
        public virtual void Write(string format, object arg0, object arg1) { }
        public virtual void Write(string format, object arg0, object arg1, object arg2) { }
        public virtual void Write(string format, params object[] arg) { }
        [System.CLSCompliantAttribute(false)]
        public virtual void Write(uint value) { }
        [System.CLSCompliantAttribute(false)]
        public virtual void Write(ulong value) { }
        public virtual System.Threading.Tasks.Task WriteAsync(char value) { throw null; }
        public System.Threading.Tasks.Task WriteAsync(char[] buffer) { throw null; }
        public virtual System.Threading.Tasks.Task WriteAsync(char[] buffer, int index, int count) { throw null; }
        public virtual System.Threading.Tasks.Task WriteAsync(string value) { throw null; }
        public virtual void WriteLine() { }
        public virtual void WriteLine(bool value) { }
        public virtual void WriteLine(char value) { }
        public virtual void WriteLine(char[] buffer) { }
        public virtual void WriteLine(char[] buffer, int index, int count) { }
        public virtual void WriteLine(decimal value) { }
        public virtual void WriteLine(double value) { }
        public virtual void WriteLine(int value) { }
        public virtual void WriteLine(long value) { }
        public virtual void WriteLine(object value) { }
        public virtual void WriteLine(float value) { }
        public virtual void WriteLine(string value) { }
        public virtual void WriteLine(string format, object arg0) { }
        public virtual void WriteLine(string format, object arg0, object arg1) { }
        public virtual void WriteLine(string format, object arg0, object arg1, object arg2) { }
        public virtual void WriteLine(string format, params object[] arg) { }
        [System.CLSCompliantAttribute(false)]
        public virtual void WriteLine(uint value) { }
        [System.CLSCompliantAttribute(false)]
        public virtual void WriteLine(ulong value) { }
        public virtual System.Threading.Tasks.Task WriteLineAsync() { throw null; }
        public virtual System.Threading.Tasks.Task WriteLineAsync(char value) { throw null; }
        public System.Threading.Tasks.Task WriteLineAsync(char[] buffer) { throw null; }
        public virtual System.Threading.Tasks.Task WriteLineAsync(char[] buffer, int index, int count) { throw null; }
        public virtual System.Threading.Tasks.Task WriteLineAsync(string value) { throw null; }
    }
}
