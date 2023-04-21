using System;

namespace MAY_Task_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userEnter;
            int count = 0;


            for (int i = 1; i > count; i++)
            {
                Console.Write("Напишите что-нибудь: ");
                userEnter = Console.ReadLine();

                if (userEnter.ToLower() == "exit")
                {
                    break;
                }
                Console.WriteLine("\nДля выхода из программы, напишите 'exit'\n");
            }
        }
    }
}
