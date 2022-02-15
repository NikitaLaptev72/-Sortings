using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сортировки
{
    class Program
    {
        static int[] CreationArray(int[] keys, int count)
        {
            Random rnd = new Random();
            keys = new int[count];
            for (int i = 0; i < keys.Count(); i++)
            {
                keys[i] = rnd.Next(1, 150);
            }
            return keys;
        }

        static int[] ShellSort(int[] mass)
        {
            int i, j, step;
            int tmp;
            for (step = mass.Count() / 2; step > 0; step /= 2)
            {
                for (i = step; i < mass.Count(); i++)
                {
                    tmp = mass[i];
                    for (j = i; j >= step; j -= step)
                    {
                        if (tmp < mass[j - step])
                        {
                            mass[j] = mass[j - step];
                        }
                        else
                        {
                            break;
                        }
                    }
                    mass[j] = tmp;
                }
            }
            return mass;
        }

        static void Main(string[] args)
        {
            int count = 20;
            int[] mass = new int[count];

            mass = CreationArray(mass, count);
            Console.WriteLine("*********Сортировка Шелла*********");
            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < count; i++)
            {
                Console.Write(mass[i] + " ");
            }
            Console.WriteLine();
            mass = ShellSort(mass);
            Console.WriteLine("Отсортированный массив:");
            for (int i = 0; i < count; i++)
            {
                Console.Write(mass[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
