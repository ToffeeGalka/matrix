

namespace matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minValue = -10;
            int maxValue = 10;
            Console.WriteLine("Введите количество строк матрицы:");
            int arraySize = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов матрицы:");
            int arraySize2 = Convert.ToInt32(Console.ReadLine());

            int[,] nums = new int[arraySize, arraySize2];

            Random nums1 = new Random();

            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize2; j++)
                {
                    nums[i, j] = nums1.Next(minValue, maxValue + 1);
                    Console.Write("{0,4}", nums[i, j]);
                }
                Console.WriteLine();
            }
            int menu;
            while (true)
            {
                Console.WriteLine("Выберите пункт меню, нажав соответствующую цифру от 1 до 5: \n" +
                    "1 - Найти количество положительных/отрицательных чисел в матрице \n" +
                    "2 - Сортировка элементов матрицы построчно по убыванию \n" +
                    "3 - Сортировка элементов матрицы построчно по возрастанию \n" +
                    "4 - Инверсия элементов матрицы построчно");
                if (int.TryParse(Console.ReadLine(), out menu))
                {
                    if (menu != 1 & menu != 2 & menu != 3 & menu != 4)
                    {
                        Console.WriteLine("Выберите предложенный пункт меню от 1 до 5!");
                        continue;
                    }
                    break;
                }
                continue;
            }
            // количество положительных и отрицательных элементов
            if (menu == 1)
            {
                int count1 = default;
                int count2 = default;
                for (int i = 0; i < arraySize; i++)
                {

                    for (int j = 0; j < arraySize2; j++)
                    {
                        if (nums[i, j] >= 0) count1++;
                        if (nums[i, j] < 0) count2++;
                    }
                }
                Console.WriteLine($"Количетсво положительных элементов в матрице: {count1} \nКоличетсво отрицательных элементов в матрице: {count2}  ");
            }
            // Сортировка элементов матрицы построчно по убыванию
            if (menu == 2)
            {
                for (int i = 0; i < nums.GetLength(0); i++)
                {
                    for (int j = 0; j < nums.GetLength(1); j++)
                    {
                        bool isSorted = false;
                        while (!isSorted)
                        {
                            isSorted = true; for (int k = 0; k < nums.GetLength(1) - 1; k++)
                            {
                                if (nums[i, k] < nums[i, k + 1])
                                {
                                    (nums[i, k], nums[i, k + 1]) = (nums[i, k + 1], nums[i, k]);
                                    isSorted = false;
                                }
                            }
                        }
                        Console.Write("{0,4}", nums[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            // Сортировка элементов матрицы построчно по возрастанию
            if (menu == 3)
            {
                for (int i = 0; i < nums.GetLength(0); i++)
                {
                    for (int j = 0; j < nums.GetLength(1); j++)
                    {
                        bool isSorted = false;
                        while (!isSorted)
                        {
                            isSorted = true; for (int k = 0; k < nums.GetLength(1) - 1; k++)
                            {
                                if (nums[i, k] > nums[i, k + 1])
                                {
                                    (nums[i, k], nums[i, k + 1]) = (nums[i, k + 1], nums[i, k]);
                                    isSorted = false;
                                }
                            }
                        }
                        Console.Write("{0,4}", nums[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            // Инверсия элементов матрицы построчно
            if (menu == 4)
            {
                for (int i = 0; i < nums.GetLength(1)/2; i++)               
                    for (int j = 0; j < nums.GetLength(0); j++)
                    {
                        int inv = nums[j, i];
                        nums[j, i] = nums[j, nums.GetLength(1) - i - 1];
                        nums[j, nums.GetLength(1) - i - 1] = inv;
                    }
                    for (int i = 0; i < nums.GetLength(0); i++)
                    {
                        for (int j = 0; j < nums.GetLength(1); j++)
                        {
                            Console.Write("{0,4}", nums[i, j]);
                        }
                    Console.WriteLine();
                    }              
            }
        }
    }
}
