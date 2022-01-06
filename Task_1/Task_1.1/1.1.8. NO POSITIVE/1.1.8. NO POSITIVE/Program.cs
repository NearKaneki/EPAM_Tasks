static void ShowArray(int[,,] array)
{
    for (int x = 0; x < array.GetLength(0); ++x)
    {
        for (int y = 0; y < array.GetLength(1); ++y)
        {
            for (int z = 0; z < array.GetLength(2); ++z)
            {
                Console.Write($"{array[x, y, z]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("-----------");
    }
}
int[,,] array3D = new int[3, 3, 3];
Random r = new Random();
for (int x = 0; x < array3D.GetLength(0); ++x)
{
    for (int y = 0; y < array3D.GetLength(1); ++y)
    {
        for (int z = 0; z < array3D.GetLength(2); ++z)
        {
            array3D[x, y, z] = r.Next(-100,100);
        }
    }
}
ShowArray(array3D);
for (int x = 0; x < array3D.GetLength(0); ++x)
{
    for (int y = 0; y < array3D.GetLength(1); ++y)
    {
        for (int z = 0; z < array3D.GetLength(2); ++z)
        {
            if (array3D[x, y, z] > 0)
            {
                array3D[x, y, z] = 0;
            }
        }
    }
}
Console.WriteLine("After changes:\n------------------");
ShowArray(array3D);