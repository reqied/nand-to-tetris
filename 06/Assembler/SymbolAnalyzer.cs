namespace Assembler
{
    public class SymbolAnalyzer
    {
        /// <summary>
        /// Находит все метки в ассемблерном коде, удаляет их из кода и вносит их адреса в таблицу символов.
        /// </summary>
        /// <param name="instructionsWithLabels">Ассемблерный код, возможно, содержащий метки</param>
        /// <param name="instructionsWithoutLabels">Ассемблерный код без меток</param>
        /// <returns>
        /// Таблица символов, содержащая все стандартные предопределенные символы (R0−R15, SCREEN, ...),
        /// а также все найденные в программе метки.
        /// </returns>
        // пояснения
        // создаем словарь: (key: метка, value: адрес)
        // пробегаем по всем строчкам ассемблерного кода, если строка содержит метку типа (LOOP),
        // то добавляем её в словарь, где адрес это currentAddress
        // если строка не является меткой, то добавляем её в итоговую программу и увеличиваем currentAddress.

        public Dictionary<string, int> CreateSymbolsTable(string[] instructionsWithLabels,
            out string[] instructionsWithoutLabels)
        {
            var symbolTable = new Dictionary<string, int>
            {
                {"R0", 0}, {"R1", 1}, {"R2", 2}, {"R3", 3}, {"R4", 4},
                {"R5", 5}, {"R6", 6}, {"R7", 7}, {"R8", 8}, {"R9", 9},
                {"R10", 10}, {"R11", 11}, {"R12", 12}, {"R13", 13},
                {"R14", 14}, {"R15", 15}, {"SCREEN", 0x4000}, {"KBD", 0x6000},
                {"SP", 0}, {"LCL", 1}, {"ARG", 2}, {"THIS", 3}, {"THAT", 4}
            };
            var cleanedInstructions = new List<string>();
            foreach (var instruction in instructionsWithLabels)
            {
                FillTheDictionary(instruction, symbolTable, cleanedInstructions);
            }
            instructionsWithoutLabels = cleanedInstructions.ToArray();
            return symbolTable;
        }

        private static void FillTheDictionary(string instruction, 
            Dictionary<string, int> symbolTable,
            List<string> cleanedInstructions)
        {
            if (instruction.StartsWith("(") && instruction.EndsWith(")"))
            {
                var label = instruction[1..^1];
                if (label == string.Empty || label.Contains('(') || label.Contains(')') )
                    throw new ArgumentException($"Wrong label {instruction}");
                symbolTable.TryAdd(label, cleanedInstructions.Count);
            }
            else
            {
                cleanedInstructions.Add(instruction);
            }
        }
    }
}
