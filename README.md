# ASP.NET-Core-201703
Az ASP.NET Core NetAcademia tanfolyam kódtár kiegészítése

## Linux subsystem for windows

- Minimum windows version [itt](https://msdn.microsoft.com/en-us/commandline/wsl/install_guide)

  Your PC must be running a **64-bit** version of **Windows 10 Anniversary Update build 14393** or later
  
- Windows Developer Mode
- install linux subsystem 
- ugyanez parancssorból [itt](http://superuser.com/a/1065579/391048)
  
  **lxrun /uninstall /full**

  **lxrun /install**

- run Bash
- set default language to en-us [itt](http://superuser.com/a/1108092/391048)
  
  **sudo update-locale LANG=en_US.UTF8**

- upgrade git [innen](http://unix.stackexchange.com/a/170831)
 - **git --version**
 - **sudo add-apt-repository ppa:git-core/ppa -y**
 - **sudo apt-get update**
 - **sudo apt-get install git -y**
 - **git --version**

- sudo: unable to resolve host WINDOWS10 hiba [megoldása](http://askubuntu.com/a/59517/557836)
 - That the **/etc/hostname** file contains just the name of the machine.
 - That **/etc/hosts** has an entry for localhost. It should have something like:
  - **127.0.0.1    localhost.localdomain localhost**
  - **127.0.1.1    WINDOWS10**

- [fish shell](http://fishshell.com/) ([github](https://github.com/oh-my-fish/oh-my-fish)) telepítése [így](https://www.hanselman.com/blog/InstallingFishShellOnUbuntuOnWindows10.aspx)
- ubuntu mono font telepítése [innen](http://font.ubuntu.com/)
- generating ssh key [innen](https://help.github.com/articles/generating-a-new-ssh-key-and-adding-it-to-the-ssh-agent/#platform-linux)
- az ssh kulcs felvitele a github oldalon [így](https://help.github.com/articles/adding-a-new-ssh-key-to-your-github-account/)
- ehhez az ssh kulcs: **cat ~/.ssh/id_rsa.pub**
- .NET Core telepítés [innen](https://www.microsoft.com/net/core#linuxubuntu), UBUNTU 14.04-re (verziószám: [**lsb_release -a**](https://help.ubuntu.com/community/CheckingYourUbuntuVersion))
- **cd ASP.NET-Core-201703\ASPNETCore\src\ASPNETCore**
- **dotnet restore**
- **dotnet run**
- The specified framework 'Microsoft.NETCore.App', version '1.0.0' was not found. ([Hanselmann](https://www.hanselman.com/blog/TheMysteryOfDotnetWatchAndMicrosoftNETCoreAppVersion110preview100110000WasNotFound.aspx))
- átírtam a verziószámot 1.1-re, majd újrafuttattam: Error -98 EADDRINUSE address already in use
- vagy telepíthetjük [az 1.0-t is](https://www.microsoft.com/net/download/linux)
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

## global.json
"projects": [ "src", "test" ],
