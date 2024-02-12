namespace DigitalDesignIntern
{
    internal class Program
    {
        static void Main()
        {
            //Результат выведется в result.txt, 
            CountWords(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\input.txt"), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\result.txt"));
        }

        public static void CountWords(string InputFilePath, string OutputFilePath)
        {
            String[] separators = { " ", "\n", "\r", "\t", ".", ",", ";", ":", "!", "?","--"};
            string text = File.ReadAllText(InputFilePath);
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> WordCounts = new();


            foreach (string word in words)
            {
                if (WordCounts.ContainsKey(word))
                {
                    WordCounts[word]++;
                }
                else
                {
                    WordCounts[word] = 1;
                }
            }


            var SortedWordCounts = WordCounts.OrderByDescending(pair => pair.Value);
            string Result = "";


            foreach (var pair in SortedWordCounts)
            {
                Result += $"{pair.Key} : {pair.Value}\n";
            }


            File.WriteAllText(OutputFilePath, Result);
            
        }
    }
}
