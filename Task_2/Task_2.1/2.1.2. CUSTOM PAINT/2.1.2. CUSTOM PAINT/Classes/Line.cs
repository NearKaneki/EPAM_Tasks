using _2._1._2._CUSTOM_PAINT.Interfaces;

namespace _2._1._2._CUSTOM_PAINT.Classes
{
    public class Line : IFigure
    {
        private (int, int) _start;
        private (int, int) _end;

        public double Length => Math.Sqrt(Math.Pow(_end.Item1 - _start.Item1, 2) + Math.Pow(_end.Item2 - _start.Item1, 2));

        public Line() { }

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
