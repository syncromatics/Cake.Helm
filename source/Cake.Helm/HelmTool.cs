using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Helm.Extensions;

namespace Cake.Helm
{
    public class HelmTool<TSettings> : Tool<TSettings>
        where TSettings : GlobalHelmSettings
    {
        private readonly ICakeEnvironment _environment;
        private readonly IFileSystem _fileSystem;

        public HelmTool(IFileSystem fileSystem,
            ICakeEnvironment environment, 
            IProcessRunner processRunner, 
            IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
            _fileSystem = fileSystem;
            _environment = environment;
        }

        public void Run(string command, TSettings settings, string[] additional)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException(nameof(command));
            }
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }
            if (additional == null)
            {
                throw new ArgumentNullException(nameof(additional));
            }
            Run(settings, GetArguments(command, settings, additional));
        }

        private ProcessArgumentBuilder GetArguments(string command, TSettings settings, string[] containers)
        {
            var builder = new ProcessArgumentBuilder();
            builder.AppendAll(command, settings, containers);
            return builder;
        }

        protected override string GetToolName()
        {
            return "Helm";
        }

        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "helm.exe", "helm" };
        }

        protected override IEnumerable<FilePath> GetAlternativeToolPaths(TSettings settings)
        {
            var path = HelmResolver.GetHelmPath(_fileSystem, _environment);
            return path != null
                ? new[] { path }
                : Enumerable.Empty<FilePath>();
        }
    }
}
