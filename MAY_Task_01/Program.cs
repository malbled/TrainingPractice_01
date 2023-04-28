using System;

namespace MAY_Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Введите количество имеющегося золота >> ");
            double Gold_count;
            string Str = Console.ReadLine();
            while (!double.TryParse(Str, out _))
            {
                Console.WriteLine("Неправильный ввод\n");
                Console.Write("Введите количество имеющегося золота >> ");
                Str = Console.ReadLine();
            }
            Gold_count = Convert.ToDouble(Str);
            Console.WriteLine();
            int Сrystal_price = 3;
            Console.WriteLine("Вы можете купить максимум " + Convert.ToInt32( Gold_count) / Сrystal_price + " кристалов по цене " + Сrystal_price + " за штуку");
            Console.Write("Сколько кристаллов вы хотите купить ? >> ");
            int Crystal_get = 0;
            Str = Console.ReadLine();
            while (!int.TryParse(Str, out _) || Convert.ToInt32(Str) < 0 || Convert.ToInt32(Str) > Convert.ToInt32(Gold_count) / Сrystal_price)
            {
                if (!int.TryParse(Str, out _))
                {
                    Console.WriteLine("Неправильный ввод\n");
                    Console.Write("Сколько кристаллов вы хотите купить ? >> ");
                    Str = Console.ReadLine();
                }
                if(Convert.ToInt32(Str) < 0)
                {
                    Console.WriteLine("Неправильный ввод\n");
                    Console.Write("Сколько кристаллов вы хотите купить ? >> ");
                    Str = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Вы можете купить максимум " + Convert.ToInt32(Gold_count) / Сrystal_price + " кристалов по цене " + Сrystal_price + " за штуку\n");
                    Console.Write("Сколько кристаллов вы хотите купить ? >> ");
                    Str = Console.ReadLine();
                }
            }
            Crystal_get = Convert.ToInt32(Str);
            Console.WriteLine();
            Console.WriteLine("Вы купили " + Crystal_get + " кристаллов.\nУ вас осталось " + (Gold_count - Crystal_get * Сrystal_price) + " золота");
            Console.ReadKey();
        }
    }
}
