using CustomArrayEPAM;

CycledCustomArray<int> abs = new CycledCustomArray<int>();

abs.Add(2);
abs.Add(5);
abs.Add(6);

foreach (var item in abs)
{
    Console.WriteLine(item);
}
