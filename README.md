# Encryption Tool

## Application - Instructions

### 1. FilesEncryption.Core 

This Application is .NET Core Application. The main purpose is to encrypt or decrypt a folder or unique file using AES 256 Encryption Algorithm.

## Usage

Usage: dotnet Encrypto.App.dll [options]

Options:
  --help            Show help information
  -i                Input Folder or File

### Encrypt Folder
dotnet Encrypto.App.dll encrypt -i /home/tcs/Downloads/

### Decrypt Folder
dotnet Encrypto.App.dll decrypt -i /home/tcs/Downloads/

### using global tool
dotnet tool install --global dotnet-encrypto
