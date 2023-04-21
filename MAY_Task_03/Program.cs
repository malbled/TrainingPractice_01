using System;

namespace MAY_Task_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "root3393";
            string userEnter;
            int attempts = 3;
            for (int i = 0; i < attempts; i++)
            {
                Console.Write("Введите пароль: ");
                userEnter = Console.ReadLine();
                if (userEnter == password)
                {
                    Console.WriteLine("\nСекретное сообщение\n? Пельмень это Сатурн ?");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Вы ввели неверный пароль, у вас осталось >> " + (attempts - i - 1) + " попытка");
                }
            }
        }
    }
}
