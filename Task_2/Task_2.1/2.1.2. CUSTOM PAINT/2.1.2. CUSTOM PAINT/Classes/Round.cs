namespace _2._1._2._CUSTOM_PAINT.Classes
{
    public class Round : Circle
    {
        public double Area => Math.PI * Math.Pow(Radius, 2);

        public Round((int, int) c, int r) : base(c, r) { }

        public override string ToString()
        {
            return $"Круг{Environment.NewLine}" +
                $"Центр: {Center}{Environment.NewLine}" +
                $"Радиус: {Radius}{Environment.NewLine}" +
                $"Длина окружности: {Math.Round(Length, 2)}{Environment.NewLine}" +
                $"Площадь круга: {Area}{Environment.NewLine}";
        }
    }
}
