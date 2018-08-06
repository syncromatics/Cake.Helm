using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Cake.Core.Annotations;
using Cake.Helm.ChartMuseum;

namespace Cake.Helm
{
    partial class HelmAliases
    {
        [CakeMethodAlias]
        public static void HelmChartMuseumUpload(this Cake.Core.ICakeContext context, HelmChartMuseumUploadSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var requestUri = new Uri(new Uri(settings.MuseumUrl), "api/charts");
            var file = new FileInfo(settings.Path);
            using (var client = new HttpClient())
            using (var stream = file.OpenRead())
            {
                if (!string.IsNullOrEmpty(settings.Username))
                {
                    var byteArray = Encoding.ASCII.GetBytes($"{settings.Username}:{settings.Password}");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                }
                var response = client.PostAsync(requestUri, new StreamContent(stream)).Result;
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
