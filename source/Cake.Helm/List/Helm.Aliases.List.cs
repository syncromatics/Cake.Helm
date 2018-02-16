using System;
using Cake.Core.Annotations;
using Cake.Helm.List;

namespace Cake.Helm
{
    partial class HelmAliases
    {
        [CakeMethodAlias]
        public static void HelmList(this Cake.Core.ICakeContext context, HelmListSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var tool = new HelmTool<HelmListSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            tool.Run("list", settings ?? new HelmListSettings(), new string[]{});
        }
    }
}
