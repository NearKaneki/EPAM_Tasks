Console.Write("Input string: ");
string s = new string(Console.ReadLine());
char[] separators = { '.', ',', '!', '?', ';', ':', '-', ' ' };
string[] words = s.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
int ans = words.Where(x => char.IsLower(x[0])).Select(x => x).Count();
Console.WriteLine(ans);