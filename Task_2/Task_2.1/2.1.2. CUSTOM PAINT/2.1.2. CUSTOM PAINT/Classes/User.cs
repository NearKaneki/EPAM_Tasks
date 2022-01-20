using _2._1._2._CUSTOM_PAINT.Interfaces;

namespace _2._1._2._CUSTOM_PAINT.Classes
{
    public class User
    {
        private string _name;
        private IList<IFigure> _array;

        public string Name=>_name ;

        public User (string name)
        {
            _name = name;
            _array = new List<IFigure>();
        }

        public void GetInfo()
        {
            foreach(var figure in _array)
            {
                figure.Output();
            }
        }
        
        public void Clear()
        {
            _array.Clear();
        }

        public void AddFigure(Figures figure)
        {
            IFigure temp = SwitchFigure(figure);
            temp.SetParam();
            _array.Add(temp);
        }

        private IFigure SwitchFigure(Figures figure) => figure switch
        {
            Figures.Circle => new Circle(),
            Figures.Round => new Round(),
            Figures.Ring => new Ring(),
            Figures.Line => new Line(),
            Figures.Triangle => new Triangle(),
            Figures.Rectangle => new Rectangle(),
            Figures.Square => new Square(),
        };

        public enum Figures
        {
            //None=0,
            Circle=1,
            Round=2,
            Ring=3,
            Line=4,
            Triangle=5,
            Rectangle=6,
            Square =7
        }

    }
}
