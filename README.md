# Ansa.Extensions

[![NuGet Pre Release](https://img.shields.io/nuget/vpre/Ansa.Extensions.svg)](https://www.nuget.org/packages/Ansa.Extensions/)

This is a small collection of general-purpose extension methods I use to make life easier when developing ASP.NET applications. It's packaged as a .NET Standard 2.0 class library. Some of the better methods I've grabbed from some great open-source projects (credit where credit is due below). I'll continue adding to this as I find new shortcuts.

## Installation

Add the NuGet package [Ansa.Extensions](https://www.nuget.org/packages/Ansa.Extensions/) to any ASP.NET project that support .NET Standard 2.0 or above.

```cmd
dotnet add package Ansa.Extensions
```

## Methods

### `s.IsNullOrEmpty()`

For those times when you're tired of typing `String.IsNullOrEmpty(s)`. Swiped from the rather exceptional [StackExchange.Exceptional](https://github.com/NickCraver/StackExchange.Exceptional) repo.

### `s.HasValue()`

For those times when you're tired of typing `!String.IsNullOrEmpty(s)`. Also taken from the [StackExchange.Exceptional](https://github.com/NickCraver/StackExchange.Exceptional) repo.

### `s.HasValueOrDBNull()`

Avoid those pesky NullReferenceExceptions when passing strings to a DbParameter in a SQL query.

### `i.HasValueOrDBNull()`

Avoid even peskier NullReferenceExceptions when passing ***nullable* integers** to a DbParameter in a SQL query.
