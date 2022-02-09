namespace _2._2._1._GAME.Classes.Elements
{
    public class Man : MovableElement
    {
        public int Money { get; set; } = 0;
        public override ConsoleColor Color { get; } = ConsoleColor.DarkGray;
        public override char Name { get; } = 'I';
        public Man(int x, int y) : base(x, y) { }
    }
}
