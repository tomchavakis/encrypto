# Encryption Tool

## Application - Instructions

### 1. FilesEncryption.Core 

This Application is .NET Core Application. The main purpose is to encrypt or decrypt a folder or unique file using AES 256 Encryption Algorithm.

## Usage

Usage: dotnet dotnet-encrypto.dll [options]

Options:
  --help            Show help information
  -i                Input Folder or File

### Encrypt Folder
dotnet dotnet-encrypto.dll encrypt -i /home/tcs/Downloads/

### Decrypt Folder
dotnet dotnet-encrypto.dll decrypt -i /home/tcs/Downloads/

### using global tool
dotnet tool install --global dotnet-encrypto

### Using tool
dotnet-encrypto --help
dotnet-encrypto encrypt -i /home/tcs/Downloads/
dotnet-encrypto decrypt -i /home/tcs/Downloads/