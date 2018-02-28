using System;
using Cake.Core.Annotations;
using Cake.Helm.Lint;

namespace Cake.Helm
{
    partial class HelmAliases
    {
        [CakeMethodAlias]
        public static void HelmLint(this Cake.Core.ICakeContext context, string path)
        {
            HelmLint(context, null, path);
        }

        [CakeMethodAlias]
        public static void HelmLint(this Cake.Core.ICakeContext context, HelmLintSettings settings, string path)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var tool = new HelmTool<HelmLintSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            tool.Run("lint", settings ?? new HelmLintSettings(), new string[]{ path });
        }
    }
}
