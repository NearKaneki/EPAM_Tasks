using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._1._GAME.Classes.Elements
{
    public class Money: Element
    {
        public override ConsoleColor Color { get; } = ConsoleColor.Green;
        public override char Name { get; } = 'M';
        public Money(int x, int y)
        {
            Coord = new Point(x, y);
        }

    }
}
