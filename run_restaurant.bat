@echo off
setlocal enabledelayedexpansion
cd /d "%~dp0"

echo ========================================================
echo   Spice Garden - Restaurant Management Suite
echo   Build ^& One-Click Launcher
echo ========================================================
echo.

set MSBUILD_PATH=

:: 1. Check Visual Studio 2022 paths
if exist "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" (
    set "MSBUILD_PATH=C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe"
) else if exist "C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe" (
    set "MSBUILD_PATH=C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe"
) else if exist "C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe" (
    set "MSBUILD_PATH=C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe"
)

:: 2. Check Visual Studio 2019 paths
if "%MSBUILD_PATH%"=="" (
    if exist "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe" (
        set "MSBUILD_PATH=C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe"
    ) else if exist "C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe" (
        set "MSBUILD_PATH=C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe"
    ) else if exist "C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\MSBuild.exe" (
        set "MSBUILD_PATH=C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\MSBuild.exe"
    )
)

:: 3. Check default .NET Framework MSBuild (Windows 7/8/10/11 native)
if "%MSBUILD_PATH%"=="" (
    if exist "C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe" (
        set "MSBUILD_PATH=C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"
    )
)

if "%MSBUILD_PATH%"=="" (
    echo [ERROR] MSBuild was not found on this system.
    echo Please make sure .NET Framework 4.0/4.8 or Visual Studio is installed.
    echo.
    pause
    exit /b 1
)

echo [Found MSBuild] %MSBUILD_PATH%
echo.
echo [1/2] Compiling RestaurantManagement...
"%MSBUILD_PATH%" "RestaurantManagement\RestaurantManagement.vbproj" /p:Configuration=Debug /p:Platform=x86 /v:m

if %ERRORLEVEL% NEQ 0 (
    echo.
    echo [Retry] Attempting compilation with default platform...
    "%MSBUILD_PATH%" "RestaurantManagement\RestaurantManagement.vbproj" /p:Configuration=Debug /v:m
    if !ERRORLEVEL! NEQ 0 (
        echo.
        echo [ERROR] Build failed! Check compiler output above.
        pause
        exit /b !ERRORLEVEL!
    )
)

echo.
echo [2/2] Launching RestaurantManagement.exe...
if exist "RestaurantManagement\bin\Debug\RestaurantManagement.exe" (
    cd /d "%~dp0RestaurantManagement\bin\Debug"
    start "" "RestaurantManagement.exe"
) else if exist "RestaurantManagement\bin\x86\Debug\RestaurantManagement.exe" (
    cd /d "%~dp0RestaurantManagement\bin\x86\Debug"
    start "" "RestaurantManagement.exe"
) else if exist "bin\Debug\RestaurantManagement.exe" (
    cd /d "%~dp0bin\Debug"
    start "" "RestaurantManagement.exe"
) else (
    echo [WARNING] Could not find RestaurantManagement.exe in bin\Debug.
    pause
    exit /b 1
)

echo Done! Application launched successfully.
