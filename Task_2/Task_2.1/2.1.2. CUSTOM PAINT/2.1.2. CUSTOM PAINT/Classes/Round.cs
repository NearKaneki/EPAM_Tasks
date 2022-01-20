namespace _2._1._2._CUSTOM_PAINT.Classes
{
    public class Round:Circle
    {
        public Round() { }

        public double Area =>Math.PI*Math.Pow(_radius,2); 

        public override void Output()
        {
            Console.WriteLine($"Круг с центром в точке ({_center.Item1},{_center.Item2}) и радиусом {_radius}\n" +
    $"Длина окружности: {Length}\n" +
    $"Площадь: {Area}");
        }
    }
}
