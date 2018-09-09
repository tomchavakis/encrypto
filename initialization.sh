dotnet new sln --name encrypto
dotnet new console --name encrypto --output encrypto
dotnet new classlib -n AES -o ./encrypt/AES -f netstandard2.0
dotnet sln add ./encrypto/encrypto.csproj
dotnet sln add ./encryptο.AES/AES.csproj
dotnet restore