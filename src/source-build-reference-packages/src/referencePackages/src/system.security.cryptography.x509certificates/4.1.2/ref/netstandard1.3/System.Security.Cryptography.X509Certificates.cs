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
[assembly: AssemblyTitle("System.Security.Cryptography.X509Certificates")]
[assembly: AssemblyDescription("System.Security.Cryptography.X509Certificates")]
[assembly: AssemblyDefaultAlias("System.Security.Cryptography.X509Certificates")]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyProduct("Microsoft® .NET Framework")]
[assembly: AssemblyCopyright("© Microsoft Corporation.  All rights reserved.")]
[assembly: AssemblyFileVersion("1.0.25814.07")]
[assembly: AssemblyInformationalVersion("1.0.25814.07 built by: SOURCEBUILD")]
[assembly: CLSCompliant(true)]
[assembly: AssemblyMetadata("", "")]
[assembly: AssemblyVersion("4.0.0.0")]




namespace Microsoft.Win32.SafeHandles
{
    public sealed partial class SafeX509ChainHandle : System.Runtime.InteropServices.SafeHandle
    {
        internal SafeX509ChainHandle() : base (default(System.IntPtr), default(bool)) { }
        public override bool IsInvalid { get { throw null; } }
        protected override bool ReleaseHandle() { throw null; }
    }
}
namespace System.Security.Cryptography.X509Certificates
{
    [System.FlagsAttribute]
    public enum OpenFlags
    {
        ReadOnly = 0,
        ReadWrite = 1,
        MaxAllowed = 2,
        OpenExistingOnly = 4,
        IncludeArchived = 8,
    }
    public sealed partial class PublicKey
    {
        public PublicKey(System.Security.Cryptography.Oid oid, System.Security.Cryptography.AsnEncodedData parameters, System.Security.Cryptography.AsnEncodedData keyValue) { }
        public System.Security.Cryptography.AsnEncodedData EncodedKeyValue { get { throw null; } }
        public System.Security.Cryptography.AsnEncodedData EncodedParameters { get { throw null; } }
        public System.Security.Cryptography.Oid Oid { get { throw null; } }
    }
    public static partial class RSACertificateExtensions
    {
        public static System.Security.Cryptography.RSA GetRSAPrivateKey(this System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) { throw null; }
        public static System.Security.Cryptography.RSA GetRSAPublicKey(this System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) { throw null; }
    }
    public enum StoreLocation
    {
        CurrentUser = 1,
        LocalMachine = 2,
    }
    public enum StoreName
    {
        AddressBook = 1,
        AuthRoot = 2,
        CertificateAuthority = 3,
        Disallowed = 4,
        My = 5,
        Root = 6,
        TrustedPeople = 7,
        TrustedPublisher = 8,
    }
    public sealed partial class X500DistinguishedName : System.Security.Cryptography.AsnEncodedData
    {
        public X500DistinguishedName(byte[] encodedDistinguishedName) { }
        public X500DistinguishedName(System.Security.Cryptography.AsnEncodedData encodedDistinguishedName) { }
        public X500DistinguishedName(System.Security.Cryptography.X509Certificates.X500DistinguishedName distinguishedName) { }
        public X500DistinguishedName(string distinguishedName) { }
        public X500DistinguishedName(string distinguishedName, System.Security.Cryptography.X509Certificates.X500DistinguishedNameFlags flag) { }
        public string Name { get { throw null; } }
        public string Decode(System.Security.Cryptography.X509Certificates.X500DistinguishedNameFlags flag) { throw null; }
        public override string Format(bool multiLine) { throw null; }
    }
    [System.FlagsAttribute]
    public enum X500DistinguishedNameFlags
    {
        None = 0,
        Reversed = 1,
        UseSemicolons = 16,
        DoNotUsePlusSign = 32,
        DoNotUseQuotes = 64,
        UseCommas = 128,
        UseNewLines = 256,
        UseUTF8Encoding = 4096,
        UseT61Encoding = 8192,
        ForceUTF8Encoding = 16384,
    }
    public sealed partial class X509BasicConstraintsExtension : System.Security.Cryptography.X509Certificates.X509Extension
    {
        public X509BasicConstraintsExtension() { }
        public X509BasicConstraintsExtension(bool certificateAuthority, bool hasPathLengthConstraint, int pathLengthConstraint, bool critical) { }
        public X509BasicConstraintsExtension(System.Security.Cryptography.AsnEncodedData encodedBasicConstraints, bool critical) { }
        public bool CertificateAuthority { get { throw null; } }
        public bool HasPathLengthConstraint { get { throw null; } }
        public int PathLengthConstraint { get { throw null; } }
        public override void CopyFrom(System.Security.Cryptography.AsnEncodedData asnEncodedData) { }
    }
    public partial class X509Certificate : System.IDisposable
    {
        public X509Certificate() { }
        public X509Certificate(byte[] data) { }
        public X509Certificate(byte[] rawData, string password) { }
        public X509Certificate(byte[] rawData, string password, System.Security.Cryptography.X509Certificates.X509KeyStorageFlags keyStorageFlags) { }
        public X509Certificate(System.IntPtr handle) { }
        public X509Certificate(string fileName) { }
        public X509Certificate(string fileName, string password) { }
        public X509Certificate(string fileName, string password, System.Security.Cryptography.X509Certificates.X509KeyStorageFlags keyStorageFlags) { }
        public System.IntPtr Handle { get { throw null; } }
        public string Issuer { get { throw null; } }
        public string Subject { get { throw null; } }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public override bool Equals(object obj) { throw null; }
        public virtual bool Equals(System.Security.Cryptography.X509Certificates.X509Certificate other) { throw null; }
        public virtual byte[] Export(System.Security.Cryptography.X509Certificates.X509ContentType contentType) { throw null; }
        public virtual byte[] Export(System.Security.Cryptography.X509Certificates.X509ContentType contentType, string password) { throw null; }
        public virtual byte[] GetCertHash() { throw null; }
        public virtual string GetFormat() { throw null; }
        public override int GetHashCode() { throw null; }
        public virtual string GetKeyAlgorithm() { throw null; }
        public virtual byte[] GetKeyAlgorithmParameters() { throw null; }
        public virtual string GetKeyAlgorithmParametersString() { throw null; }
        public virtual byte[] GetPublicKey() { throw null; }
        public virtual byte[] GetSerialNumber() { throw null; }
        public override string ToString() { throw null; }
        public virtual string ToString(bool fVerbose) { throw null; }
    }
    public partial class X509Certificate2 : System.Security.Cryptography.X509Certificates.X509Certificate
    {
        public X509Certificate2() { }
        public X509Certificate2(byte[] rawData) { }
        public X509Certificate2(byte[] rawData, string password) { }
        public X509Certificate2(byte[] rawData, string password, System.Security.Cryptography.X509Certificates.X509KeyStorageFlags keyStorageFlags) { }
        public X509Certificate2(System.IntPtr handle) { }
        public X509Certificate2(string fileName) { }
        public X509Certificate2(string fileName, string password) { }
        public X509Certificate2(string fileName, string password, System.Security.Cryptography.X509Certificates.X509KeyStorageFlags keyStorageFlags) { }
        public bool Archived { get { throw null; } set { } }
        public System.Security.Cryptography.X509Certificates.X509ExtensionCollection Extensions { get { throw null; } }
        public string FriendlyName { get { throw null; } set { } }
        public bool HasPrivateKey { get { throw null; } }
        public System.Security.Cryptography.X509Certificates.X500DistinguishedName IssuerName { get { throw null; } }
        public System.DateTime NotAfter { get { throw null; } }
        public System.DateTime NotBefore { get { throw null; } }
        public System.Security.Cryptography.X509Certificates.PublicKey PublicKey { get { throw null; } }
        public byte[] RawData { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public System.Security.Cryptography.Oid SignatureAlgorithm { get { throw null; } }
        public System.Security.Cryptography.X509Certificates.X500DistinguishedName SubjectName { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        public int Version { get { throw null; } }
        public static System.Security.Cryptography.X509Certificates.X509ContentType GetCertContentType(byte[] rawData) { throw null; }
        public static System.Security.Cryptography.X509Certificates.X509ContentType GetCertContentType(string fileName) { throw null; }
        public string GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType nameType, bool forIssuer) { throw null; }
        public override string ToString() { throw null; }
        public override string ToString(bool verbose) { throw null; }
    }
    public partial class X509Certificate2Collection : System.Security.Cryptography.X509Certificates.X509CertificateCollection
    {
        public X509Certificate2Collection() { }
        public X509Certificate2Collection(System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) { }
        public X509Certificate2Collection(System.Security.Cryptography.X509Certificates.X509Certificate2Collection certificates) { }
        public X509Certificate2Collection(System.Security.Cryptography.X509Certificates.X509Certificate2[] certificates) { }
        public new System.Security.Cryptography.X509Certificates.X509Certificate2 this[int index] { get { throw null; } set { } }
        public int Add(System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) { throw null; }
        public void AddRange(System.Security.Cryptography.X509Certificates.X509Certificate2Collection certificates) { }
        public void AddRange(System.Security.Cryptography.X509Certificates.X509Certificate2[] certificates) { }
        public bool Contains(System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) { throw null; }
        public byte[] Export(System.Security.Cryptography.X509Certificates.X509ContentType contentType) { throw null; }
        public byte[] Export(System.Security.Cryptography.X509Certificates.X509ContentType contentType, string password) { throw null; }
        public System.Security.Cryptography.X509Certificates.X509Certificate2Collection Find(System.Security.Cryptography.X509Certificates.X509FindType findType, object findValue, bool validOnly) { throw null; }
        public new System.Security.Cryptography.X509Certificates.X509Certificate2Enumerator GetEnumerator() { throw null; }
        public void Import(byte[] rawData) { }
        public void Import(byte[] rawData, string password, System.Security.Cryptography.X509Certificates.X509KeyStorageFlags keyStorageFlags) { }
        public void Import(string fileName) { }
        public void Import(string fileName, string password, System.Security.Cryptography.X509Certificates.X509KeyStorageFlags keyStorageFlags) { }
        public void Insert(int index, System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) { }
        public void Remove(System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) { }
        public void RemoveRange(System.Security.Cryptography.X509Certificates.X509Certificate2Collection certificates) { }
        public void RemoveRange(System.Security.Cryptography.X509Certificates.X509Certificate2[] certificates) { }
    }
    public sealed partial class X509Certificate2Enumerator : System.Collections.IEnumerator
    {
        internal X509Certificate2Enumerator() { }
        public System.Security.Cryptography.X509Certificates.X509Certificate2 Current { get { throw null; } }
        object System.Collections.IEnumerator.Current { get { throw null; } }
        public bool MoveNext() { throw null; }
        public void Reset() { }
        bool System.Collections.IEnumerator.MoveNext() { throw null; }
        void System.Collections.IEnumerator.Reset() { }
    }
    public partial class X509CertificateCollection : System.Collections.ICollection, System.Collections.IEnumerable, System.Collections.IList
    {
        public X509CertificateCollection() { }
        public X509CertificateCollection(System.Security.Cryptography.X509Certificates.X509CertificateCollection value) { }
        public X509CertificateCollection(System.Security.Cryptography.X509Certificates.X509Certificate[] value) { }
        public int Count { get { throw null; } }
        public System.Security.Cryptography.X509Certificates.X509Certificate this[int index] { get { throw null; } set { } }
        bool System.Collections.ICollection.IsSynchronized { get { throw null; } }
        object System.Collections.ICollection.SyncRoot { get { throw null; } }
        bool System.Collections.IList.IsFixedSize { get { throw null; } }
        bool System.Collections.IList.IsReadOnly { get { throw null; } }
        object System.Collections.IList.this[int index] { get { throw null; } set { } }
        public int Add(System.Security.Cryptography.X509Certificates.X509Certificate value) { throw null; }
        public void AddRange(System.Security.Cryptography.X509Certificates.X509CertificateCollection value) { }
        public void AddRange(System.Security.Cryptography.X509Certificates.X509Certificate[] value) { }
        public void Clear() { }
        public bool Contains(System.Security.Cryptography.X509Certificates.X509Certificate value) { throw null; }
        public void CopyTo(System.Security.Cryptography.X509Certificates.X509Certificate[] array, int index) { }
        public System.Security.Cryptography.X509Certificates.X509CertificateCollection.X509CertificateEnumerator GetEnumerator() { throw null; }
        public override int GetHashCode() { throw null; }
        public int IndexOf(System.Security.Cryptography.X509Certificates.X509Certificate value) { throw null; }
        public void Insert(int index, System.Security.Cryptography.X509Certificates.X509Certificate value) { }
        public void Remove(System.Security.Cryptography.X509Certificates.X509Certificate value) { }
        public void RemoveAt(int index) { }
        void System.Collections.ICollection.CopyTo(System.Array array, int index) { }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        int System.Collections.IList.Add(object value) { throw null; }
        bool System.Collections.IList.Contains(object value) { throw null; }
        int System.Collections.IList.IndexOf(object value) { throw null; }
        void System.Collections.IList.Insert(int index, object value) { }
        void System.Collections.IList.Remove(object value) { }
        public partial class X509CertificateEnumerator : System.Collections.IEnumerator
        {
            public X509CertificateEnumerator(System.Security.Cryptography.X509Certificates.X509CertificateCollection mappings) { }
            public System.Security.Cryptography.X509Certificates.X509Certificate Current { get { throw null; } }
            object System.Collections.IEnumerator.Current { get { throw null; } }
            public bool MoveNext() { throw null; }
            public void Reset() { }
            bool System.Collections.IEnumerator.MoveNext() { throw null; }
            void System.Collections.IEnumerator.Reset() { }
        }
    }
    public partial class X509Chain : System.IDisposable
    {
        public X509Chain() { }
        public System.Security.Cryptography.X509Certificates.X509ChainElementCollection ChainElements { get { throw null; } }
        public System.Security.Cryptography.X509Certificates.X509ChainPolicy ChainPolicy { get { throw null; } set { } }
        public System.Security.Cryptography.X509Certificates.X509ChainStatus[] ChainStatus { get { throw null; } }
        public Microsoft.Win32.SafeHandles.SafeX509ChainHandle SafeHandle { get { throw null; } }
        public bool Build(System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) { throw null; }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
    }
    public partial class X509ChainElement
    {
        internal X509ChainElement() { }
        public System.Security.Cryptography.X509Certificates.X509Certificate2 Certificate { get { throw null; } }
        public System.Security.Cryptography.X509Certificates.X509ChainStatus[] ChainElementStatus { get { throw null; } }
        public string Information { get { throw null; } }
    }
    public sealed partial class X509ChainElementCollection : System.Collections.ICollection, System.Collections.IEnumerable
    {
        internal X509ChainElementCollection() { }
        public int Count { get { throw null; } }
        public System.Security.Cryptography.X509Certificates.X509ChainElement this[int index] { get { throw null; } }
        bool System.Collections.ICollection.IsSynchronized { get { throw null; } }
        object System.Collections.ICollection.SyncRoot { get { throw null; } }
        public void CopyTo(System.Security.Cryptography.X509Certificates.X509ChainElement[] array, int index) { }
        public System.Security.Cryptography.X509Certificates.X509ChainElementEnumerator GetEnumerator() { throw null; }
        void System.Collections.ICollection.CopyTo(System.Array array, int index) { }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public sealed partial class X509ChainElementEnumerator : System.Collections.IEnumerator
    {
        internal X509ChainElementEnumerator() { }
        public System.Security.Cryptography.X509Certificates.X509ChainElement Current { get { throw null; } }
        object System.Collections.IEnumerator.Current { get { throw null; } }
        public bool MoveNext() { throw null; }
        public void Reset() { }
    }
    public sealed partial class X509ChainPolicy
    {
        public X509ChainPolicy() { }
        public System.Security.Cryptography.OidCollection ApplicationPolicy { get { throw null; } }
        public System.Security.Cryptography.OidCollection CertificatePolicy { get { throw null; } }
        public System.Security.Cryptography.X509Certificates.X509Certificate2Collection ExtraStore { get { throw null; } }
        public System.Security.Cryptography.X509Certificates.X509RevocationFlag RevocationFlag { get { throw null; } set { } }
        public System.Security.Cryptography.X509Certificates.X509RevocationMode RevocationMode { get { throw null; } set { } }
        public System.TimeSpan UrlRetrievalTimeout { get { throw null; } set { } }
        public System.Security.Cryptography.X509Certificates.X509VerificationFlags VerificationFlags { get { throw null; } set { } }
        public System.DateTime VerificationTime { get { throw null; } set { } }
        public void Reset() { }
    }
    public partial struct X509ChainStatus
    {
        public System.Security.Cryptography.X509Certificates.X509ChainStatusFlags Status { get { throw null; } set { } }
        public string StatusInformation { get { throw null; } set { } }
    }
    [System.FlagsAttribute]
    public enum X509ChainStatusFlags
    {
        NoError = 0,
        NotTimeValid = 1,
        NotTimeNested = 2,
        Revoked = 4,
        NotSignatureValid = 8,
        NotValidForUsage = 16,
        UntrustedRoot = 32,
        RevocationStatusUnknown = 64,
        Cyclic = 128,
        InvalidExtension = 256,
        InvalidPolicyConstraints = 512,
        InvalidBasicConstraints = 1024,
        InvalidNameConstraints = 2048,
        HasNotSupportedNameConstraint = 4096,
        HasNotDefinedNameConstraint = 8192,
        HasNotPermittedNameConstraint = 16384,
        HasExcludedNameConstraint = 32768,
        PartialChain = 65536,
        CtlNotTimeValid = 131072,
        CtlNotSignatureValid = 262144,
        CtlNotValidForUsage = 524288,
        OfflineRevocation = 16777216,
        NoIssuanceChainPolicy = 33554432,
    }
    public enum X509ContentType
    {
        Unknown = 0,
        Cert = 1,
        SerializedCert = 2,
        Pfx = 3,
        Pkcs12 = 3,
        SerializedStore = 4,
        Pkcs7 = 5,
        Authenticode = 6,
    }
    public sealed partial class X509EnhancedKeyUsageExtension : System.Security.Cryptography.X509Certificates.X509Extension
    {
        public X509EnhancedKeyUsageExtension() { }
        public X509EnhancedKeyUsageExtension(System.Security.Cryptography.AsnEncodedData encodedEnhancedKeyUsages, bool critical) { }
        public X509EnhancedKeyUsageExtension(System.Security.Cryptography.OidCollection enhancedKeyUsages, bool critical) { }
        public System.Security.Cryptography.OidCollection EnhancedKeyUsages { get { throw null; } }
        public override void CopyFrom(System.Security.Cryptography.AsnEncodedData asnEncodedData) { }
    }
    public partial class X509Extension : System.Security.Cryptography.AsnEncodedData
    {
        protected X509Extension() { }
        public X509Extension(System.Security.Cryptography.AsnEncodedData encodedExtension, bool critical) { }
        public X509Extension(System.Security.Cryptography.Oid oid, byte[] rawData, bool critical) { }
        public X509Extension(string oid, byte[] rawData, bool critical) { }
        public bool Critical { get { throw null; } set { } }
        public override void CopyFrom(System.Security.Cryptography.AsnEncodedData asnEncodedData) { }
    }
    public sealed partial class X509ExtensionCollection : System.Collections.ICollection, System.Collections.IEnumerable
    {
        public X509ExtensionCollection() { }
        public int Count { get { throw null; } }
        public System.Security.Cryptography.X509Certificates.X509Extension this[int index] { get { throw null; } }
        public System.Security.Cryptography.X509Certificates.X509Extension this[string oid] { get { throw null; } }
        bool System.Collections.ICollection.IsSynchronized { get { throw null; } }
        object System.Collections.ICollection.SyncRoot { get { throw null; } }
        public int Add(System.Security.Cryptography.X509Certificates.X509Extension extension) { throw null; }
        public void CopyTo(System.Security.Cryptography.X509Certificates.X509Extension[] array, int index) { }
        public System.Security.Cryptography.X509Certificates.X509ExtensionEnumerator GetEnumerator() { throw null; }
        void System.Collections.ICollection.CopyTo(System.Array array, int index) { }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public sealed partial class X509ExtensionEnumerator : System.Collections.IEnumerator
    {
        internal X509ExtensionEnumerator() { }
        public System.Security.Cryptography.X509Certificates.X509Extension Current { get { throw null; } }
        object System.Collections.IEnumerator.Current { get { throw null; } }
        public bool MoveNext() { throw null; }
        public void Reset() { }
    }
    public enum X509FindType
    {
        FindByThumbprint = 0,
        FindBySubjectName = 1,
        FindBySubjectDistinguishedName = 2,
        FindByIssuerName = 3,
        FindByIssuerDistinguishedName = 4,
        FindBySerialNumber = 5,
        FindByTimeValid = 6,
        FindByTimeNotYetValid = 7,
        FindByTimeExpired = 8,
        FindByTemplateName = 9,
        FindByApplicationPolicy = 10,
        FindByCertificatePolicy = 11,
        FindByExtension = 12,
        FindByKeyUsage = 13,
        FindBySubjectKeyIdentifier = 14,
    }
    [System.FlagsAttribute]
    public enum X509KeyStorageFlags
    {
        DefaultKeySet = 0,
        UserKeySet = 1,
        MachineKeySet = 2,
        Exportable = 4,
        UserProtected = 8,
        PersistKeySet = 16,
    }
    public sealed partial class X509KeyUsageExtension : System.Security.Cryptography.X509Certificates.X509Extension
    {
        public X509KeyUsageExtension() { }
        public X509KeyUsageExtension(System.Security.Cryptography.AsnEncodedData encodedKeyUsage, bool critical) { }
        public X509KeyUsageExtension(System.Security.Cryptography.X509Certificates.X509KeyUsageFlags keyUsages, bool critical) { }
        public System.Security.Cryptography.X509Certificates.X509KeyUsageFlags KeyUsages { get { throw null; } }
        public override void CopyFrom(System.Security.Cryptography.AsnEncodedData asnEncodedData) { }
    }
    [System.FlagsAttribute]
    public enum X509KeyUsageFlags
    {
        None = 0,
        EncipherOnly = 1,
        CrlSign = 2,
        KeyCertSign = 4,
        KeyAgreement = 8,
        DataEncipherment = 16,
        KeyEncipherment = 32,
        NonRepudiation = 64,
        DigitalSignature = 128,
        DecipherOnly = 32768,
    }
    public enum X509NameType
    {
        SimpleName = 0,
        EmailName = 1,
        UpnName = 2,
        DnsName = 3,
        DnsFromAlternativeName = 4,
        UrlName = 5,
    }
    public enum X509RevocationFlag
    {
        EndCertificateOnly = 0,
        EntireChain = 1,
        ExcludeRoot = 2,
    }
    public enum X509RevocationMode
    {
        NoCheck = 0,
        Online = 1,
        Offline = 2,
    }
    public sealed partial class X509Store : System.IDisposable
    {
        public X509Store() { }
        public X509Store(System.Security.Cryptography.X509Certificates.StoreName storeName, System.Security.Cryptography.X509Certificates.StoreLocation storeLocation) { }
        public X509Store(string storeName, System.Security.Cryptography.X509Certificates.StoreLocation storeLocation) { }
        public System.Security.Cryptography.X509Certificates.X509Certificate2Collection Certificates { get { throw null; } }
        public System.Security.Cryptography.X509Certificates.StoreLocation Location { get { throw null; } }
        public string Name { get { throw null; } }
        public void Add(System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) { }
        public void Dispose() { }
        public void Open(System.Security.Cryptography.X509Certificates.OpenFlags flags) { }
        public void Remove(System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) { }
    }
    public sealed partial class X509SubjectKeyIdentifierExtension : System.Security.Cryptography.X509Certificates.X509Extension
    {
        public X509SubjectKeyIdentifierExtension() { }
        public X509SubjectKeyIdentifierExtension(byte[] subjectKeyIdentifier, bool critical) { }
        public X509SubjectKeyIdentifierExtension(System.Security.Cryptography.AsnEncodedData encodedSubjectKeyIdentifier, bool critical) { }
        public X509SubjectKeyIdentifierExtension(System.Security.Cryptography.X509Certificates.PublicKey key, bool critical) { }
        public X509SubjectKeyIdentifierExtension(System.Security.Cryptography.X509Certificates.PublicKey key, System.Security.Cryptography.X509Certificates.X509SubjectKeyIdentifierHashAlgorithm algorithm, bool critical) { }
        public X509SubjectKeyIdentifierExtension(string subjectKeyIdentifier, bool critical) { }
        public string SubjectKeyIdentifier { get { throw null; } }
        public override void CopyFrom(System.Security.Cryptography.AsnEncodedData asnEncodedData) { }
    }
    public enum X509SubjectKeyIdentifierHashAlgorithm
    {
        Sha1 = 0,
        ShortSha1 = 1,
        CapiSha1 = 2,
    }
    [System.FlagsAttribute]
    public enum X509VerificationFlags
    {
        NoFlag = 0,
        IgnoreNotTimeValid = 1,
        IgnoreCtlNotTimeValid = 2,
        IgnoreNotTimeNested = 4,
        IgnoreInvalidBasicConstraints = 8,
        AllowUnknownCertificateAuthority = 16,
        IgnoreWrongUsage = 32,
        IgnoreInvalidName = 64,
        IgnoreInvalidPolicy = 128,
        IgnoreEndRevocationUnknown = 256,
        IgnoreCtlSignerRevocationUnknown = 512,
        IgnoreCertificateAuthorityRevocationUnknown = 1024,
        IgnoreRootRevocationUnknown = 2048,
        AllFlags = 4095,
    }
}
