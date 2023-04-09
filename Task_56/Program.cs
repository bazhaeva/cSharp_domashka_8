int m = GetUserNumber("Введите число строк матрицы: ");         // способ задания массива выбран произвольно
int n = GetUserNumber("Введите число столбцов матрицы: ");

int[,] matrix = GetMatrix(m, n, 0, 10);            // диапазон 0, 10 взят произвольно, для удобства проверки  
PrintArray(matrix);
int[] rowSum = RowSum(matrix);
int minSum = FindMinSum(rowSum);
//Console.WriteLine(String.Join(" ", rowSum));
Console.WriteLine($"Cтрока с наименьшей суммой элементов: {minSum}");




//-----------------Получение числа от пользователя

int GetUserNumber(string messageToUser)
{
    while (true)
    {
        Console.Write(messageToUser);
        if (int.TryParse(Console.ReadLine(), out int userNumber) && userNumber > 0)
            return userNumber;
        Console.WriteLine("Ошибка! Введите целое число больше нуля");
    }
}



//-----------------Заполнение двумерного массива

int[,] GetMatrix(int m, int n, int minValue, int maxValue)
{
    int[,] resultMatrix = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            resultMatrix[i, j] = new Random().Next(minValue, maxValue);
        }
    }
    return resultMatrix;
}



//--------------------------Вывод двумерного массива на экран

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]}  ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}



//----------------------Нахождение суммы по строкам

int[] RowSum(int[,] inArray)
{
    int[] resultArray = new int[inArray.GetLength(0)];
    int count = 0;
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            count += inArray[i, j];
        }
        resultArray[i] = count;

        count = 0;
    }
    return resultArray;
}



//----------------------Нахождение строки с минимальной суммой

int FindMinSum(int[] inArray)
{
    int minIndex = 0;
    for(int i=1; i<inArray.Length; i++)
    {
        if (inArray[i] < inArray[minIndex]) minIndex = i;
    }
return minIndex;
}