using System.Text;

Console.Write("Input string: ");
string input = new string(Console.ReadLine());
char[] separators = { '.', '!', '?'};
string[] sentences = input.Split(separators,StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
StringBuilder ans=new StringBuilder();
for (int i = 0; i < sentences.Length; ++i)
{
    StringBuilder s = new StringBuilder(sentences[i]);
    s[0] = char.ToUpper(s[0]);
    ans.Append(s);
    ans.Append($"{input[ans.Length]} ");
}
Console.WriteLine(ans);