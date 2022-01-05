static int needDigits(int x)
{
    int sum = 0;
    for (int i = x; i < 1000; i += x)
    {
        sum += i;
    }
    return sum;
}
int sum = 0;
int ans = needDigits(3) + needDigits(5);
Console.WriteLine(ans);