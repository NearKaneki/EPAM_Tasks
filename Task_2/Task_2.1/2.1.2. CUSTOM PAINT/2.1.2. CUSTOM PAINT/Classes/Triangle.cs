namespace _2._1._2._CUSTOM_PAINT.Classes
{
    public class Triangle : Figure
    {
        private Line _a;
        private Line _b;
        private Line _c;

        public override (double, double) Center => ((_a.Start.Item1 + _b.Start.Item1 + _c.Start.Item1) / 3, (_a.End.Item2 + _b.End.Item2 + _c.End.Item2) / 3);
        public double Perimeter =>_a.Length+_b.Length+_c.Length; 
        public double Area
        {
            get
            {
                double p = Perimeter / 2;
                return Math.Sqrt(p*(p-_a.Length)*(p-_b.Length)*(p-_c.Length));
            }
        }

        public Triangle((int, int) p1, (int, int) p2, (int, int) p3) {
            _a = new Line(p1, p2);
            _b = new Line(p2, p3);
            _c = new Line(p3, p1);
        }

        public override string ToString()
        {
            return $"Треугольник{Environment.NewLine}" +
                $"Точки: {_a.Start}, {_b.Start}, {_c.Start}{Environment.NewLine}" +
                $"Центр: {Center}{Environment.NewLine}" +
                $"Периметр: {Math.Round(Perimeter, 2)}{Environment.NewLine}" +
                $"Площадь: {Math.Round(Area, 2)}{Environment.NewLine}";
        }
    }
}
