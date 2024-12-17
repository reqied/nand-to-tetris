
namespace Assembler
{
    public class HackTranslator
    {
        private static readonly Dictionary<string, string> CompTable = new()
        {
            { "0", "0101010" }, { "1", "0111111" }, { "-1", "0111010" }, { "D", "0001100" },
            { "A", "0110000" }, { "M", "1110000" }, { "!D", "0001101" }, { "!A", "0110001" },
            { "!M", "1110001" }, { "-D", "0001111" }, { "-A", "0110011" }, { "-M", "1110011" },
            { "D+1", "0011111" }, { "A+1", "0110111" }, { "M+1", "1110111" }, { "D-1", "0001110" },
            { "A-1", "0110010" }, { "M-1", "1110010" }, { "D+A", "0000010" }, { "D+M", "1000010" },
            { "D-A", "0010011" }, { "D-M", "1010011" }, { "A-D", "0000111" }, { "M-D", "1000111" },
            { "D&A", "0000000" }, { "D&M", "1000000" }, { "D|A", "0010101" }, { "D|M", "1010101" }
        };
        
        private static readonly Dictionary<string, string> DestTable = new()
        {
            { "", "000" }, { "M", "001" }, { "D", "010" }, { "MD", "011" }, { "A", "100" },
            { "AM", "101" }, { "AD", "110" }, { "AMD", "111" }
        };
        
        private static readonly Dictionary<string, string> JumpTable = new()
        {
            { "", "000" }, { "JGT", "001" }, { "JEQ", "010" }, { "JGE", "011" },
            { "JLT", "100" }, { "JNE", "101" }, { "JLE", "110" }, { "JMP", "111" }
        };
        
        /// <summary>
        /// Транслирует инструкции ассемблерного кода (без меток) в бинарное представление.
        /// </summary>
        /// <param name="instructions">Ассемблерный код без меток</param>
        /// <param name="symbolTable">Таблица символов</param>
        /// <returns>Строки инструкций в бинарном формате</returns>
        /// <exception cref="FormatException">Ошибка трансляции</exception>
        
        private int nextAvailableAddress = 16;
        public string[] TranslateAsmToHack(string[] instructions, Dictionary<string, int> symbolTable)
        {
            var hackCode = new List<string>();

            foreach (var instruction in instructions)
            {
                var cleanedInstruction = instruction.Split("//")[0].Trim();
                hackCode.Add(cleanedInstruction.StartsWith("@")
                    ? AInstructionToCode(cleanedInstruction, symbolTable)
                    : CInstructionToCode(cleanedInstruction));
            }
            return hackCode.ToArray();
        }
        
        /// <summary>
        /// Транслирует одну A-инструкцию ассемблерного кода в бинарное представление
        /// </summary>
        /// <param name="aInstruction">Ассемблерная A-инструкция, например, @42 или @SCREEN</param>
        /// <param name="symbolTable">Таблица символов</param>
        /// <returns>Строка, содержащее нули и единицы — бинарное представление
        /// ассемблерной инструкции, например, "0000000000000101"</returns>
        public string AInstructionToCode(string aInstruction, Dictionary<string, int> symbolTable)
        {
            var symbol = aInstruction[1..];
            if (int.TryParse(symbol, out var address))
            {
                return Convert.ToString(address, 2).PadLeft(16, '0');
            }
            if (!symbolTable.ContainsKey(symbol))
            {
                symbolTable[symbol] = nextAvailableAddress++;
            }
            address = symbolTable[symbol];
            return Convert.ToString(address, 2).PadLeft(16, '0');
        }


        /// <summary>
        /// Транслирует одну C-инструкцию ассемблерного кода в бинарное представление
        /// </summary>
        /// <param name="cInstruction">Ассемблерная C-инструкция, например, A=D+M</param>
        /// <returns>Строка, содержащее нули и единицы — бинарное представление
        /// ассемблерной инструкции, например, "1111000010100000"</returns>
        public string CInstructionToCode(string cInstruction)
        {
            var splitCInstruction = cInstruction.Split(";");
            var destOrComp = splitCInstruction[0].Split("=");
            var jump = splitCInstruction.Length == 2 ? splitCInstruction[1].Trim() : "";
            var dest = destOrComp.Length == 2 ? destOrComp[0] : "" ;
            var comp = destOrComp.Last();
            if (CompTable.TryGetValue(comp, out var compBits) 
                && DestTable.TryGetValue(dest, out var destBits)
                && JumpTable.TryGetValue(jump, out var jumpBits))
                return "111" + compBits + destBits + jumpBits;
            throw new ArgumentException($"Wrong instruction: {cInstruction}");
        }
    }
}
