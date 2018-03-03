#addin "Cake.FileHelpers"

var Project = Directory("../source/Cake.Helm/");
var TestProject = Directory("../source/Cake.Helm.Tests/");
var CakeHelmProj = Project + File("Cake.Helm.csproj");
var CakeTestHelmAssembly = TestProject + Directory("bin/Release") + File("Cake.Helm.Tests.dll");
var CakeHelmSln = File("../source/Cake.Helm.sln");
var Nupkg = Directory("../source/nupkg");

var target = Argument("target", "Default");
var tag = EnvironmentVariable("APPVEYOR_REPO_TAG_NAME");
var version = !string.IsNullOrEmpty(tag) ? tag : "0.0.0";

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

Task("NuGetPush")
	.IsDependentOn("NuGetPack")
	.Does(() => 
	{
		if (EnvironmentVariable("APPVEYOR_REPO_TAG") != "true") return;

        var settings = new DotNetCoreNuGetPushSettings
        {
            Source = "https://www.nuget.org/api/v2/package,
            ApiKey = EnvironmentVariable("NUGET_API_KEY"),
        };

        DotNetCoreNuGetPush(Nupkg + File($"./Syncromatics.Cake.Helm.{version}.nupkg"), settings);
	});

RunTarget (target);
