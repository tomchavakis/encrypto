using CommandLine;

namespace Encrypto
{

    [Verb("encrypt", HelpText = "Encrypt File(s) Or Folder(s")]
    class EncryptOptions
    { //normal options here

        [Option('i', "input", HelpText = "Input File(s) or Folder(s) to encrypt.")]
        public string InputFile { get; set; }

        [Option('t', "text", HelpText = "Insert the text for encryption")]
        public string InputText { get; set; }
    }

    [Verb("decrypt", HelpText = "Dencrypt File(s) Or Folder(s")]
    class DecryptOptions
    { //normal options here

        [Option('i', "input", HelpText = "Input File(s) or Folder(s) to decrypt.")]
        public string InputFile { get; set; }

        [Option('t', "text", HelpText = "Insert the text for decryption")]
        public string InputText { get; set; }

    }


}