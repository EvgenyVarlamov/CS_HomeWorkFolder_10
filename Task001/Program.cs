/* Задача 70: Напишите программу, которая на вход принимает 
два числа и выдаёт первые N чисел, для которых каждое следующее 
равно сумме двух предыдущих. 
3 и 4, N = 5 -> 3 4 7 11 18
6 и 10, N = 4 -> 6 10 16 26

*/
int number1 = Input("Введите значение 1: ");
int number2 = Input("Введите значение 2: ");
int count = Input("Введите значение N: ");

for (int i = 0; i < count; i++)
{
    Console.Write(SumBetweenNumbers(number1, number2, i) + " ");
}
Console.WriteLine();

int Input(string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int SumBetweenNumbers(int numberFirst, int numberSecond, int numberCount)
 
{
    if (numberCount == 0)
    {
        return numberFirst;
    }
    else if (numberCount == 1)
    {
        return numberSecond;
    }
    else
    {
        return  SumBetweenNumbers(numberFirst, numberSecond, numberCount - 1) + SumBetweenNumbers(numberFirst, numberSecond, numberCount - 2);
    }
}