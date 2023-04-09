int m = GetUserNumber("Введите число слоев массива: ");         // способ задания массива выбран произвольно
int n = GetUserNumber("Введите число строк массива: ");
int l = GetUserNumber("Введите число столбцов массива: ");

int[,,] cube = GetCube(m, n, l);              
PrintArray(cube);



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




//-----------------Заполнение трехмерного массива

int[,,] GetCube(int m, int n, int l)
{
    int[,,] resultArray = new int[m, n, l];

    for (int i = 0; i < resultArray.GetLength(0); i++)
    {
        for (int j = 0; j < resultArray.GetLength(1); j++)
        {
            for (int k = 0; k < resultArray.GetLength(2); k++)
            {
                resultArray[i, j, k] = GetUnique(resultArray, 10, 99, i, j, k);

            }
        }
    }
    return resultArray;
}



//--------------------------Вывод трехмерного массива на экран

void PrintArray(int[,,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            for (int k = 0; k < inArray.GetLength(2); k++)
            {
                Console.Write($"{inArray[i, j, k]}({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}


//-------------------Генерация элементов массива без повторений
int GetUnique(int[,,] array, int min, int max, int i, int j, int k)
{
    int value = 0;
    bool exist = true;
    while (exist)
    {
        bool break1 = false;
        value = new Random().Next(min, max + 1);
        for (int i1 = 0; i1 < array.GetLength(0); i1++)
        {
            if (break1) break;
            for (int j1 = 0; j1 < array.GetLength(1); j1++)
            {
                if (break1) break;
                for (int k1 = 0; k1 < array.GetLength(2); k1++)
                {
                    if (array[i1, j1, k1] == value)
                    {
                    break1 = true;
                    break;
                    }
                    if (i1 == i && j1==j && k1 == k) exist = false;
                }
            }
        }

    }
    return value;
}