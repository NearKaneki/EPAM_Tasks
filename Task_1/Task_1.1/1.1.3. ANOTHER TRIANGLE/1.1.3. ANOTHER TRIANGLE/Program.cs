Console.Write($"n = ");
int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; ++i)
{
    string temp = new string(' ', n - i - 1);
    temp += new string('*', i*2+1);
    Console.WriteLine(temp);
}