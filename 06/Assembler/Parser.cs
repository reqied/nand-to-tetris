namespace Assembler
{
    public class Parser
    {
        /// <summary>
        /// Удаляет все комментарии и пустые строки из программы. Удаляет все пробелы из команд.
        /// </summary>
        /// <param name="asmLines">Строки ассемблерного кода</param>
        /// <returns>Только значащие строки строки ассемблерного кода без комментариев и лишних пробелов</returns>
        public string[] RemoveWhitespacesAndComments(string[] asmLines)
        {
            var result = new List<string>();

            foreach (var line in asmLines)
            {
                var noCommentLine = line.Split(@"//")[0].Trim();
                if (string.IsNullOrEmpty(noCommentLine))
                    continue;
                var compactLine = string.Concat(noCommentLine.Where(c => !char.IsWhiteSpace(c)));
                result.Add(compactLine);
            }
            return result.ToArray();
        }
    }
}
