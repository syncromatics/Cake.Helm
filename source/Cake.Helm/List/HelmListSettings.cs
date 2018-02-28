using Cake.Core.Tooling;

namespace Cake.Helm.List
{
    /// <summary>
    /// Settings for helm list [flags] [FILTER].
    /// </summary>
    public sealed class HelmListSettings : GlobalHelmSettings
    {
        /// <summary>
        /// Show all releases, not just the ones marked DEPLOYED
        /// </summary>
        public bool? All { get; set; }

        /// <summary>
        /// Specifies the max column width of output (default 60)
        /// </summary>
        public uint? ColWidth { get; set; }

        /// <summary>
        /// Sort by release date
        /// </summary>
        public bool? Date { get; set; }

        /// <summary>
        /// Show deleted releases
        /// </summary>
        public bool? Deleted { get; set; }

        /// <summary>
        /// Show releases that are currently being deleted
        /// </summary>
        public bool? Deleting { get; set; }

        /// <summary>
        /// Show deployed releases. If no other is specified, this will be automatically enabled
        /// </summary>
        public bool? Deployed { get; set; }

        /// <summary>
        /// Show failed releases
        /// </summary>
        public bool? Failed { get; set; }

        /// <summary>
        /// Maximum number of releases to fetch (default 256)
        /// </summary>
        public int? Max { get; set; }

        /// <summary>
        /// Show releases within a specific namespace
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Next release name in the list, used to offset from start value
        /// </summary>
        public string Offset { get; set; }

        /// <summary>
        /// Show pending releases
        /// </summary>
        public bool? Pending { get; set; }

        /// <summary>
        /// Reverse the sort order
        /// </summary>
        public bool? Reverse { get; set; }

        /// <summary>
        /// Output short (quiet) listing format
        /// </summary>
        public bool? Short { get; set; }

        /// <summary>
        /// Enable TLS for request
        /// </summary>
        public bool? Tls { get; set; }

        /// <summary>
        /// Path to TLS CA certificate file (default "$HELM_HOME/ca.pem")
        /// </summary>
        public string TlsCaCert { get; set; }

        /// <summary>
        /// Path to TLS certificate file (default "$HELM_HOME/cert.pem")
        /// </summary>
        public string TlsCert { get; set; }

        /// <summary>
        /// Path to TLS key file (default "$HELM_HOME/key.pem")
        /// </summary>
        public string TlsKey { get; set; }

        /// <summary>
        /// Enable TLS for request and verify remote
        /// </summary>
        public bool? TlsVerify { get; set; }
    }
}
