using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;

namespace Encrypto
{
    [Verb("encrypt", HelpText = "Encrypt File(s) Or Folder(s")]
    class EncryptOptions
    { //normal options here

        [Option('i', "input", HelpText = "Input File(s) or Folder(s) to encrypt.")]
        public string InputFile { get; set; }
        [Option('t', "text", HelpText = "Insert the text for encryption")]
        public string InputText { get; set; }
        [Usage(ApplicationAlias = "dotnet-encrypto")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                return new List<Example>() {
                new Example("encrypt folder", new EncryptOptions { InputFile = "~/Downloads/test" }),
                new Example("encrypt file", new EncryptOptions { InputFile = "~/Downloads/text.txt" }),
                new Example("encrypt text", new EncryptOptions { InputText = "thomas" }),
                new Example("encrypt text with escape characters", new EncryptOptions { InputText = "text \"to encrypt" }),
            };
            }
        }
    }

    [Verb("decrypt", HelpText = "Decrypt File(s) Or Folder(s")]
    class DecryptOptions
    { //normal options here

        [Option('i', "input", HelpText = "Input File(s) or Folder(s) to decrypt.")]
        public string InputFile { get; set; }
        [Option('t', "text", HelpText = "Insert the text for decryption")]
        public string InputText { get; set; }
        [Usage(ApplicationAlias = "dotnet-encrypto")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                return new List<Example>() {
                new Example("encrypt folder", new DecryptOptions { InputFile = "~/Downloads/test" }),
                new Example("encrypt file", new DecryptOptions { InputFile = "~/Downloads/text.txt" }),
                new Example("encrypt text", new DecryptOptions { InputText = "thomas" }),
                new Example("encrypt text with escape characters", new DecryptOptions { InputText = "text \"to encrypt" }),
            };
            }
        }
    }
}