using _2._2._1._GAME.Classes.Elements;

namespace _2._2._1._GAME.Classes
{
    static public class Game
    {
        private const int _length = 20;
        private const int _weight = 10;
        private const int _countKillers = 10;
        private const int _countMoney = 20;
        private const int _countPolicia = 4;
        static private int _collectMoney = _countMoney;
        static private Element[,] _field = new Element[_weight, _length];
        static private List<Killer> _killers = new List<Killer>();
        static private List<Policia> _policia = new List<Policia>();
        static private List<Money> _money = new List<Money>();
        static private bool _died = false;
        static private bool _win = false;
        static private ConsoleKey _curKey;
        static private Man _man = new Man(0, 0);

        static public void Start()
        {
            WelcomeText();
            Console.Clear();
            GenerateField();
            ShowField();
            while (!_died)
            {
                ReadKey();
                MoveMan();
                FirstCheck();
                if (_died)
                {
                    Console.Clear();
                    Console.WriteLine("Вас убили!!!");
                    return;
                }
                if (_win)
                {
                    Console.Clear();
                    Console.WriteLine($"Вы набрали {_man.Money}$ ");
                    return;
                }
                MoveKillers();
                SecondCheck();
                if (_died)
                {
                    Console.Clear();
                    Console.WriteLine("Вас убили!!!");
                    return;
                }
                ReGenerateField();
                Console.Clear();
                ShowField();
            }


        }

        static private void WelcomeText()
        {
            Console.WriteLine($"Цель игры: собрать все деньги и уйти с ними{Environment.NewLine}" +
                $"Правила игры:{Environment.NewLine}" +
                $"1.Если вы зашли в полицию, то вы появитесь в стартовой точке и у вас заберут все деньги{Environment.NewLine}" +
                $"2.Если вы будете в одной клетке с убийцей, он вас убьет{Environment.NewLine}" +
                $"3.Если убийца встанет на доллар, то он заберет его себе.{Environment.NewLine}" +
                $"4.Если убийца убийца зайдет в полицию, то на одного убийцу станет меньше{Environment.NewLine}" +
                $"5.Для того, чтобы выйти вы должны встать в крайнюю правую клетку, но вы не сможете выйти пока на поле будут деньги{Environment.NewLine}" +
                $"Нажмите любую клавишу, чтобы продолжить...{Environment.NewLine}");
            Console.ReadKey();
        }

        static private void GenerateField()
        {
            for (int i = 0; i < _weight; i++)
            {
                for (int j = 0; j < _length; j++)
                {
                    _field[i, j] = new Nothing(i, j);
                }
            }
            _field[0, 0] = _man;
            Random r = new Random();
            for (int i = 0; i < _countKillers; i++)
            {
                int xR = r.Next(0, _weight);
                int yR = r.Next(0, _length);
                if (_field[xR, yR] is Nothing)
                {
                    Killer temp = new Killer(xR, yR);
                    _field[xR, yR] = temp;
                    _killers.Add(temp);
                }
                else
                {
                    --i;
                }
            }
            for (int i = 0; i < _countMoney; i++)
            {
                int xR = r.Next(0, _weight);
                int yR = r.Next(0, _length);
                if (_field[xR, yR] is Nothing)
                {
                    Money temp = new Money(xR, yR);
                    _field[xR, yR] = temp;
                    _money.Add(temp);
                }
                else
                {
                    --i;
                }
            }
            for (int i = 0; i < _countPolicia; i++)
            {
                int xR = r.Next(0, _weight);
                int yR = r.Next(0, _length);
                if (_field[xR, yR] is Nothing)
                {
                    Policia temp = new Policia(xR, yR);
                    _field[xR, yR] = temp;
                    _policia.Add(temp);
                }
                else
                {
                    --i;
                }
            }
        }

        static private void ShowField()
        {
            Console.BackgroundColor = ConsoleColor.White;
            for (int i = 0; i < _weight; i++)
            {
                for (int j = 0; j < _length; j++)
                {
                    Console.ForegroundColor = _field[i, j].Color;
                    Console.Write(_field[i, j].Name);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        static private void ReadKey()
        {
            List<ConsoleKey> need = new List<ConsoleKey>() { ConsoleKey.W, ConsoleKey.A, ConsoleKey.S, ConsoleKey.D };
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();
            }
            while (!need.Contains(key.Key));
            _curKey = key.Key;
        }

        static private void MoveMan()
        {
            switch (_curKey)
            {
                case ConsoleKey.W:
                    if (_man.Coord.X - 1 >= 0)
                    {
                        _man.Coord.X -= 1;
                    }
                    break;
                case ConsoleKey.A:
                    if (_man.Coord.Y - 1 >= 0)
                    {
                        _man.Coord.Y -= 1;
                    }
                    break;
                case ConsoleKey.S:
                    if (_man.Coord.X + 1 < _weight)
                    {
                        _man.Coord.X += 1;
                    }
                    break;
                case ConsoleKey.D:
                    if (_man.Coord.Y + 1 < _length)
                    {
                        _man.Coord.Y += 1;
                    }
                    break;
                default:
                    break;
            }
        }

        static private void FirstCheck()
        {
            if (_field[_man.Coord.X, _man.Coord.Y] is Killer)
            {
                _died = true;
                return;
            }
            if (_field[_man.Coord.X, _man.Coord.Y] is Policia)
            {
                _collectMoney -= _man.Money;
                _man.Money = 0;
                _man.Coord.X = 0;
                _man.Coord.Y = 0;
                return;
            }
            if (_field[_man.Coord.X, _man.Coord.Y] is Money)
            {
                _man.Money += 1;
                return;
            }
            if (_man.Coord.Y == _length - 1 && _man.Coord.X == _weight - 1)
            {
                if (_collectMoney == _man.Money)
                {
                    _win = true;
                }
            }
        }

        static private void MoveKillers()
        {
            foreach (Killer killer in _killers)
            {
                Random r = new Random();
                int xR = r.Next(-1, 2);
                int yR = r.Next(-1, 2);
                if (killer.Coord.X + xR >= 0 && killer.Coord.X + xR < _weight)
                {
                    killer.Coord.X += xR;
                }
                if (killer.Coord.Y + yR >= 0 && killer.Coord.Y + yR < _length)
                {
                    killer.Coord.Y += yR;
                }
            }
        }

        static private void SecondCheck()
        {
            foreach (Killer killer in _killers)
            {
                if (killer.Coord.X == _man.Coord.X && killer.Coord.Y == _man.Coord.Y)
                {
                    _died = true;
                }
            }
        }

        static private void ReGenerateField()
        {
            for (int i = 0; i < _weight; i++)
            {
                for (int j = 0; j < _length; j++)
                {
                    _field[i, j] = new Nothing(i, j);
                }
            }

            foreach (Policia policia in _policia)
            {
                _field[policia.Coord.X, policia.Coord.Y] = policia;
            }
            for (int i = 0; i < _killers.Count; i++)
            {
                if (_field[_killers[i].Coord.X, _killers[i].Coord.Y] is Policia)
                {
                    _killers.Remove(_killers[i]);
                    --i;
                    continue;
                }
                _field[_killers[i].Coord.X, _killers[i].Coord.Y] = _killers[i];
            }
            _field[_man.Coord.X, _man.Coord.Y] = _man;
            for (int i = 0; i < _money.Count; i++)
            {
                if (_field[_money[i].Coord.X, _money[i].Coord.Y] is Killer)
                {
                    _money.Remove(_money[i]);
                    --i;
                    _collectMoney -= 1;
                    continue;
                }
                if (_field[_money[i].Coord.X, _money[i].Coord.Y] is Man)
                {
                    _money.Remove(_money[i]);
                    --i;
                    continue;
                }
                _field[_money[i].Coord.X, _money[i].Coord.Y] = _money[i];
            }

        }
    }

}

