namespace _2._1._2._CUSTOM_PAINT.Classes
{
    public class Square : Rectangle
    {
        public Square((int, int) p1, (int, int) p2, (int, int) p3) : base(p1, p2, p3)
        {
            if (_a.Length != _b.Length)
            {
                throw new ArgumentException("Стороны не равны");
            }
        }
        public override string ToString()
        {
            return $"Квадрат{Environment.NewLine}" +
                $"Длина стороны: {_a.Length}{Environment.NewLine}" +
                $"Центр: {Center}{Environment.NewLine}" +
                $"Периметр: {Math.Round(Perimeter, 2)}{Environment.NewLine}" +
                $"Площадь: {Math.Round(Area, 2)}{Environment.NewLine}";
        }
    }
}
