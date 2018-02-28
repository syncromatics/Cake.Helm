using System;
using Cake.Core.Annotations;
using Cake.Helm.Package;

namespace Cake.Helm
{
    partial class HelmAliases
    {
        [CakeMethodAlias]
        public static void HelmPackage(this Cake.Core.ICakeContext context, string path)
        {
            HelmPackage(context, null, path);
        }

        [CakeMethodAlias]
        public static void HelmPackage(this Cake.Core.ICakeContext context, HelmPackageSettings settings, string path)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var tool = new HelmTool<HelmPackageSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            tool.Run("package", settings ?? new HelmPackageSettings(), new string[]{ path });
        }
    }
}
