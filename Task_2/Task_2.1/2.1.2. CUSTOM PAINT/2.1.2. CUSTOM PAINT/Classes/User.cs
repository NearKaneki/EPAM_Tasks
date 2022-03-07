namespace _2._1._2._CUSTOM_PAINT.Classes
{
    public class User
    {
        public string Name { get; init; }
        private List<Figure> _array;

        public User(string name)
        {
            Name = name;
            _array = new List<Figure>();
        }

        public override string ToString()
        {
            string temp = "";
            foreach (var figure in _array)
            {
                temp += figure;
            }
            return temp;
        }

        public void Clear()
        {
            _array.Clear();
        }

        public void AddFigure(Figure figure)
        {
            _array.Add(figure);
        }
    }
}
