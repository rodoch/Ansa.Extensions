# Ansa.Extensions

[![NuGet Pre Release](https://img.shields.io/nuget/vpre/Ansa.Extensions.svg)](https://www.nuget.org/packages/Ansa.Extensions/)
[![NuGet](https://img.shields.io/nuget/dt/Ansa.Extensions.svg)](https://www.nuget.org/packages/Ansa.Extensions/)

This is a small collection of general-purpose extension methods I use to make life easier when developing ASP.NET applications. It's packaged as a .NET Standard 2.0 class library. Some of the better methods have been grabbed from a few great open-source projects (credit given where credit is due below). I'll continue adding to this as I find new shortcuts.

## Installation

Add the NuGet package [Ansa.Extensions](https://www.nuget.org/packages/Ansa.Extensions/) to any ASP.NET project that support .NET Standard 2.0 or above.

```cmd
dotnet add package Ansa.Extensions
```

## Methods

### General

#### `string.IsNullOrWhiteSpace()`

For those times when you're tired of typing `String.IsNullOrEmpty(s)`. Swiped from the rather exceptional [StackExchange.Exceptional](https://github.com/NickCraver/StackExchange.Exceptional) repo.

#### `string.HasValue()`

For those times when you're tired of typing `!String.IsNullOrEmpty(s)`. Also taken from the [StackExchange.Exceptional](https://github.com/NickCraver/StackExchange.Exceptional) repo.

#### `string.HasValueOrDBNull()`

Avoid those pesky NullReferenceExceptions when passing strings to a DbParameter in a SQL query.

#### `int.HasValueOrDBNull()`

Avoid even peskier NullReferenceExceptions when passing ***nullable* integers** to a DbParameter in a SQL query.

### URLs

#### `string.RemoveDiacritics()`

Returns a string where all characters with diacritics (such as an accent or cedilla) have been converted to normalised characters with their diacritics removed. Can be useful when constructing URLs and URL slugs. Credit due to [Michael S. Kaplan](http://archives.miloush.net/michkap/archive/2007/05/14/2629747.html).

#### `string.ToUrlSlug()`

'Slugifies' a given string so that it can be used in a URL: characters are converted to lowercase, diacritics are removed, word delimiters and invalid characters are replaced with hyphens.

#### `string.EnforceUrlProtocol()`

Prepends a properly-formed HTTP protocol (http://) to a string if none is present already.

### Email

A variety of methods useful in programmatically constructing an HTML e-mail are provided. These methods are best understood by viewing the source code. Most of these e-mail-specific methods were also taken from the [StackExchange.Exceptional](https://github.com/NickCraver/StackExchange.Exceptional) repo.
