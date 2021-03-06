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
[assembly: AssemblyTitle("Microsoft.Win32.Registry")]
[assembly: AssemblyDescription("Microsoft.Win32.Registry")]
[assembly: AssemblyDefaultAlias("Microsoft.Win32.Registry")]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyProduct("Microsoft® .NET Framework")]
[assembly: AssemblyCopyright("© Microsoft Corporation.  All rights reserved.")]
[assembly: AssemblyFileVersion("1.0.24212.01")]
[assembly: AssemblyInformationalVersion("1.0.24212.01 built by: SOURCEBUILD")]
[assembly: CLSCompliant(true)]
[assembly: AssemblyMetadata("", "")]
[assembly: AssemblyVersion("4.0.0.0")]




namespace Microsoft.Win32
{
    public static partial class Registry
    {
        public static readonly Microsoft.Win32.RegistryKey ClassesRoot;
        public static readonly Microsoft.Win32.RegistryKey CurrentConfig;
        public static readonly Microsoft.Win32.RegistryKey CurrentUser;
        public static readonly Microsoft.Win32.RegistryKey LocalMachine;
        public static readonly Microsoft.Win32.RegistryKey PerformanceData;
        public static readonly Microsoft.Win32.RegistryKey Users;
        public static object GetValue(string keyName, string valueName, object defaultValue) { throw null; }
        public static void SetValue(string keyName, string valueName, object value) { }
        public static void SetValue(string keyName, string valueName, object value, Microsoft.Win32.RegistryValueKind valueKind) { }
    }
    public enum RegistryHive
    {
        ClassesRoot = -2147483648,
        CurrentUser = -2147483647,
        LocalMachine = -2147483646,
        Users = -2147483645,
        PerformanceData = -2147483644,
        CurrentConfig = -2147483643,
    }
    public sealed partial class RegistryKey : System.IDisposable
    {
        internal RegistryKey() { }
        public Microsoft.Win32.SafeHandles.SafeRegistryHandle Handle { get { throw null; } }
        public string Name { get { throw null; } }
        public int SubKeyCount { get { throw null; } }
        public int ValueCount { get { throw null; } }
        public Microsoft.Win32.RegistryView View { get { throw null; } }
        public Microsoft.Win32.RegistryKey CreateSubKey(string subkey) { throw null; }
        public Microsoft.Win32.RegistryKey CreateSubKey(string subkey, bool writable) { throw null; }
        public Microsoft.Win32.RegistryKey CreateSubKey(string subkey, bool writable, Microsoft.Win32.RegistryOptions options) { throw null; }
        public void DeleteSubKey(string subkey) { }
        public void DeleteSubKey(string subkey, bool throwOnMissingSubKey) { }
        public void DeleteSubKeyTree(string subkey) { }
        public void DeleteSubKeyTree(string subkey, bool throwOnMissingSubKey) { }
        public void DeleteValue(string name) { }
        public void DeleteValue(string name, bool throwOnMissingValue) { }
        public void Dispose() { }
        public void Flush() { }
        public static Microsoft.Win32.RegistryKey FromHandle(Microsoft.Win32.SafeHandles.SafeRegistryHandle handle) { throw null; }
        public static Microsoft.Win32.RegistryKey FromHandle(Microsoft.Win32.SafeHandles.SafeRegistryHandle handle, Microsoft.Win32.RegistryView view) { throw null; }
        public string[] GetSubKeyNames() { throw null; }
        public object GetValue(string name) { throw null; }
        public object GetValue(string name, object defaultValue) { throw null; }
        public object GetValue(string name, object defaultValue, Microsoft.Win32.RegistryValueOptions options) { throw null; }
        public Microsoft.Win32.RegistryValueKind GetValueKind(string name) { throw null; }
        public string[] GetValueNames() { throw null; }
        public static Microsoft.Win32.RegistryKey OpenBaseKey(Microsoft.Win32.RegistryHive hKey, Microsoft.Win32.RegistryView view) { throw null; }
        public Microsoft.Win32.RegistryKey OpenSubKey(string name) { throw null; }
        public Microsoft.Win32.RegistryKey OpenSubKey(string name, bool writable) { throw null; }
        public Microsoft.Win32.RegistryKey OpenSubKey(string name, System.Security.AccessControl.RegistryRights rights) { throw null; }
        public void SetValue(string name, object value) { }
        public void SetValue(string name, object value, Microsoft.Win32.RegistryValueKind valueKind) { }
        public override string ToString() { throw null; }
    }
    [System.FlagsAttribute]
    public enum RegistryOptions
    {
        None = 0,
        Volatile = 1,
    }
    public enum RegistryValueKind
    {
        None = -1,
        Unknown = 0,
        String = 1,
        ExpandString = 2,
        Binary = 3,
        DWord = 4,
        MultiString = 7,
        QWord = 11,
    }
    [System.FlagsAttribute]
    public enum RegistryValueOptions
    {
        None = 0,
        DoNotExpandEnvironmentNames = 1,
    }
    public enum RegistryView
    {
        Default = 0,
        Registry64 = 256,
        Registry32 = 512,
    }
}
namespace Microsoft.Win32.SafeHandles
{
    public sealed partial class SafeRegistryHandle : System.Runtime.InteropServices.SafeHandle
    {
        public SafeRegistryHandle(System.IntPtr preexistingHandle, bool ownsHandle) : base (default(System.IntPtr), default(bool)) { }
        public override bool IsInvalid { get { throw null; } }
        protected override bool ReleaseHandle() { throw null; }
    }
}
namespace System.Security.AccessControl
{
    [System.FlagsAttribute]
    public enum RegistryRights
    {
        QueryValues = 1,
        SetValue = 2,
        CreateSubKey = 4,
        EnumerateSubKeys = 8,
        Notify = 16,
        CreateLink = 32,
        Delete = 65536,
        ReadPermissions = 131072,
        WriteKey = 131078,
        ExecuteKey = 131097,
        ReadKey = 131097,
        ChangePermissions = 262144,
        TakeOwnership = 524288,
        FullControl = 983103,
    }
}
