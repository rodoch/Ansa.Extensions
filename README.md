# Ansa.Extensions

[![NuGet Pre Release](https://img.shields.io/nuget/vpre/Ansa.Extensions.svg)](https://www.nuget.org/packages/Ansa.Extensions/)

This is a tiny collection of general-purpose extension methods I use to make life easier when developing ASP.NET applications. It's packaged as a .NET Standard 2.0 class library. Some of the better methods I've grabbed from some great open-source projects (see Credits below). I'll continue adding to this as I find new shortcuts.

## Installation

Add the NuGet package [Ansa.Extensions](https://www.nuget.org/packages/Ansa.Extensions/) to any ASP.NET project that support .NET Standard 2.0 or above.

```cmd
dotnet add package Ansa.Extensions
```

## Credit where credit is due

The `IsNullOrEmpty()` and `HasValue()` methods are taken from the rather exceptional [StackExchange.Exceptional](https://github.com/NickCraver/StackExchange.Exceptional) repo.
