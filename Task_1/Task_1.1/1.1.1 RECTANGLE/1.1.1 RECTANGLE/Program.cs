static int init(char x)
{
    Console.Write($"{x} = ");
    int temp = int.Parse(Console.ReadLine());
    return temp;
}

int a = init('a');
int b = init('b');
if (a <= 0 || b <= 0)
{
    throw new ArgumentException("Incorrect values entered");
}
else
{
    Console.WriteLine($"Area = {a * b}");
}
