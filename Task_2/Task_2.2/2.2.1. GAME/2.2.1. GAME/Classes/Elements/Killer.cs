namespace _2._2._1._GAME.Classes.Elements
{
    public class Killer : Element
    {
        public override ConsoleColor Color { get; } = ConsoleColor.Red;
        public override char Name { get; } = 'K';
        public Killer(int x, int y)
        {
            Coord = new Point(x, y);
        }

        public void Move(int x, int y)
        {
            Coord.X = x;
            Coord.Y = y;
        }
    }
}
