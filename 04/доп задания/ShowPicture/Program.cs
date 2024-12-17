using System;
using System.IO;

namespace ShowPicture
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // if (args.Length == 0)
            // {
            //     Console.WriteLine($"Usage:\n" +
            //                       $" ShowPicture <file>.png");
            //     Console.WriteLine("Generates <file>.asm, which outputs this png to hack screen");
            //     Environment.Exit(1);
            //     return;
            // }

            var pixels = ImageHelpers.LoadImagePixels("Wizzard.png");
            string[] asmCode = ShowPictureTask.GenerateShowPictureCode(pixels);
            var asmFile = Path.ChangeExtension("D://work//ShowPicture//Wizzard.png", ".asm");
            File.WriteAllLines(asmFile, asmCode);
        }
    }
}
