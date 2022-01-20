using _2._1._2._CUSTOM_PAINT.Interfaces;

namespace _2._1._2._CUSTOM_PAINT.Classes
{
    public class Circle:IFigure
    {
        public (int,int) _center;
        public int _radius;
        public double Length =>2*Math.PI*_radius;

        public Circle() { }

        public virtual void Output()
        {
            Console.WriteLine($"Окружность с центром в точке ({_center.Item1},{_center.Item2}) и радиусом {_radius}\n" +
                $"Длина окружности: {Length}");
        }

        public void SetParam()
        {
            Console.Write("Введите координаты центра (x y): ");
            string[] coords = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            bool success = int.TryParse(coords[0], out _center.Item1);
            success = int.TryParse(coords[1], out _center.Item2);
            Console.Write("Введите радиус: ");
            success = int.TryParse(Console.ReadLine(), out _radius);
        }
    }
}
