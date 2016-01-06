@echo off
nuget pack Termine.csproj
set var=Termine.1.*.nupkg
nuget push %var%
del %var%

pause