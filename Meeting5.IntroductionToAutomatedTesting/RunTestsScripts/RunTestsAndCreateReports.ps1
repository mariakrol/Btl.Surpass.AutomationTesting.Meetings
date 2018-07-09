Param(
	[string] $pathToPackages,
	[string] $pathToTestsLibrary,
	[string] $pathToOutputDirectory,
	[string] $resultName,
	[string] $includedCategories
);

function FindFile($fileName) {
	get-childitem $pathToPackages -Filter $fileName -Recurse | % {
		if(!$dateCreated -or ($_.CreationTimeUtc -gt [DateTime]"$dateCreated")) {
			$filePath = $_.FullName;
			$dateCreated = $_.CreationTimeUtc;
		}
	}

	return $filePath;
}

#find paths to libraries
$nunitConsole = FindFile nunit3-console.exe;
$nunitEngine = FindFile nunit.engine.api.dll;
$nunitWriter = FindFile nunit-v2-result-writer.dll;

#create paths to reports

$nunitTextOut = (-join($pathToOutputDirectory, $resultName, ".txt"));
$nuni3XmlOut = (-join($pathToOutputDirectory, $resultName, "-NUnitV3.xml"));
$nuni2XmlOut = (-join($pathToOutputDirectory, $resultName, "-NUnitV2.xml"));

#create folder for reports if not exists
If(!(test-path $pathToOutputDirectory))
{
	New-Item -ItemType Directory -Force -Path $pathToOutputDirectory;
}

#run tests and create report for 3 version of NUnit
If(!([string]::IsNullOrEmpty($includedCategories)) -and (!($includedCategories -eq "All"))) {

	$categoriesForRun = @();
	ForEach ($category in $includedCategories.split(" ", [System.StringSplitOptions]::RemoveEmptyEntries)) 
	{
		$categoriesForRun += "cat == " + $category;
	}

	$categoriesRunOption = '--where "' + ($categoriesForRun -join ' || ') + '"';
}

$nunitRunOptions = (-join("--labels=All --out=", $nunitTextOut, " --result=", $nuni3XmlOut, " ", $categoriesRunOption));
$nunitCommand = (-join($nunitConsole, " ", $pathToTestsLibrary, " ", $nunitRunOptions));

Invoke-Expression $nunitCommand;

#convert report for 3 version of NUnit to 2 version

Add-Type -Path $nunitEngine;
Add-Type -Path $nunitWriter;

$xmlDoc = New-Object -TypeName System.Xml.XmlDataDocument;
$fileStream = New-Object -TypeName System.IO.FileStream -ArgumentList $nuni3XmlOut, "Open", "Read";
$xmlDoc.Load($fileStream);
$xmlNode = $xmldoc.GetElementsByTagName('test-run').Item(0);
$writer = New-Object -TypeName NUnit.Engine.Addins.NUnit2XmlResultWriter;
$writer.WriteResultFile($xmlNode, $nuni2XmlOut);
$fileStream.Close();
