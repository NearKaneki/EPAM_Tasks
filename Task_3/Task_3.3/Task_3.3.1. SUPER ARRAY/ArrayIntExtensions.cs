public static class ArrayIntExtensions
{
    public static void ChangeArray(this int[] array, Func<int, int> func) =>
        array = array.Select(x => func(x)).ToArray();

    public static int SumNumbers(this int[] array) => array.Sum();

    public static double AverageNumber(this int[] array) => array.Average();

    public static int OftRepeatedItem(this int[] array)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        foreach (var item in array)
        {
            if (dict.ContainsKey(item))
            {
                ++dict[item];
                continue;
            }
            dict.Add(item, 1);
        }
        return dict.Where(x => x.Value == dict.Max(x => x.Value)).FirstOrDefault().Key;
    }
}