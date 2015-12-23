Param(
    [string]$RuleName
)

$tool = "SqlSkim"
$utility = "$PSScriptRoot\..\..\bld\bin\$tool.Driver\AnyCPU_Release\SqlSkim.exe"
$sourceExtension = "sql"

function Build-Tool()
{
    Write-Host "Building the tool..."  -NoNewline
    # Out-Null *and* /noconsolelogger here because our scripts call out to batch files and similar
    # that don't respect msbuild's /noconsolelogger switch.
    #msbuild $PSScriptRoot\..\$tool.Driver\$tool.Driver.csproj /p:"Platform=AnyCPU`;Configuration=Release" /m 
    Write-Host " done."
}

function Build-Baselines($rulename)
{
    Write-Host "Building baselines..."
    $expectedDirectory = Join-Path "$PSScriptRoot\RulesTestData" $ruleName
	$expectedDirectory = Join-Path $expectedDirectory "Expected"
    $testsDirectory = "$PSScriptRoot\RulesTestData\" 
    $sourceExtension = "*.$sourceExtension"
    Get-ChildItem $testsDirectory -Filter $sourceExtension | ForEach-Object {
        Write-Host "    $_ -> $_.sarif"
        $input = $_.FullName
		$outputFile = $_.Name
        $output = Join-Path $expectedDirectory "$outputFile.sarif"
        $outputTemp = "$output.temp"

        # Actually run the tool
        Remove-Item $outputTemp -ErrorAction SilentlyContinue
        &$utility analyze "$input" --output "$outputTemp" --verbose --config default

        Move-Item $outputTemp $output -Force
    }
}

$allTools = (Get-ChildItem "$PSScriptRootRulesTestData" -Directory | ForEach-Object { $_.Name })

Build-Tool

Build-Baselines $_

Write-Host "Finished! Terminate."
