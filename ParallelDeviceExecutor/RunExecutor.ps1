param([String] $assemblies = "", [String] $baselocation="C:\a\1\s\")

$filePath = $baselocation + 'ParallelDeviceExecutor\bin\Release\ParallelDeviceExecutor.exe'
$workingDirectory = $baselocation + 'ParallelDeviceExecutor\bin\Release'
$arguments = "a:$assemblies" 
echo "aguments in ps are: " + $arguments
Start-Process -FilePath $filePath -Args $arguments -NoNewWindow -PassThru -Wait -WorkingDirectory $workingDirectory
