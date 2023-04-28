using System;
using System.Linq;
using System.Security.Cryptography;

namespace MAY_Task_07
{
    internal class Program
    {
        static int Next(RNGCryptoServiceProvider random)
        {
            byte[] randomInt = new byte[4];
            random.GetBytes(randomInt);
            return Convert.ToInt32(randomInt[0]);
        }
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
            RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
            mas = mas.OrderBy(x => Next(random)).ToArray();
            foreach (var i in mas)
            {
                Console.Write(i + " ");
            }
            Console.ReadKey();
        }
        
    }
}
