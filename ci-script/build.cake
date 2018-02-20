#addin "Cake.FileHelpers"

var Project = Directory("../source/Cake.Helm/");
var TestProject = Directory("../source/Cake.Helm.Tests/");
var CakeHelmProj = Project + File("Cake.Helm.csproj");
var CakeTestHelmProj = TestProject + File("Cake.Helm.Test.csproj");
var CakeTestHelmAssembly = TestProject + Directory("bin/Release") + File("Cake.Helm.Tests.dll");
var AssemblyInfo = Project + File("Properties/AssemblyInfo.cs");
var CakeHelmSln = File("../source/Cake.Helm.sln");
var CakeHelmNuspec = File("../source/Cake.Helm.nuspec");
var Nupkg = Directory("../source/nupkg");

var target = Argument("target", "Default");

Task("Default")
	.Does (() =>
	{
		NuGetRestore (CakeHelmSln);
		DotNetCoreBuild (CakeHelmSln, new DotNetCoreBuildSettings {
			Configuration = "Release"
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
	DotNetCorePack (CakeHelmProj, new DotNetCorePackSettings
     {
         Configuration = "Release",
         OutputDirectory = Nupkg
     });
});

RunTarget (target);
