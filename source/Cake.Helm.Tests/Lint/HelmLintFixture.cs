using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Helm.Lint;
using Cake.Testing.Fixtures;

namespace Cake.Helm.Tests.Lint
{
    public class HelmLintFixture : ToolFixture<HelmLintSettings>, ICakeContext
    {
        public string Path { get; set; }

        IFileSystem ICakeContext.FileSystem => FileSystem;

        ICakeEnvironment ICakeContext.Environment => Environment;

        public ICakeLog Log => Log;

        ICakeArguments ICakeContext.Arguments => throw new NotImplementedException();

        IProcessRunner ICakeContext.ProcessRunner => ProcessRunner;

        public IRegistry Registry => Registry;

        public HelmLintFixture() : base("helm")
        {
            ProcessRunner.Process.SetStandardOutput(new string[] { });
        }

        protected override void RunTool()
        {
            this.HelmLint(Settings, Path);
        }
    }
}