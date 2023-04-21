using System;

namespace MAY_Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Введите количество имеющегося золота >> ");
            int Gold_count;
            string Str = Console.ReadLine();
            while (!int.TryParse(Str, out _))
            {
                Console.WriteLine("Неправильный ввод\n");
                Console.Write("Введите количество имеющегося золота >> ");
                Str = Console.ReadLine();
            }
            Gold_count = Convert.ToInt32(Str);
            Console.WriteLine();
            int Сrystal_price = 3;
            Console.WriteLine("Вы можете купить максимум " + Gold_count / Сrystal_price + " кристалов по цене " + Сrystal_price + " за штуку");
            Console.Write("Сколько кристаллов вы хотите купить ? >> ");
            int Crystal_get;
            Str = Console.ReadLine();
            while (!int.TryParse(Str, out _) || Convert.ToInt32(Str) > Gold_count / Сrystal_price)
            {
                if (!int.TryParse(Str, out _))
                {
                    Console.WriteLine("Неправильный ввод\n");
                    Console.Write("Сколько кристаллов вы хотите купить ? >> ");
                    Str = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Вы можете купить максимум " + Gold_count / Сrystal_price + " кристалов по цене " + Сrystal_price + " за штуку\n");
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
