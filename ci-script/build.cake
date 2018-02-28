#addin "Cake.FileHelpers"

var Project = Directory("../source/Cake.Helm/");
var TestProject = Directory("../source/Cake.Helm.Tests/");
var CakeHelmProj = Project + File("Cake.Helm.csproj");
var CakeTestHelmAssembly = TestProject + Directory("bin/Release") + File("Cake.Helm.Tests.dll");
var CakeHelmSln = File("../source/Cake.Helm.sln");
var Nupkg = Directory("../source/nupkg");

var target = Argument("target", "Default");
var travisTag = EnvironmentVariable("TRAVIS_TAG");
var version = !string.IsNullOrEmpty(travisTag) ? travisTag : "0.0.0";

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
