using _2._1._2._CUSTOM_PAINT.Interfaces;

namespace _2._1._2._CUSTOM_PAINT.Classes
{
    public class Triangle : IFigure,IPolygon
    {
        private Line _a;
        private Line _b;
        private Line _c;

        public double Perimeter =>_a.Length+_b.Length+_c.Length; 

        public double Area
        {
            get
            {
                double p = Perimeter / 2;
                return Math.Sqrt(p*(p-_a.Length)*(p-_b.Length)*(p-_c.Length));
            }
        }

        public Triangle() { }

        public void Output()
        {
            throw new NotImplementedException();
        }

        public void SetParam()
        {
            throw new NotImplementedException();
        }
    }
}
