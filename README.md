# ASP.NET-Core-201703
Az ASP.NET Core NetAcademia tanfolyam kódtár kiegészítése

## Linux subsystem for windows

- Minimum windows version [itt](https://msdn.microsoft.com/en-us/commandline/wsl/install_guide)
- Windows Developer Mode
- install linux subsystem 
- run Bash
- set default language to en-us [itt](http://superuser.com/a/1108092/391048)
- upgrade git [innen](http://unix.stackexchange.com/a/170831)
- sudo: unable to resolve host WINDOWS10 hiba [megoldása](http://askubuntu.com/a/59517/557836)
- [fish shell](http://fishshell.com/) ([github](https://github.com/oh-my-fish/oh-my-fish)) telepítése [így](https://www.hanselman.com/blog/InstallingFishShellOnUbuntuOnWindows10.aspx)
- ubuntu mono font telepítése [innen](http://font.ubuntu.com/)
- generating ssh key [innen](https://help.github.com/articles/generating-a-new-ssh-key-and-adding-it-to-the-ssh-agent/#platform-linux)
- az ssh kulcs felvitele a github oldalon
- ehhez az ssh kulcs: **cat ~/.ssh/id_rsa.pub**
- .NET Core telepítés [innen](https://www.microsoft.com/net/core#linuxubuntu), UBUNTU 14.04-re (verziószám: [**lsb_release -a**](https://help.ubuntu.com/community/CheckingYourUbuntuVersion))
- **cd ASP.NET-Core-201703\ASPNETCore\src\ASPNETCore**
- **dotnet restore**
- **dotnet run**
- The specified framework 'Microsoft.NETCore.App', version '1.0.0' was not found. ([Hanselmann](https://www.hanselman.com/blog/TheMysteryOfDotnetWatchAndMicrosoftNETCoreAppVersion110preview100110000WasNotFound.aspx))
- átírtam a verziószámot 1.1-re, majd újrafuttattam: Error -98 EADDRINUSE address already in use
- konfiguráltam, hogy milyen portokon figyeljen, majd **sudo**-val elindítottam ([Oleg](http://stackoverflow.com/questions/34212765/how-do-i-get-the-kestrel-web-server-to-listen-to-non-localhost-requests)):
```
[~/A/A/s/ASPNETCore.WU]─[⎇ master]─(130)-> sudo dotnet run
Project ASPNETCore.WU (.NETCoreApp,Version=v1.0) was previously compiled. Skipping compilation.
Hosting environment: Production
Content root path: /home/gplesz/ASP.NET-Core-201703/ASPNETCore.WU/src/ASPNETCore.WU
Now listening on: http://*:1000
Now listening on: https://*:1234
Now listening on: http://0.0.0.0:5000
Application started. Press Ctrl+C to shut down.
```


