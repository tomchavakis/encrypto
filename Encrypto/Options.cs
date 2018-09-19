using CommandLine;

namespace Encrypto
{
             
        [Verb("encrypt", HelpText = "Encrypt File(s) Or Folder(s")]
        class EncryptOptions { //normal options here
            
            [Option('i', "input", Required = true, HelpText = "Input File(s) or Folder(s) to encrypt.")]
            public string InputFile { get; set; }
        }
        
        [Verb("decrypt", HelpText = "Dencrypt File(s) Or Folder(s")]
        
        class DecryptOptions { //normal options here
            
            [Option('i', "input", Required = true, HelpText = "Input File(s) or Folder(s) to decrypt.")]
            public string InputFile { get; set; }
        
        }
        
    
}