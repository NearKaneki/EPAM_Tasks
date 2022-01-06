Console.Write("Input string: ");
string s = new string(Console.ReadLine());
char[] separators = { '.', ',', '!', '?', ';', ':', '-', ' ' };
string[] words = s.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
int ans = words.Select(x => x.Length).Sum()/words.Count();//округление в меньшую сторону
Console.WriteLine(ans);