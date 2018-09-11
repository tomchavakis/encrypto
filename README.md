# Encryption Tool

## Application - Instructions

### 1. FilesEncryption.Core 

This Application is .NET Core Application. The main purpose is to encrypt or decrypt a folder or unique file using AES 256 Encryption Algorithm.

## Usage

Usage: dotnet dotnet-encrypto.dll [options]

Params:

encrypt            Encrypt Folder or Files

decrypt            Decrypt Folder or Files

Options:

--help            Show help information
  
-i                Input Folder or File

### using global tool (Install tool)

dotnet tool install --global dotnet-encrypto

### using global tool (Uninstall tool)

dotnet tool uninstall --global dotnet-encrypto

### Using tool

dotnet-encrypto --help

Encrypt Folder or Files :

dotnet-encrypto encrypt -i /home/tcs/Downloads/

Decrypt Folder or Files

dotnet-encrypto decrypt -i /home/tcs/Downloads/

### Encrypt Folder
dotnet dotnet-encrypto.dll encrypt -i /home/tcs/Downloads/

### Decrypt Folder
dotnet dotnet-encrypto.dll decrypt -i /home/tcs/Downloads/
