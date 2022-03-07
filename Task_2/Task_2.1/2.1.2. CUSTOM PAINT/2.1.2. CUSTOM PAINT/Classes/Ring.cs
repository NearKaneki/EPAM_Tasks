namespace _2._1._2._CUSTOM_PAINT.Classes
{
    public class Ring : Figure
    {
        public Round Inside { get; init; }
        public Round Outside { get; init; }
        public override (double, double) Center { get; init; }
        public double SumLength => Inside.Length + Outside.Length;
        public double Area => Outside.Area - Inside.Area;

        public Ring((int, int) c1, int r1, int r2)
        {
            Inside = new Round(c1, r1);
            Outside = new Round(c1, r2);
            Center = c1;
        }

        public override string ToString()
        {
            return $"Кольцо{Environment.NewLine}" +
                $"Центр: {Center}{Environment.NewLine}" +
                $"Внутренний радиус: {Inside.Radius}{Environment.NewLine}" +
                $"Внешний радиус: {Outside.Radius}{Environment.NewLine}" +
                $"Суммарная длина кольца: {Math.Round(SumLength, 2)}{Environment.NewLine}" +
                $"Площадь кольца: {Area}{Environment.NewLine}";
        }
    }
}
