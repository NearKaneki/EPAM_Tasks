int[] array = new int[10];
Random r = new Random();
for (int i = 0; i < array.Length; i++)
{
    array[i] = r.Next(100);
    Console.Write($"{array[i]} ");
}
//int max = 0;
//int min = 101;
//for (int i = 0; i < 10; ++i)
//{
//    if (array[i] > max)
//    {
//        max = array[i];
//    }
//    if (array[i] < min)
//    {
//        min = array[i];
//    }
//}
for (int i = 0; i < array.Length; i++)
{
    for (int j = i + 1; j < array.Length; j++)
    {
        if (array[i] > array[j])
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
Console.WriteLine();
for (int i = 0; i < array.Length; i++)
{
    Console.Write($"{array[i]} ");
}
Console.WriteLine();
Console.WriteLine($"min = {array[0]}");
Console.WriteLine($"max = {array[^1]}");





