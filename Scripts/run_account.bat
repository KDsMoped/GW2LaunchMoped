set arg1=%1
set ze_base_dat="%APPDATA%\Guild Wars 2\Local.base.dat"
set ze_account_dat="%APPDATA%\Guild Wars 2\Local.%arg1%.dat"
set ze_link="%APPDATA%\Guild Wars 2\Local.dat"
set gw2_path="C:\Program Files\Guild Wars 2"

:: create the account-specific dat if needed
if not exist %ze_account_dat% (
	copy /y %ze_base_dat% %ze_account_dat%
)

:: create the link
if exist %ze_link% (
	del %ze_link%
)
mklink /H %ze_link% %ze_account_dat%
:: if we have a problem with the link, exit. We don't want to start the game without Local.dat (or it would create one as well as gfxsettings and ruin your settings)
if %errorlevel% neq 0 exit /b %errorlevel%

start "" %gw2_path%\Gw2-64.exe -autologin
