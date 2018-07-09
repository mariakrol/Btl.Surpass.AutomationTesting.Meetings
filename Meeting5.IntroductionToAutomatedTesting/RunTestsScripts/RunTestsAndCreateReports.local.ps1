Param(
	[string] $testProject,
	[string] $buildMode,
	[string] $includedCategories
);

If(([string]::IsNullOrEmpty($buildMode))) {
	$buildMode = "Release";
}

If(([string]::IsNullOrEmpty($testProject))) {
	$testProject = "Meeting1.LearnBasicDataTypesAndConstructions";
}

$pathToRootDirectory = (Get-Item -Path "..\..").FullName;

$pathToPackages = $pathToRootDirectory + "\packages\";

$pathToTestsLibrary = $pathToRootDirectory + "\" + $testProject + "\bin\" + $buildMode + "\" + $testProject + ".dll";

$pathToOutputDirectory = $pathToRootDirectory + "\TestResults\";

$resultName = $testProject + "RegressionResult";

If(([string]::IsNullOrEmpty($includedCategories))) {
	Write-Host "In if";
	.\RunTestsAndCreateReports.ps1 -pathToPackages $pathToPackages -pathToTestsLibrary $pathToTestsLibrary -pathToOutputDirectory $pathToOutputDirectory -resultName $resultName
}
Else {
	.\RunTestsAndCreateReports.ps1 -pathToPackages $pathToPackages -pathToTestsLibrary $pathToTestsLibrary -pathToOutputDirectory $pathToOutputDirectory -resultName $resultName -includedCategories $includedCategories
}
