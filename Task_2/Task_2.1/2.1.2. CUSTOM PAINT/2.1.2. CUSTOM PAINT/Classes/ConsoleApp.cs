namespace _2._1._2._CUSTOM_PAINT.Classes
{
    static public class ConsoleApp
    {
        static private List<User> _users = new List<User>();
        static private User _currentUser;
        static private int _action = 0;

        static public void Start()
        {
            ChangeUser();
            Console.Clear();
            while (_action != 5)
            {
                GetAction();
                DoAction();
                Console.WriteLine("Для продолжения нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            }

        }

        static private void ChangeUser()
        {
            Console.WriteLine("Введите имя пользователя");
            string name = Console.ReadLine();
            User temp = _users.FirstOrDefault(x => x.Name == name);
            if (temp == default(User))
            {
                temp = new User(name);
                _currentUser = temp;
                _users.Add(temp);
            }
            else
            {
                _currentUser = temp;
            }
        }

        static private void GetAction()
        {
            Console.Write($"Текущий пользователь: {_currentUser.Name}{Environment.NewLine}" +
                $"1. Добавить фигуру{Environment.NewLine}" +
                $"2. Вывести фигуры{Environment.NewLine}" +
                $"3. Очистить холст{Environment.NewLine}" +
                $"4. Сменить пользователя{Environment.NewLine}" +
                $"5. Выйти из программы{Environment.NewLine}" +
                $"Введите номер действия: ");
            string ab = Console.ReadLine();
            bool success = int.TryParse(ab, out _action);
        }

        static private void DoAction()
        {
            switch (_action)
            {
                case 1:
                    Console.Write($"1. Окружность{Environment.NewLine}" +
                        $"2. Круг{Environment.NewLine}" +
                        $"3. Кольцо{Environment.NewLine}" +
                        $"4. Линия{Environment.NewLine}" +
                        $"5. Треугольник{Environment.NewLine}" +
                        $"6. Прямоугольник{Environment.NewLine}" +
                        $"7. Квадрат{Environment.NewLine}" +
                        $"Выберите номер фигуры: ");
                    int ind;
                    bool success = int.TryParse(Console.ReadLine(), out ind);
                    _currentUser.AddFigure(CtorOfFigure((Figures)ind));
                    Console.WriteLine("Фигура добавлена");
                    break;
                case 2:
                    Console.WriteLine(_currentUser);
                    Console.WriteLine("Вывод фигур завершен");
                    break;
                case 3:
                    _currentUser.Clear();
                    Console.WriteLine("Холст отчищен");
                    break;
                case 4:
                    Console.Clear();
                    ChangeUser();
                    break;
                default:
                    break;
            }
        }

        private static Figure CtorOfFigure(Figures figure)
        {
            switch (figure)
            {
                case Figures.Circle:
                    Console.Write("Введите центр окружности (x y): ");
                    string[] coords = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    int x, y;
                    bool succed = int.TryParse(coords[0], out x);
                    succed = int.TryParse(coords[1], out y);
                    Console.Write("Введите радиус окружности : ");
                    int r;
                    succed = int.TryParse(Console.ReadLine(), out r);
                    return new Circle((x, y), r);
                case Figures.Round:
                    Console.Write("Введите центр круга (x y): ");
                    coords = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    succed = int.TryParse(coords[0], out x);
                    succed = int.TryParse(coords[1], out y);
                    Console.Write("Введите радиус круга : ");
                    succed = int.TryParse(Console.ReadLine(), out r);
                    return new Round((x, y), r);
                case Figures.Ring:
                    Console.Write("Введите центр кольца (x y): ");
                    coords = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    succed = int.TryParse(coords[0], out x);
                    succed = int.TryParse(coords[1], out y);
                    Console.Write("Введите радиус внутренней окружности : ");
                    succed = int.TryParse(Console.ReadLine(), out r);
                    Console.Write("Введите радиус внешней окружности : ");
                    int r2;
                    succed = int.TryParse(Console.ReadLine(), out r2);
                    return new Ring((x, y), r, r2);
                case Figures.Line:
                    Console.Write("Введите точку начала линии (x y): ");
                    coords = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    int xS, yS;
                    succed = int.TryParse(coords[0], out xS);
                    succed = int.TryParse(coords[1], out yS);
                    Console.Write("Введите точку конца линии (x y): ");
                    coords = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    int xE, yE;
                    succed = int.TryParse(coords[0], out xE);
                    succed = int.TryParse(coords[1], out yE);
                    return new Line((xS, yS), (xE, yE));
                case Figures.Triangle:
                    Console.Write("Введите точки треугольника (x1 y1 x2 y2 x3 y3): ");
                    coords = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    int x1, x2, x3, y1, y2, y3;
                    succed = int.TryParse(coords[0], out x1);
                    succed = int.TryParse(coords[1], out y1);
                    succed = int.TryParse(coords[2], out x2);
                    succed = int.TryParse(coords[3], out y2);
                    succed = int.TryParse(coords[4], out x3);
                    succed = int.TryParse(coords[5], out y3);
                    return new Triangle((x1, y1), (x2, y2), (x3, y3));
                case Figures.Rectangle:
                    Console.Write($"Введите три точки прямоугольника{Environment.NewLine}" +
                        $"Сначала нижнюю левую, затем верхнюю левую и в конце верхнюю правую{Environment.NewLine}" +
                        $"(x1 y1 x2 y2 x3 y3): ");
                    coords = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    succed = int.TryParse(coords[0], out x1);
                    succed = int.TryParse(coords[1], out y1);
                    succed = int.TryParse(coords[2], out x2);
                    succed = int.TryParse(coords[3], out y2);
                    succed = int.TryParse(coords[4], out x3);
                    succed = int.TryParse(coords[5], out y3);
                    return new Rectangle((x1, y1), (x2, y2), (x3, y3));
                case Figures.Square:
                    Console.Write($"Введите три точки квадрата{Environment.NewLine}" +
    $"Сначала нижнюю левую, затем верхнюю левую и в конце верхнюю правую{Environment.NewLine}" +
    $"(x1 y1 x2 y2 x3 y3): ");
                    coords = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    succed = int.TryParse(coords[0], out x1);
                    succed = int.TryParse(coords[1], out y1);
                    succed = int.TryParse(coords[2], out x2);
                    succed = int.TryParse(coords[3], out y2);
                    succed = int.TryParse(coords[4], out x3);
                    succed = int.TryParse(coords[5], out y3);
                    return new Square((x1, y1), (x2, y2), (x3, y3));
                default:
                    return null;
            }
        }

        public enum Figures
        {
            //None=0,
            Circle = 1,
            Round = 2,
            Ring = 3,
            Line = 4,
            Triangle = 5,
            Rectangle = 6,
            Square = 7
        }
    }
}
