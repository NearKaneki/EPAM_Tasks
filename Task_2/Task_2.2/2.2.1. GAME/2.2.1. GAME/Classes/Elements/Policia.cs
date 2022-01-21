namespace _2._2._1._GAME.Classes.Elements
{
    public class Policia : Element
    {
        public override ConsoleColor Color { get; } = ConsoleColor.Blue;
        public override char Name { get; } = 'P';
        public Policia(int x, int y)
        {
            Coord = new Point(x, y);
        }
    }
}
