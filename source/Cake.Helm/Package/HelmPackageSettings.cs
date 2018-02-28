namespace Cake.Helm.Package
{
    public sealed class HelmPackageSettings : GlobalHelmSettings
    {
        /// <summary>
        /// Set the appVersion on the chart to this version                                               
        /// </summary>
        public string AppVersion { get; set; }

        /// <summary>
        /// Update dependencies from "requirements.yaml" to dir "charts/" before packaging
        /// </summary>
        public bool? DependencyUpdate { get; set; }

        /// <summary>
        /// Location to write the chart. (default ".")                                                    
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Name of the key to use when signing. Used if --sign is true                                   
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Location of a public keyring (default "~/.gnupg/pubring.gpg")                   
        /// </summary>
        public string Keyring { get; set; }

        /// <summary>
        /// Save packaged chart to local chart repository (default true)                                  
        /// </summary>
        public bool? Save { get; set; }

        /// <summary>
        /// Use a PGP private key to sign this package                                                    
        /// </summary>
        public bool? Sign { get; set; }

        /// <summary>
        /// Set the version on the chart to this semver version                                           
        /// </summary>
        public string Version { get; set; }
    }
}
