namespace _2._2._1._GAME.Classes.Elements
{
    public class Money : Element
    {
        public override ConsoleColor Color { get; } = ConsoleColor.Green;
        public override char Name { get; } = 'M';
        public Money(int x, int y) : base(x, y) { }
    }
}
