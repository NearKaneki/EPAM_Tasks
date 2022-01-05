Console.Write($"n = ");
int n = int.Parse(Console.ReadLine());
for (int i = 1; i <= n; ++i)
{
    for (int j = 0; j < i; ++j)
    {
        string temp = new string(' ', n - j - 1);
        temp += new string('*', j * 2 + 1);
        Console.WriteLine(temp);
    }
    
}