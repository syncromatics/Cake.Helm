namespace Cake.Helm.ChartMuseum
{
    /// <summary>
    /// Settings for uploading charts to a chart museum
    /// </summary>
    public sealed class HelmChartMuseumUploadSettings : GlobalHelmSettings
    {
        /// <summary>
        /// Root URL of the ChartMuseum Helm chart repository
        /// </summary>
        public string MuseumUrl { get; set; }

        /// <summary>
        /// Path to packaged chart to upload to ChartMuseum
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Optional username to authenticate the request to the ChartMuseum (using HTTP basic authentication)
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Optional password to authenticate the request to the ChartMuseum (using HTTP basic authentication)
        /// </summary>
        public string Password { get; set; }
    }
}
