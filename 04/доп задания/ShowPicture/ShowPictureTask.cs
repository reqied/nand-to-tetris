using System;
using System.Collections.Generic;

namespace ShowPicture
{
    public static class ShowPictureTask
    {
        public static string[] GenerateShowPictureCode(bool[,] pixels)
        {
            var program = new List<string>();
            const int position = 16384;
            var height = pixels.GetLength(0);
            var width = pixels.GetLength(1);
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x += 16)
                {
                    var address = position + y * 32 + x / 16;
                    var value = "";
                    value = MakeValue(pixels, x, value, y);
                    int intValue = Convert.ToInt16(value, 2);
                    var aOrNotA = "A";
                    if (value.StartsWith("1"))
                    {                               
                        aOrNotA = "A";
                        intValue = ~intValue;
                        aOrNotA = "!A";
                    }
                    FillTheList(intValue, aOrNotA, address, program);
                }
            }
            return program.ToArray();
        }

        private static string MakeValue(bool[,] pixels, int x, string value, int y)
        {
            for (var i = x + 15; i >= x; i--)
            {
                value += (pixels[y, i] ? "1" : "0");
            }
            return value;
        }

        private static void FillTheList(int intValue, string aOrNotA, int address, List<string> program)
        {
            program.Add($"@{intValue.ToString()}");
            program.Add($"D={aOrNotA}");
            program.Add($"@{address}");
            program.Add("M=D");
        }
    }
}
