namespace Cake.Helm.Lint
{
    public sealed class HelmLintSettings : GlobalHelmSettings
    {
        /// <summary>
        /// Namespace to install the release into (only used if --install is set) (default "default")                 
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2) 
        /// </summary>
        public string[] Set { get; set; }

        /// <summary>
        /// Fail on lint warnings                                                                                     
        /// </summary>
        public bool? Strict { get; set; }

        /// <summary>
        /// Specify values in a YAML file (can specify multiple) (default [])                                         
        /// </summary>
        public string[] Values { get; set; }
    }
}
