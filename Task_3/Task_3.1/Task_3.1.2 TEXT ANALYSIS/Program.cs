Console.WriteLine("Input text: ");
string s = new string(Console.ReadLine()).ToLower();

char[] separators = { '.', ',', '!', '?', ';', ':', '-', ' ', ')', '(' };
string[] words = s.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);

Dictionary<string, int> wordsDict = new Dictionary<string, int>();
int countWords = words.Count();
foreach (var word in words)
{
    if (wordsDict.Keys.Contains(word))
    {
        wordsDict[word] += 1;
        continue;
    }
    wordsDict.Add(word, 1);
}

Console.WriteLine($"Count words: {countWords}");
foreach (var word in wordsDict.OrderByDescending(pair => pair.Value))
{
    Console.WriteLine($"Word: {word.Key} Count: {word.Value} Percent: {Math.Round((float)word.Value / countWords * 100, 2)}%");
}