namespace Task_3._3._1._SUPER_ARRAY
{
    public static class ArrayDoubleExtensions
    {
        public static void ChangeArray(this double[] array, Func<double, double> func) =>
            array = array.Select(x => func(x)).ToArray();

        public static double SumNumbers(this double[] array) => array.Sum();

        public static double AverageNumber(this double[] array) => array.Average();

        public static double OftRepeatedItem(this double[] array)
        {
            Dictionary<double, int> dict = new Dictionary<double, int>();
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
