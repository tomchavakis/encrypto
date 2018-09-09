using CommandLine;

namespace Encrypto
{
             
        [Verb("encrypt", HelpText = "Encrypt File Or Folder")]
        class EncryptOptions { //normal options here
            
            [Option('i', "input", Required = true, HelpText = "Input File or Folder to encrypt.")]
            public string InputFile { get; set; }
        }
        
        [Verb("decrypt", HelpText = "Dencrypt File Or Folder")]
        
        class DecryptOptions { //normal options here
            
            [Option('i', "input", Required = true, HelpText = "Input File or Folder to encrypt.")]
            public string InputFile { get; set; }
        
        }
        
    
}