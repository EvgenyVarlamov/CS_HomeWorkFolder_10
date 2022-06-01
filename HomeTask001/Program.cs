/*Задача 73: Есть число N. Сколько групп M, можно получить при разбиении всех чисел на группы, 
так чтобы в одной группе все числа были взаимно просты (все числа в группе друг на друга не делятся)? 
Найдите M при заданном N и получите одно из разбиений на группы N ≤ 10²⁰. Можно использовать рекурсию.

Например, для N = 50, M получается 6
Группа 1: 1
Группа 2: 2 3 11 13 17 19 23 29 31 37 41 43 47
Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
Группа 4: 8 12 18 20 27 28 30 42 44 45 50
Группа 5: 7 16 24 36 40
Группа 6: 5 32 48

Или
Группа 1: 1
Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
Группа 4: 8 12 18 20 27 28 30 42 44 45 50
Группа 5: 16 24 36 40
Группа 6: 32 48
*/

long number = Input("Введите число N: ");
long groupQuantity = GroupCalculation(number);
long[,] array = FillGroup(number, groupQuantity);
SortingNumbersInGroupS(array);
PrintGroup(array);
Console.WriteLine();

int Input(string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

long GroupCalculation(long value)
{
    long check = 1;
    long count = 0;
    for (long i = 1; i <= value; i++)
    {
        if (i % check == 0)
        {
            count++;
            check = i;
        }
    }
    Console.WriteLine($"Итого {count} групп, в каждой из которых числа друг на друга не делятся");
    return count;
}

long[,] FillGroup(long value, long count)
{
    long[,] result = new long[count, value];

    for (long i = 0; i < count; i++)
    {
        for (long j = 0; j < value; j++)
        {
            result[i, 0] = Convert.ToInt64(Math.Pow(2, i));
            long temp = Convert.ToInt64(Math.Pow(2, i) + j);
            if (temp <= value)
            {
                result[i, j] = temp;
            }
        }
    }
    return result;
}

long[,] SortingNumbersInGroupS(long[,] result)
{
    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (long j = 0; j < result.GetLength(1); j++)
        {
            for (long k = 0; k < result.GetLength(1); k++)
            {
                for (long l = 0; l < result.GetLength(0); l++)
                {
                    if (i < l && result[i, j] == result[l, k])
                    {
                        result[l, k] = 0;
                    }
                }

                if (result[i, j] != 0 && result[i, j] != result[i, k] && result[i, k] % result[i, j] == 0)
                {
                    result[i, k] = 0;
                }

            }
        }
    }
    return result;
}

void PrintGroup(long[,] result)
{
    for (int i = 0; i < result.GetLength(0); i++)
    {
        Console.Write($"Группа {i + 1}: ");
        for (long j = 0; j < result.GetLength(1); j++)
        {
            if (result[i, j] != 0)
            {
                Console.Write(result[i, j] + " ");
            }
        }
        Console.WriteLine();
    }
}