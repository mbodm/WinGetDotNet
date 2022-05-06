# WinGetDotNet
Some easy-to-use [_WinGet_](https://docs.microsoft.com/en-us/windows/package-manager/winget) wrapper library for .NET

![wingetupd.exe](img/screenshot-source-code.png)

### What it is
It´s a simple and tiny .NET 6 assembly named `WinGetDotNet`. The library wraps the popular Windows-App [_WinGet_](https://docs.microsoft.com/en-us/windows/package-manager/winget). _WinGet_ is used to manage software packages on a Windows machine. `WinGetDotNet` makes it easy, to integrate _WinGet_ into a .NET program.

`WinGetDotNet` is specifically designed with the [_KISS principle_](https://en.wikipedia.org/wiki/KISS_principle) in mind. It´s sole purpose is just to wrap the _WinGet_ application process calls. Nothing else.

Btw: _WinGet_ is imo a __fantastic__ piece of software, to manage all of your Windows applications and keep your Windows software up2date. Fat kudos :thumbsup: to Microsoft here!  For more information about _WinGet_ itself, take a look at https://docs.microsoft.com/en-us/windows/package-manager/winget or use your Google-Fu techniques.

### How it works
- When started, `wingetupd.exe` searches for a so-called "package-file". The package-file is simply a file named "_packages.txt_", located in the same folder as the `wingetupd.exe`. The package-file contains a list of _WinGet_ package-id´s (__not__ package-names, this is important, see [Notes](#Notes) section below).
- So, when `wingetupd.exe` is started and it founds a package-file, it just checks for each _WinGet_ package-id listed in the package-file, if that package exists, if that package is installed and if that package has an update. If so, it updates the package. `wingetupd.exe` does all of this, by using _WinGet_ internally.
- This means: All you have to do, is to edit the package-file and insert the _WinGet_ package-id´s of your installed Windows applications you want to update. When `wingetupd.exe` is executed, it will try to update all that packages (aka "your Windows applications").

### Requirements
There are not any special requirements, besides having _WinGet_ installed on your machine. `wingetupd.exe` is just a typical command line _.exe_ file for Windows. Just download the newest release, from the [_Releases_](https://github.com/MBODM/wingetupd/releases) page, unzip and run it. All the releases are compiled for x64, assuming you are using some 64-bit Windows (and that's quite likely).

### Notes
- `WinGetDotNet` is written in C#, is using .NET 6 and is built with Visual Studio 2022.
- To compile the source by your own, you just need some Visual Studio 2022 Edition (i.e. _Community_). Nothing else.
- The release-binaries are compiled as _self-contained_ .NET 6 NuGet packages, with "_x64 Windows_" as target.
- _Self-contained_: That´s the reason why the binary-size may be a bit bigger and why there is no framework dependency.
- GitHub´s default _.gitignore_ excludes _Visual Studio 2022_ publish-profiles, so i added a [publish-settings screenshot](img/screenshot-publish-settings.png) to repo.
- The source is using some typical asynchronous TAP pattern approach, including "_Tasks_" and "_async/await_" concepts.
- `WinGetDotNet` just exists, because it started as a sidecar project of my  [_wingetupd_](https://github.com/MBODM/wingetupd) project. :grin:

#### Have fun.

