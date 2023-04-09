int m = GetUserNumber("Введите число строк массива: ");
int n = GetUserNumber("Введите число столбцов массива: ");

int[,] matrix = new int[m, n];
matrix = FillingBySpiral(matrix);
PrintArray(matrix);



//================================Методы

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


//--------------------------Заполнение по спирали

int[,] FillingBySpiral(int[,] matrix)
{
int x = 0;                // x, y = координаты ячейки матрицы, с которой начинается заполнение
int y = 0;
int el = 1;

while (el <= n * m)
{
    while (y + 1 < n)  
    {
        if (matrix[x, y] == 0)
        {
            matrix[x, y] = el;
            el++;
        }
        if (el > n * m || matrix[x, y + 1] != 0)
            break;                              // * Для заполнения последних строк/столбцов, если можно закончить раньше, не выполняя лишних проверок
        y++;
    }

    while (x + 1 < m)  
    {
        if (matrix[x, y] == 0)
        {
            matrix[x, y] = el;
            el++;
        }
        if (el > n * m || matrix[x + 1, y] != 0)  
            break;                              // Аналогично *
        x++;
    }

    while (y - 1 >= 0)  
    {
        if (matrix[x, y] == 0)
        {
            matrix[x, y] = el;
            el++;
        }
        if (el > n * m || matrix[x, y - 1] != 0)
            break;                             // Аналогично *
        y--;
    }

    while (x - 1 >= 1)  
    {
        if (matrix[x, y] == 0)
        {
            matrix[x, y] = el;
            el++;
        }
        if (el > n * m || matrix[x - 1, y] != 0)
            break;                              // Аналогично *
        x--;
    }

}
return matrix;
}