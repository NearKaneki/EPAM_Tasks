namespace Task_3._3._1._SUPER_ARRAY
{
    public static class ArrayLongExtensions
    {
        public static void ChangeArray(this long[] array, Func<long, long> func) =>
            array = array.Select(x => func(x)).ToArray();

        public static long SumNumbers(this long[] array) => array.Sum();

        public static double AverageNumber(this long[] array) => array.Average();

        public static long OftRepeatedItem(this long[] array)
        {
            Dictionary<long, int> dict = new Dictionary<long, int>();
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
}
