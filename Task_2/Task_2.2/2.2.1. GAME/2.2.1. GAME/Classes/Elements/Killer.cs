namespace _2._2._1._GAME.Classes.Elements
{
    public class Killer : MovableElement
    {
        public override ConsoleColor Color { get; } = ConsoleColor.Red;
        public override char Name { get; } = 'K';
        public Killer(int x, int y) : base(x, y) { }
    }
}
