using Cake.Core.Tooling;

namespace Cake.Helm
{
    public abstract class GlobalHelmSettings : ToolSettings
    {
        /// <summary>
        /// Enable verbose output                                                                     
        /// </summary>
        public bool? Debug {get;set;}

        /// <summary>
        /// Location of your Helm config. Overrides $HELM_HOME (default "~\.helm")      
        /// </summary>
        public string Home {get;set;}

        /// <summary>
        /// Address of Tiller. Overrides $HELM_HOST                                                   
        /// </summary>}
        public string Host {get;set;}

        /// <summary>
        /// Name of the kubeconfig context to use                                                     
        /// </summary>
        public string KubeContext {get;set;}

        /// <summary>
        /// Namespace of Tiller (default "kube-system")                                               
        /// </summary>
        public string TillerNamespace {get;set;}
    }
}
