# Encryption Tool

## Application - Instructions

### 1. Encrypto

This Application is dotnet tool and .net core 2.1 Application. 

The main purpose of this tool is to encrypt or decrypt a folder(s) or unique file(s) using AES 256 Encryption Algorithm.
Data will be encrypted with your preferred password.

## Usage

Usage: dotnet dotnet-encrypto.dll [options]

Params:

encrypt            Encrypt Folder(s) or Files

decrypt            Decrypt Folder(s) or Files

Options:

--help            Show help information
  
-i                Input Folder or File

### using global tool (Install tool)

dotnet tool install --global dotnet-encrypto

### using global tool (Uninstall tool)

dotnet tool uninstall --global dotnet-encrypto

### Using tool

dotnet-encrypto --help

Encrypt Folder(s) or Files :

dotnet-encrypto encrypt -i /home/tcs/Downloads/

Decrypt Folder(s) or Files

dotnet-encrypto decrypt -i /home/tcs/Downloads/

### Encrypt Folder
dotnet dotnet-encrypto.dll encrypt -i /home/tcs/Downloads/

### Decrypt Folder
dotnet dotnet-encrypto.dll decrypt -i /home/tcs/Downloads/
