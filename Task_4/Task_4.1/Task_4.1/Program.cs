using Task_4._1;

int rejim;
bool check;
do
{
    Console.Write($"Выберите режим работы:{Environment.NewLine}" +
    $"1.Режим наблюдения{Environment.NewLine}" +
    $"2.Режим отката изменений{Environment.NewLine}" +
    $"Введите номер режима и нажмите Enter{Environment.NewLine}");
    check = int.TryParse(Console.ReadLine(), out rejim);
}
while (!(check && (rejim == 1 || rejim == 2)));

GIT git = new GIT();
if (rejim == 1)
{
    git.StartWatcher();
}
else
{
    DateTime time=DateTime.Now;
    Console.WriteLine("Введите дату и время к которому вы хотите вернуть папку " +
        "в формате год\\месяц\\день часы:минуты:секунды");
    do
    {
        string[] str = Console.ReadLine().Split(' ', '/', ':');
        check = true;
        try
        {
            time = new DateTime(int.Parse(str[0]), int.Parse(str[1]), int.Parse(str[2]),
                    int.Parse(str[3]), int.Parse(str[4]), int.Parse(str[5]));
        }
        catch
        {
            Console.WriteLine("Что то введено не верно. Попробуйте еще раз");
            check = false;
        }
    }
    while (!check);

    git.BackupMod(time);
}
git.SaveInfo();