int[,] array = new int[5, 5];
Random r = new Random();
for (int i = 0; i < array.GetLength(0); i++)
{
    for (int j = 0; j < array.GetLength(1); j++)
    {
        array[i, j] = r.Next(10);
        Console.Write($"{array[i, j]} ");
    }
    Console.WriteLine();
}
Console.WriteLine();
int ans = 0;
for (int i = 0; i < array.GetLength(0); ++i)
{
    int j = i % 2 == 0 ? 0 : 1;
    for (; j < array.GetLength(1); j += 2)
    {
        ans += array[i, j];
    }
}
Console.WriteLine(ans);