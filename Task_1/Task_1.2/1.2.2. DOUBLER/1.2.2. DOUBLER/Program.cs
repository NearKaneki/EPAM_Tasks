Console.Write("input first string = ");
string str1 = Console.ReadLine();
Console.Write("input second string = ");
HashSet<char> str2 = new HashSet<char>(Console.ReadLine());
char[] separators = { '.', ',', '!', '?', ';', ':', '-', ' ' };
foreach(var i in separators)
{
    str2.Remove(i);
}
foreach(var i in str2)
{
    str1 = str1.Replace($"{i}", new string(i, 2));
}
Console.WriteLine(str1);

