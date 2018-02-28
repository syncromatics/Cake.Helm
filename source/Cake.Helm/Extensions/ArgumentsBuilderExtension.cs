using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Helm.Extensions
{
    public static class ArgumentsBuilderExtension
    {
        public static void AppendAll<TSettings>(this ProcessArgumentBuilder builder, string command, TSettings settings, string[] arguments)
            where TSettings : GlobalHelmSettings
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
            AppendArguments(builder, settings, preCommand: true);
            builder.Append(command);
            AppendArguments(builder, settings, preCommand: false);
            if (arguments != null)
            {
                foreach (string argument in arguments)
                {
                    builder.Append(argument);
                }
            }
        }

        private static void AppendArguments<TSettings>(ProcessArgumentBuilder builder, TSettings settings, bool preCommand)
            where TSettings : GlobalHelmSettings
        {
            var type = preCommand ? typeof(GlobalHelmSettings) : typeof(TSettings);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var property in properties)
            {
                GetArguments(builder, property, settings);
            }
        }

        private static void GetArguments(ProcessArgumentBuilder builder, PropertyInfo propertyInfo, object settings)
        {
            var snakecaseFlag = $"--{Regex.Replace(propertyInfo.Name, @"([a-z])([A-Z])", "$1-$2").ToLower()}";
            var value = propertyInfo.GetValue(settings);
            if (value == null) return;
            switch (value)
            {
                case string[] stringArrayValue:
                    foreach (var stringValue in stringArrayValue)
                    {
                        builder.Append(snakecaseFlag);
                        builder.AppendQuoted(stringValue);
                    }
                    break;
                case bool boolValue:
                    if (boolValue) builder.Append(snakecaseFlag);
                    break;
                default:
                    builder.Append(snakecaseFlag);
                    builder.AppendQuoted(value.ToString());
                    break;
            }
        }
    }
}
