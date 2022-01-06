using System.Linq;

int[] array = new int[10];
Random r = new Random();
for (int i = 0; i < array.Length; i++)
{
    array[i] = r.Next(-100, 100);
    Console.Write($"{array[i]} ");
}
Console.WriteLine();
Console.WriteLine($"SUM = {array.Where(x => x > 0).Sum()}");