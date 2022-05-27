/*Задача 72: Заданы 2 массива: info и data. В массиве info хранятся двоичные 
представления нескольких чисел (без разделителя). В массиве data хранится 
информация о количестве бит, которые занимают числа из массива info. 
Напишите программу, которая составит массив десятичных представлений чисел 
3 массива data с учётом информации из массива info.
входные данные:
data = {0, 1, 1, 1, 1, 0, 0, 0, 1 }
info = {2, 3, 3, 1 }
выходные данные:
1, 7, 0, 1
*/

int[] data = { 0, 1, 1, 1, 1, 0, 0, 0, 1 };
int[] info = { 2, 3, 3, 1 };
int[] output = new int[info.Length];

BinaryToDecimal(data, info, output);
Console.WriteLine();
Console.WriteLine("Массив с двоичными представлениями нескольких чисел (без разделителя):");
PrintArray(data);
Console.WriteLine();
Console.WriteLine("Массив с информацией о количестве бит, которые занимают числа из массива выше:");
PrintArray(info);
Console.WriteLine();
Console.WriteLine("Массив с выводом десятичных представлений чисел верхнего массива:");
PrintArray(output);
Console.WriteLine();
Console.WriteLine();

void BinaryToDecimal(int[] arrayBinary, int[] arrayBit, int[] arrayOutput)
{
    int count = 0;

    for (int i = 0; i < arrayBit.Length; i++)
    {
        string temp = String.Empty;
        for (int j = 0; j < info[i]; j++)
        {
            temp += arrayBinary[j + count];
        }
        arrayOutput[i] = Convert.ToInt32(temp);
        count += info[i];

        int number = 0;
        temp = Convert.ToString(arrayOutput[i]);
        for (int j = 0; j < temp.Length; j++)      
        {                                          
            number += Convert.ToInt32(Math.Pow(2, j) * Convert.ToDouble(Convert.ToString(temp[j])));
        }
        arrayOutput[i] = Convert.ToInt32(number);
        number = 0;
    }
}

void PrintArray(int[] array)
{
    Console.Write("{ ");
    for (int i = 0; i < array.Length - 1; i++)
    {
        Console.Write(array[i] + ", ");
    }
    Console.Write(array[array.Length - 1] + " }");
}