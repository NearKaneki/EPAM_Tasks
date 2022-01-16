static void infoFont(bool[] info)
{
    Console.Write("Параметры надписи:");
    if (info.Count(x=>x) == 0)
    {
        Console.WriteLine(" None");
        return;
    }
    if (info[0])
    {
        Console.Write(" Bold");
    }
    if (info[1])
    {
        Console.Write(" Italic");
    }
    if (info[2])
    {
        Console.Write(" Underline");
    }
    Console.WriteLine();
}

static void changeParameters(bool[] info)
{
    Console.WriteLine("Введите:\n\t1: bold\n\t2: italic\n\t3: underline\n\t4: Завершить программу");
    int cur;
    int.TryParse(Console.ReadLine(), out cur);
    if (cur >= 1 && cur <= 4)
    {
        info[cur - 1] =!info[cur - 1];
        return;
    }
    else
    {
        throw new Exception("Incorrect input");
    }
}

bool[] parameters = new bool[4];
while (!parameters[3])
{
    infoFont(parameters);
    changeParameters(parameters);
}