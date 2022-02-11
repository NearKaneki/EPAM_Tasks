namespace Task_3._3._1._SUPER_ARRAY
{
    public static class ArrayFloatExtensions
    {
        public static void ChangeArray(this float[] array, Func<float, float> func) =>
            array = array.Select(x => func(x)).ToArray();

        public static float SumNumbers(this float[] array) => array.Sum();

        public static float AverageNumber(this float[] array) => array.Average();

        public static float OftRepeatedItem(this float[] array)
        {
            Dictionary<float, int> dict = new Dictionary<float, int>();
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
