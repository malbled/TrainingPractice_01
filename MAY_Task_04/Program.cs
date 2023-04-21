using System;

namespace MAY_Task_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region вступление
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ДОБРО ПОЖАЛОВАТЬ В ДОЛИНУ ТЕНЕЙ\n");
            Console.WriteLine("Здесь Вам предстоит сразиться с самым могущественным монстром в мире, а имя ему - ДЕМОГОРГОН\n" +
                "И только после смерти Демогоргона к вам придет покой\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Вы обладаете колдовским даром");
            Console.WriteLine("Помните закон Долины - Максимальное кол-во hp игрока - до 843\nТакже в Долине имеется бог Аби-Ранд, который выбирает, кто сделает первых ход в БИТВЕ\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Заклинания для атаки или лечения: \n\n" +
                "1. Меткий Удар - Бросок атаки по цели наносит 50 урона, отнимает 15hp игроку\n" +
                "2. Гнев Природы - Духи Долины оживляют деревья и наносят 100 урона Демогоргону, отнимает 30hp игроку\n" +
                "3. Мираж - Вы выглядете,звучите и пахните как Долина Теней, Демогорнон Вас не найдет! Вы востанавливаете себе 150hp\n" +
                "4. Благословление Удачи - Призывает Духа Долины - Таши, отнимает 80hp игроку\n" +
                "5. Яд Смеха Таши(может быть выполнено только после призыва Таши) - Таши воспринимает Демогоргона невероятно смешным, корчясь от смеха, наносит 150 урона Демогоргону");
            Console.ResetColor();
            #endregion
            Random random = new Random();
            int hpUser = random.Next(400, 599);//жизни игрока
            int hpDemon;//жизни демона
            do
            {
                hpDemon = random.Next(400, 600);
            } while (hpDemon < hpUser);//жизни демона должны быть больше в начале игры он же мощный
            int TurnOfEvents;
            TurnOfEvents = random.Next(1, 3);
            int couter = 0;//счетчик ход игры
            string userStep;//считать переменную для выбора заклинания
            bool Check = true;//перемнная проверки конца игры
            Console.WriteLine("\nДА НАЧНЁТСЯ БИТВА");
            OutPutStatistic(hpUser, hpDemon);
            int firstStep = random.Next(1, 3);//рандомируем кто ударит первым
            if (firstStep == 1)
            {
                couter = 1;
                int lossUser = random.Next(20, 115);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{couter} ход ДЕМОГОРГОНА - {lossUser} урон по игроку");
                Console.ResetColor(); //демон нанес первый удар
                hpUser = hpUser - lossUser;
                OutPutStatistic(hpUser, hpDemon);
                //так как первым нанес удар демон мы отнимаем у игрока жизни у демона ничего не происходит и выводится информация
            }
            int crystal = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                couter = couter + 1;
                Console.Write($"\n{couter} ход(введите номер заклинания) >> ");
                userStep = Console.ReadLine();
                Console.ResetColor();
                switch (userStep)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nМеткий Удар по ДЕМОГОРГОНУ");
                        Console.ResetColor();
                        if (hpUser - 15 <= 0)
                        {
                            FatalError(out hpUser, out Check);
                            OutPutStatistic(hpUser, hpDemon);
                        }
                        else
                        {
                            hpUser = hpUser - 15;
                            if (hpDemon - 50 <= 0)
                            {
                                hpDemon = 0;
                                Check = false;
                                break;
                            }
                            else
                            {
                                hpDemon = hpDemon - 50;
                            }
                            OutPutStatistic(hpUser, hpDemon);
                        }
                        couter = couter + 1;
                        DemonStep(random, ref hpUser, couter, ref Check);
                        OutPutStatistic(hpUser, hpDemon);
                        break;


                    case "2":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nДерево завалило ДЕМОГОРГОНА");
                        Console.ResetColor();
                        if (hpUser - 30 <= 0)
                        {
                            FatalError(out hpUser, out Check);
                            OutPutStatistic(hpUser, hpDemon);
                        }
                        else
                        {
                            hpUser = hpUser - 30;
                            if (hpDemon - 100 <= 0)
                            {
                                hpDemon = 0;
                                Check = false;
                                break;
                            }
                            else
                            {
                                hpDemon = hpDemon - 100;
                            }
                            OutPutStatistic(hpUser, hpDemon);
                        }
                        couter = couter + 1;
                        DemonStep(random, ref hpUser, couter, ref Check);
                        OutPutStatistic(hpUser, hpDemon);
                        break;

                    case "3":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nВы в состояние МИРАЖ");
                        Console.ResetColor();
                        if (hpUser + 150 >= 843 && hpDemon + 50 >= 843)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\nМаксимальный hp!\nВы не скрылись в МИРАЖЕ");
                            Console.ResetColor();
                            OutPutStatistic(hpUser, hpDemon);
                        }
                        else
                        {
                            hpUser = hpUser + 150;
                            hpDemon = hpDemon + 50;
                            OutPutStatistic(hpUser, hpDemon);
                        }
                        couter = couter + 1;
                        DemonStep(random, ref hpUser, couter, ref Check);
                        OutPutStatistic(hpUser, hpDemon);
                        break;

                    case "4":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n...Призыв Духа Таши...");
                        Console.ResetColor();
                        if (hpUser - 80 <= 0)
                        {
                            FatalError(out hpUser, out Check);
                            OutPutStatistic(hpUser, hpDemon);
                        }
                        else
                        {
                            hpUser = hpUser - 80;
                            crystal = crystal + 1;
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine($"\nУ вас есть #{crystal} УДАЧИ\nВы можете ее применить для вызова 5 заклинания!");
                            Console.ResetColor();
                            OutPutStatistic(hpUser, hpDemon);
                        }
                        couter = couter + 1;
                        DemonStep(random, ref hpUser, couter, ref Check);
                        OutPutStatistic(hpUser, hpDemon);
                        break;
                    case "5":
                        if (crystal == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nУ Вас нет Удачи, чтобы воспользоваться этим Заклинаием");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nЯд Духа Таши наносит мощный урон по ДЕМОГОРГОНУ");
                            Console.ResetColor();
                            crystal = crystal - 1;
                            if (hpDemon - 150 <= 0)
                            {
                                Check = false;
                                hpDemon = 0;
                            }
                            else
                            {
                                hpDemon = hpDemon - 150;
                                OutPutStatistic(hpUser, hpDemon);
                            }
                            if (TurnOfEvents == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\nНеожиданный поворот событий\n\n\nДЕМОГОРГОН сильно разозлился из-за Ядовитой насмешки Таши и пришёл в черной магии\n" +
                                    "Всю Долину Теней(в том числе и тебя) настиг СНАРЯД ХАОСА. Всё живое погибло в Долине и пришла Вечная Тьма\nА ДЕМОГОРГОН спрятался в Сфере Бури и восстанавливает силы");
                                Check = false;
                                hpUser = 0;
                            }
                        }
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Ты плохо владеешь знаниями по заклинанию, поэтому ДЕМОГОРГОН нанесет удар");
                        Console.ResetColor();
                        couter = couter + 1;
                        DemonStep(random, ref hpUser, couter, ref Check);
                        OutPutStatistic(hpUser, hpDemon);
                        break;
                }
            } while (Check);
            if (hpUser == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n▓▓▓▓▓ ВЫ ПРОИГРАЛИ ▓▓▓▓▓");
            }
            if (hpDemon == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\n▓▓▓▓▓ ВЫ ВЫИГРАЛИ ▓▓▓▓▓");
            }
            Console.ReadKey();
        }

        private static void FatalError(out int hpUser, out bool Check)
        {
            Check = false;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nВам не хватило hp, чтобы сделать удар и ВЫ ПОГИБЛИ");
            Console.ResetColor();
            hpUser = 0;
        }

        private static void DemonStep(Random random, ref int hpUser, int couter, ref bool Check)
        {
            int lossUser = random.Next(20, 115);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{couter} ход ДЕМОГОРГОНА - {lossUser} урон по игроку");
            Console.ResetColor();
            if (hpUser - lossUser <= 0)
            {
                hpUser = 0;
                Check = false;
            }
            else
            {
                hpUser = hpUser - lossUser;
            }
        }

        private static void OutPutStatistic(int hpUser, int hpDemon)
        {
            Console.WriteLine("\nСостояние:");
            Console.Write($"Health Points(hp) ИГРОКА - {hpUser}");
            Console.WriteLine($"\nHealth Points(hp) ДЕМОГОРГОНА - {hpDemon}");
        }
    }
}

