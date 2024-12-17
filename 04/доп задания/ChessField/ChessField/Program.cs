using System;

namespace ChessField;

public static class ChessField
{
    public static void Main()
    {
        var sw = new StreamWriter(@"D:\work\ChessField\chessfield.txt");
        var program = new List<string>();
        const int position = 16384;
        const int height = 260;
        const int width = 512;
        var countX = 0;
        var countY = 0;
        var counyYSell = 0;
        sw.WriteLine($"@0");
        sw.WriteLine($"D=!A");
        for (var y = 0; y <= height; y++)
        {
            for (var x = 0; x < width; x += 16)
            {
                var address = position + y * 32 + x / 16;
                if (countX % 2 == 0 && counyYSell % 2 == 0)
                {
                    sw.WriteLine($"@{address}");
                    sw.WriteLine("M=D");
                }

                if (countX % 2 != 0 && counyYSell % 2 != 0)
                {
                    sw.WriteLine($"@{address}");
                    sw.WriteLine("M=D");
                }
                countX++;
            }
            countY++;
            if (countY % 16 == 0 && countY != 0)
            {
                counyYSell++;
            }
        }
        sw.WriteLine($"@END");
        sw.WriteLine($"0;JMP");
        sw.Close();
    }
}