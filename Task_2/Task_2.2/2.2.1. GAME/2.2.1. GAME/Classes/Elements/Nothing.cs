namespace _2._2._1._GAME.Classes.Elements
{
    public class Nothing : Element
    {
        public override ConsoleColor Color { get; } = ConsoleColor.White;
        public override char Name { get; } = ' ';
        public Nothing(int x, int y) : base(x, y) { }
    }
}
