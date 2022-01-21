namespace _2._1._2._CUSTOM_PAINT.Classes
{
    public class Circle : Figure
    {
        public int Radius { get; init; }
        public override (double, double) Center { get; init; }
        public double Length => 2 * Math.PI * Radius;

        public Circle((int, int) c, int r)
        {
            Radius = r;
            Center = c;
        }

        public override string ToString()
        {
            return $"Окружность{Environment.NewLine}" +
                $"Центр: {Center}{Environment.NewLine}" +
                $"Радиус: {Radius}{Environment.NewLine}" +
                $"Длина окружности: {Math.Round(Length, 2)}{Environment.NewLine}";
        }
    }
}
