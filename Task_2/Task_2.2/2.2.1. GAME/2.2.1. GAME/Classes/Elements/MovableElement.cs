namespace _2._2._1._GAME.Classes.Elements
{
    public abstract class MovableElement : Element
    {
        public MovableElement(int x, int y) : base(x, y) { }

        public void Move(int x, int y)
        {
            Coord.X = x;
            Coord.Y = y;
        }
    }
}
