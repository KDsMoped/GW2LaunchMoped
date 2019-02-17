set GW2Dir=%ProgramFiles%\Guild Wars 2
set GW2BinDir=%ProgramFiles%\Guild Wars 2\bin64
set wgetPath=%ProgramFiles(X86)%\GnuWin32\bin\wget
set ArcDpsWebsite=https://www.deltaconnected.com/arcdps/x64

"%wgetPath%" -N --no-check-certificate "%ArcDpsWebsite%/d3d9.dll" -P "%GW2BinDir%"
"%wgetPath%" -N --no-check-certificate "%ArcDpsWebsite%/buildtemplates/d3d9_arcdps_buildtemplates.dll" -P "%GW2BinDir%"
"%wgetPath%" -N --no-check-certificate "%ArcDpsWebsite%/arcdps.ini" -P "%GW2BinDir%"

::start "" "%GW2Dir%\gw2-64.exe" -mapLoadinfo