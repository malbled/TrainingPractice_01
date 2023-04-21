using System;
using System.Linq;

namespace MAY_Task_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива >> ");
            int n_mas;
            string Str = Console.ReadLine();
            while (!int.TryParse(Str, out _))
            {
                Console.WriteLine("Неправильный ввод\n");
                Console.Write("Введите размер массива >> ");
                Str = Console.ReadLine();
            }
            n_mas = Convert.ToInt32(Str);
            int[] mas = new int[n_mas];
            Random rand = new Random();
            Console.WriteLine("\n↓ Исходный массив размером: " + n_mas + " ↓\n");
            for (int i = 0; i < n_mas; i++)
            {
                mas[i] = rand.Next(1, 50);
                Console.Write(mas[i] + " ");
            }
            Console.WriteLine("\n\n↓ Перемешанный массив ↓\n");
            Random random = new Random();
            mas = mas.OrderBy(x => random.Next()).ToArray();
            foreach (var i in mas)
            {
                Console.Write(i + " ");
            }
            Console.ReadKey();
        }
    }
}
