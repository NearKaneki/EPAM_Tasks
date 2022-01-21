namespace _2._1._2._CUSTOM_PAINT.Classes
{
    public class Line : Figure
    {
        public (int, int) Start { get; init; }
        public (int, int) End { get; init; }
        public override (double, double) Center => ((Start.Item1 + End.Item1) / 2, (Start.Item2 + End.Item2) / 2);
        public double Length => Math.Sqrt(Math.Pow(End.Item1 - Start.Item1, 2) + Math.Pow(End.Item2 - Start.Item2, 2));

        public Line((int, int) s, (int, int) e)
        {
            Start = s;
            End = e;
        }

        public override string ToString()
        {
            return $"Линия{Environment.NewLine}" +
                $"Начало линии в {Start}, конец - {End}{Environment.NewLine}" +
                $"Центр: {Center}{Environment.NewLine}" +
                $"Длина : {Math.Round(Length, 2)}{Environment.NewLine}";
        }
    }
}
