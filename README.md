# Encryption Tool [![CodeFactor](https://www.codefactor.io/repository/github/tomchavakis/encrypto/badge)](https://www.codefactor.io/repository/github/tomchavakis/encrypto/overview/develop) [![Build Status](https://travis-ci.com/tomchavakis/encrypto.svg?branch=develop)](https://travis-ci.com/tomchavakis/encrypto.svg?branch=develop) [![NuGet](https://img.shields.io/nuget/v/BeatPulse.svg)](https://www.nuget.org/packages/dotnet-encrypto)

## Application - Instructions

### 1. Encrypto

This Application is dotnet tool and .net core 2.1 Application.

The main purpose of this tool is to encrypt or decrypt a folder(s) or unique file(s) using AES 256 Encryption Algorithm.
Data will be encrypted with your preferred password.

## Usage

Usage: dotnet-encrypto [params] [options]

** Params:

| Parameter | Description |
|------|-------------|
| `encrypt` | Encrypt Folder(s) or Files |
| `decrypt` | Decrypt Folder(s) or Files |

** Options:

| Option | Description |
|------|-------------|
| `--help` | Show help information |
| `-i` | Folder or File |

## dotnet-encrypto tool

* Install tool

`dotnet tool install --global dotnet-encrypto`

* Uninstall tool

`dotnet tool uninstall --global dotnet-encrypto`

## Using tool

`dotnet-encrypto --help`

Usage:

`dotnet-encrypto encrypt --help`

Usage :

`dotnet-encrypto decrypt --help`

#### Encrypt Folder(s) or Files :

`dotnet-encrypto encrypt -i /home/tcs/Downloads/`

#### Decrypt Folder(s) or Files

`dotnet-encrypto decrypt -i /home/tcs/Downloads/`

#### Encrypt Text:

Create a base64 encoded encrypted text:

`dotnet-encrypto encrypt -t "tom"`

#### Decrypt Text:

`dotnet-encrypto decrypt -t "P/A6VZEaRHCB8WV9S5m58g=="`

## Nuget

https://www.nuget.org/packages/dotnet-encrypto

