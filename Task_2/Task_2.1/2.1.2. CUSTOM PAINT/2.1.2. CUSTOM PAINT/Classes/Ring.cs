using _2._1._2._CUSTOM_PAINT.Interfaces;

namespace _2._1._2._CUSTOM_PAINT.Classes
{
    public class Ring : IFigure
    {
        private Round _inside;
        private Round _outside;

        public double SumLength =>_inside.Length+_outside.Length; 
        public double Area =>_outside.Area-_inside.Area; 

        public Ring() { }

        public void Output()
        {
            throw new NotImplementedException();
        }

        public void SetParam()
        {
            Console.Write("Введите координаты центра внутренней окружности (x y): ");
            string[] coords = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            bool success = int.TryParse(coords[0], out _inside._center.Item1);
            success = int.TryParse(coords[1], out _inside._center.Item2);
            Console.Write("Введите радиус внутренней окружности: ");
            success = int.TryParse(Console.ReadLine(), out _inside._radius);
            //Доделать
        }
    }
}
