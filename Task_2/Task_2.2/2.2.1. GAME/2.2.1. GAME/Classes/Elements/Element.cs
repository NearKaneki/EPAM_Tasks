namespace _2._2._1._GAME.Classes.Elements
{
    public abstract class Element
    {
        public Point Coord { get; protected set; }
        public virtual ConsoleColor Color { get; }
        public virtual char Name { get; }

        public Element(int x, int y)
        {
            Coord = new Point(x, y);
        }
    }
}
