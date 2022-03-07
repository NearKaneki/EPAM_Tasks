Console.Write("Input number of people: ");
int numberPeople = 0;
while (numberPeople == 0)
{
    int temp;
    CheckInput(out temp, "number of people");
    if (temp <= 0)
    {
        Console.Write("Number of people must be positive. Input number of people: ");
        continue;
    }
    numberPeople = temp;
}

Console.Write("Input strikeout number: ");
int strikeoutNumber = 0;
while (strikeoutNumber == 0)
{
    int temp;
    CheckInput(out temp, "strikeout number");
    if (temp > numberPeople)
    {
        Console.Write("Strikeout number greater than number of people. Input strikeout number: ");
        continue;
    }
    if (temp <= 0)
    {
        Console.Write("Strikeout number must be positive. Input strikeout number: ");
        continue;
    }
    strikeoutNumber = temp;
}

for (int i = 1; i <= numberPeople - strikeoutNumber + 1; i++)
{
    Console.WriteLine($"Round {i}. One person struck out. Humans left: {numberPeople - i}");
}

Console.WriteLine("Game over. Can’t rule out more people.");

static void CheckInput(out int temp, string item)
{
    while (!int.TryParse(Console.ReadLine(), out temp))
    {
        Console.Write($"Wrong input. Input {item}: ");
    }
}