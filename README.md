# ASP.NET-Core-201703
Az ASP.NET Core NetAcademia tanfolyam kódtár kiegészítése

## Linux subsystem for windows

Minimum windows version:

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
- **cd ASPNETCore**
- **dotnet restore**
- **dotnet run**
