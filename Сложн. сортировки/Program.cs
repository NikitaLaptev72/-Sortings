using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сложн.сортировки
{
    class Program
    {
        //Сортировка слиянием - требуется большая память
        public static void Merger(int[] mass, int k, int q)
        {
            // k – нижняя граница упорядоченного фрагмента
            // q – верхняя граница фрагмента
            int i, j, t, mid;
            int[] d = new int[20];
            i = k;
            mid = k + (q - k) / 2;
            j = mid + 1;
            t = 1;
            while (i <= mid && j <= q)
            {
                if (mass[i] <= mass[j])
                {
                    d[t] = mass[i]; i++;
                }
                else
                {
                    d[t] = mass[j]; j++;
                }
                t++;
            }
            // Один из фрагментов обработан полностью, осталось перенести в D остаток другого фрагмента
            while (i <= mid)
            {
                d[t] = mass[i]; i++; t++;
            }
            while (j <= q)
            {
                d[t] = mass[j]; j++; t++;
            }

            for (i = 1; i <= t - 1; i++)
            {
                mass[k + i - 1] = d[i];
            }
        }

        // Рекурсивная реализация сортировки слиянием 
        public static int[] Sort_Merger(int[] mass, int i, int j)
        {
            int t;
            if (i < j)
            {
                // Обрабатываемый фрагмент массива состоит более, чем из одного элемента
                if (j - i == 1)
                {
                    if (mass[j] < mass[i])
                    // Обрабатываемый фрагмент массива состоит из двух элементов*)
                    {
                        t = mass[i]; mass[i] = mass[j]; mass[j] = t;
                    };
                }
                else
                {
                    // Разбиваем заданный фрагмент на два
                    Sort_Merger(mass, i, i + (j - i) / 2); // рекурсивные вызовы процедуры Sort_Sl
                    Sort_Merger(mass, i + (j - i) / 2 + 1, j);
                    Merger(mass, i, j);
                }
            }
            return mass;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("*********Сортировка слиянием*********");
            Random rnd = new Random();
            Console.WriteLine("Исходный массив:");
            int[] a = new int[20];
            int n = 19;
            for (int i = 0; i < n; i++)
            {
                a[i] = rnd.Next(1, 150);
                Console.Write(a[i] + " ");
            }
            Sort_Merger(a, 0, n - 1);
            Console.WriteLine();
            Console.WriteLine("Отсортированный массив:"); ;
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
