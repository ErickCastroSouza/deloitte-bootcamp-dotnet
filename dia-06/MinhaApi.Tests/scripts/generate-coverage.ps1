param(
    [string]$TestProjectDir = (Get-Location).Path,
    [string]$ReportDir = "$PWD\CoverageReport"
)

# Find the most recent cobertura coverage file under TestResults
$cov = Get-ChildItem -Path (Join-Path $TestProjectDir 'TestResults') -Filter "*coverage.cobertura.xml" -Recurse -ErrorAction SilentlyContinue |
    Sort-Object LastWriteTime -Descending | Select-Object -First 1

if (-not $cov) {
    Write-Error "No coverage.cobertura.xml found under TestResults"
    exit 1
}

[xml]$xml = Get-Content $cov.FullName

# Remove any <class> elements whose filename points into an obj\ path (generated files)
$classes = $xml.SelectNodes('//class')
foreach ($c in $classes) {
    if ($c.filename -and $c.filename -like 'obj\\*') {
        $parent = $c.ParentNode
        $null = $parent.RemoveChild($c)
    }
}

$filtered = Join-Path $TestProjectDir 'coverage.filtered.cobertura.xml'
$xml.Save($filtered)

Write-Host "Filtered coverage saved to: $filtered"

if (-not (Test-Path $ReportDir)) { New-Item -ItemType Directory -Path $ReportDir | Out-Null }

Write-Host "Generating HTML report to $ReportDir"
reportgenerator -reports:$filtered -targetdir:$ReportDir -reporttypes:Html

if ($LASTEXITCODE -ne 0) { Write-Error "reportgenerator failed with code $LASTEXITCODE"; exit $LASTEXITCODE }

Write-Host "Report generated at $ReportDir\index.html"
