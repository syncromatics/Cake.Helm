#addin "Cake.FileHelpers"

var Project = Directory("../source/Cake.Helm/");
var TestProject = Directory("../source/Cake.Helm.Tests/");
var CakeHelmProj = Project + File("Cake.Helm.csproj");
var CakeTestHelmProj = TestProject + File("Cake.Helm.Test.csproj");
var CakeTestHelmAssembly = TestProject + Directory("bin/Release") + File("Cake.Helm.Tests.dll");
var AssemblyInfo = Project + File("Properties/AssemblyInfo.cs");
var CakeHelmSln = File("../source/Cake.Helm.sln");
var Nupkg = Directory("../source/nupkg");

var target = Argument("target", "Default");
var version = EnvironmentVariable("TRAVIS_TAG") ?? "0.0.0";

Task("Default")
	.Does (() =>
	{
		DotNetCoreRestore(CakeHelmSln);
		DotNetCoreBuild(CakeHelmSln, new DotNetCoreBuildSettings
		{
			Configuration = "Release",
			ArgumentCustomization = args => args.Append($"/property:Version={version}"),
			NoRestore = true,
		});
	});

Task("UnitTest")
	.IsDependentOn("Default")
	.Does(() =>
	{
		NUnit3(CakeTestHelmAssembly);
	});

Task("NuGetPack")
	.IsDependentOn("Default")
	.IsDependentOn("UnitTest")
	.Does (() =>
	{
		CreateDirectory(Nupkg);
		DotNetCorePack(CakeHelmProj, new DotNetCorePackSettings
		{
			Configuration = "Release",
			OutputDirectory = Nupkg,
			ArgumentCustomization = args => args.Append($"/property:Version={version}"),
			NoBuild = true,
			NoRestore = true,
		});
	});

RunTarget (target);
