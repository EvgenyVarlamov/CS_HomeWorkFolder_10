/*Задача 74*: 4 друга должны посетить 12 пабов, в котором выпить по британской пинте (0,568 литра) 
пенного напитка. До каждого бара идти примерно 15-20 минут, каждый пьет пинту за 15 минут. 
У первого друга лимит выпитого 1.1 литра, у второго 1.5, у третьего 2.2 литра, у 4 - 3.3 литра, 
это их максимум. Необходимо выяснить, до скольки баров смогут дойти каждый из друзей
(Пройденное расстояние (в барах)), пока не упадет. И сколько всего времени будет потрачено на выпивку. */

int drinkPintSpeed = 15;
double time = 0;
double pint = 0.568;
int[] distance = { 15, 20 };
double[] limits = { 1.1, 1.5, 2.2, 3.5 };
double[] pubsPossibility = new double[limits.Length];

Console.WriteLine();
for (int i = 0; i < limits.Length; i++)
{
    int correct = 0;
    pubsPossibility[i] = limits[i] / pint;
    if (Convert.ToInt32(pubsPossibility[i]) > pubsPossibility[i])
    {
        correct = 0;
    }
    else
    {
        correct = 1;
    }
    Console.Write($"{i + 1}-й друг дойдет до {Math.Round(pubsPossibility[i], 0) + correct}-го паба и упадет в нём, осилив {Math.Round(pubsPossibility[i], 2)} пинты");
    Console.Write(" пенного за ");
    for (int j = 0; j < distance.Length; j++)
    {
        time = Math.Round((Math.Round(pubsPossibility[i], 0) + correct) * distance[j] + pubsPossibility[i] * drinkPintSpeed, 0);
        if (distance[j] % 2 == 0)
        {
            Console.Write("-");
        }
        Console.Write(time);
    }
    Console.Write(" минут(ы)");
    Console.WriteLine();
}
Console.WriteLine();