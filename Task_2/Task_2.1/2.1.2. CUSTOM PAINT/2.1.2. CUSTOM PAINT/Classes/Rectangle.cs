using _2._1._2._CUSTOM_PAINT.Interfaces;

namespace _2._1._2._CUSTOM_PAINT.Classes
{
    public class Rectangle : IFigure,IPolygon
    {
        protected Line _a;
        protected Line _b;

        public double Perimeter =>_a.Length*2+_b.Length*2;

        public double Area => _a.Length * _b.Length;

        public Rectangle() { }
        public virtual void Output()
        {
            throw new NotImplementedException();
        }

        public virtual void SetParam()
        {
            throw new NotImplementedException();
        }
    }
}
