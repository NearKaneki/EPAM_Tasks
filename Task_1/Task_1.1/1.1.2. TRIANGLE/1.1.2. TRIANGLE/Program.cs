Console.Write($"n = ");
int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; ++i)
{
    Console.WriteLine(new String('*',i+1));
}