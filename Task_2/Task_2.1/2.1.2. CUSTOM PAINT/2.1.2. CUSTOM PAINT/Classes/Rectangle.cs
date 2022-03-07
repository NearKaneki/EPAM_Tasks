namespace _2._1._2._CUSTOM_PAINT.Classes
{
    public class Rectangle : Figure
    {
        protected Line _a;
        protected Line _b;

        public override (double, double) Center => ((_a.Start.Item1 + _b.End.Item1) / 2, (_a.Start.Item2 + _a.End.Item2) / 2);
        public double Perimeter => _a.Length * 2 + _b.Length * 2;
        public double Area => _a.Length * _b.Length;

        public Rectangle((int, int) p1, (int, int) p2, (int, int) p3)
        {
            _a = new Line(p1, p2);
            _b = new Line(p2, p3);
        }

        public override string ToString()
        {
            return $"Прямоугольник{Environment.NewLine}" +
                $"Длина сторон: {_a.Length}, {_b.Length}{Environment.NewLine}" +
                $"Центр: {Center}{Environment.NewLine}" +
                $"Периметр: {Math.Round(Perimeter, 2)}{Environment.NewLine}" +
                $"Площадь: {Math.Round(Area, 2)}{Environment.NewLine}";
        }
    }
}
