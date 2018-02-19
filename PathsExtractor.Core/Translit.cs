namespace PathsExtractor.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Translit
    {
        private static Dictionary<string, string> _charMap = new Dictionary<string, string>
        {
            {"а", "a"},
            {"б", "b"},
            {"в", "v"},
            {"г", "g"},
            {"д", "d"},
            {"е", "e"},
            {"ё", "yo"},
            {"ж", "zh"},
            {"з", "z"},
            {"ї", "i"},
            {"и", "i"},
            {"й", "j"},
            {"к", "k"},
            {"л", "l"},
            {"м", "m"},
            {"н", "n"},
            {"о", "o"},
            {"п", "p"},
            {"р", "r"},
            {"с", "s"},
            {"т", "t"},
            {"у", "u"},
            {"ф", "f"},
            {"х", "h"},
            {"ц", "c"},
            {"ч", "ch"},
            {"ш", "sh"},
            {"щ", "sch"},
            {"ъ", "j"},
            {"ы", "i"},
            {"ь", "j"},
            {"э", "e"},
            {"ю", "yu"},
            {"я", "ya"},
            {"А", "A"},
            {"Б", "B"},
            {"В", "V"},
            {"Г", "G"},
            {"Д", "D"},
            {"Е", "E"},
            {"З", "Z"},
            {"И", "I"},
            {"Ї", "I"},
            {"Й", "J"},
            {"К", "K"},
            {"Л", "L"},
            {"М", "M"},
            {"Н", "N"},
            {"О", "O"},
            {"П", "P"},
            {"Р", "R"},
            {"С", "S"},
            {"Т", "T"},
            {"У", "U"},
            {"Ф", "F"},
            {"Х", "H"},
            {"Ц", "C"},
            {"Ч", "Ch"},
            {"Ш", "Sh"},
            {"Щ", "Sch"},
            {"Ё", "Yo"},
            {"Ж", "Zh"},
            {"Ъ", "J"},
            {"Ы", "I"},
            {"Ь", "J"},
            {"Э", "E"},
            {"Ю", "Yu"},
            {"Я", "Ya"},
            {" ", "_" },
            {"(", "_" },
            {")", "_" }
        };
        public static void TranslitFileNames(IEnumerable<FileInfo> files)
        {
            foreach (FileInfo file in files)
            {
                string oldFileName = file.FullName;
                string newFileName = oldFileName;
                foreach (KeyValuePair<string, string> keyValuePair in _charMap)
                {
                    newFileName = newFileName.Replace(keyValuePair.Key, keyValuePair.Value);
                }
                string directory = Path.GetDirectoryName(newFileName);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory ?? throw new InvalidOperationException());
                }
                File.Move(oldFileName, newFileName);
            }
        }
    }
}