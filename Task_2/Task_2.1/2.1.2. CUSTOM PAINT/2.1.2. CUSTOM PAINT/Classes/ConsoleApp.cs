using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._2._CUSTOM_PAINT.Classes
{
    static public class ConsoleApp
    {
        static private List<User> _users = new List<User>();
        static private User _currentUser;
        static private int _action=0;

        static public void Start()
        {
            _currentUser = ChangeUser();
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

        static private User ChangeUser()
        {
            Console.Clear();
            Console.WriteLine("Введите имя пользователя");
            string name = Console.ReadLine();
            int ind = _users.FindIndex(x => x.Name == name);
            if (ind == -1)
            {
                return new User(name);
            }
            return _users[ind];
        }
        static private void GetAction()
        {
            Console.Write($"Текущий пользователь: {_currentUser.Name}\n" +
                $"1. Добавить фигуру\n" +
                $"2. Вывести фигуры\n" +
                $"3. Очистить холст\n" +
                $"4. Сменить пользователя\n" +
                $"5. Выйти из программы\n" +
                $"Введите номер действия: ");
            bool success = int.TryParse(Console.ReadLine(), out _action);
        }
        static private void DoAction()
        {
            switch (_action)
            {
                case 1:
                    Console.Write("1. Окружность\n" +
                        "2. Круг\n" +
                        "3. Кольцо\n" +
                        "4. Линия\n" +
                        "5. Треугольник\n" +
                        "6. Прямоугольник\n" +
                        "7. Квадрат\n" +
                        "Выберите номер фигуры: ");
                    int ind;
                    bool success = int.TryParse(Console.ReadLine(), out ind);
                    _currentUser.AddFigure((User.Figures)ind);
                    Console.WriteLine("Фигура добавлена");
                    break;
                case 2:
                    _currentUser.GetInfo();
                    Console.WriteLine("Вывод фигур завершен");
                    break;
                case 3:
                    _currentUser.Clear();
                    Console.WriteLine("Холст отчищен");
                    break;
                case 4:
                    _currentUser=ChangeUser();
                    break;
                default:
                    break;
            }
        }
    }
}
