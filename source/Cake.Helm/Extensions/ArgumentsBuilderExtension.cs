using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Helm.Extensions
{
    public static class ArgumentsBuilderExtension
    {
        public static void AppendAll<TSettings>(this ProcessArgumentBuilder builder, string command, TSettings settings, string[] arguments)
            where TSettings : ToolSettings//, new()
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }
            if (arguments == null)
            {
                throw new ArgumentNullException("arguments");
            }
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException("command");
            }
            if (settings == null)
            {
                //settings = new TSettings();
            }
            //AppendArguments(builder, settings, preCommand: true);
            builder.Append(command);
            //AppendArguments(builder, settings, preCommand: false);
            if (arguments != null)
            {
                foreach (string argument in arguments)
                {
                    builder.Append(argument);
                }
            }
        }
    }
}
