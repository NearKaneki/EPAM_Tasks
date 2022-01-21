namespace _2._2._1._GAME.Classes.Elements
{
    public class Man : Element
    {
        public int Money { get; set; } = 0;
        public override ConsoleColor Color { get; } = ConsoleColor.DarkGray;
        public override char Name { get; } = 'I';
        public Man(int x, int y)
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
