using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_HW_16_07
{
    internal class AdditionalTask1
    {
        static Random random = new Random();
        static async Task Main(string[] args)
        {
            int[] array1 = new int[50];
            int[] array2 = new int[50];

            FillArrayRandom(array1);
            FillArrayRandom(array2);

            Console.WriteLine("Initial arrays:");

            Console.Write("First array: ");
            PrintArray(array1);

            Console.Write("Second array: ");
            PrintArray(array2);

            var sortedArray1Task = BubbleSortAsync(array1);
            var sortedArray2Task = InsertionSortAsync(array2);

            var sortedArray1 = await sortedArray1Task;
            var sortedArray2 = await sortedArray2Task;

            Console.WriteLine("\nSorted arrays:");

            Console.Write("First array: ");
            PrintArray(sortedArray1);

            Console.Write("Second array: ");
            PrintArray(sortedArray2);
        }
        static void FillArrayRandom(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(100);
            }
        }
        static async Task<int[]> BubbleSortAsync(int[] array)
        {
            return await Task.Run(() =>
            {
                BubbleSort(array);
                return array;
            });
        }

        static void BubbleSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
        }

        static async Task<int[]> InsertionSortAsync(int[] array)
        {
            return await Task.Run(() =>
            {
                InsertionSort(array);
                return array;
            });
        }

        static void InsertionSort(int[] array)
        {
            int n = array.Length;
            for (int i = 1; i < n; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }

        static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
