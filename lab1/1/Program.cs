using System;

namespace Lab1
{
    internal class Program
    {
        static void Error()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nНекоректний ввiд!");
            Console.ResetColor();
            Console.WriteLine("\nНатиснiть будь-яку кнопку для закриття консолi..");
            Console.ReadKey();
        }
        static void End()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nНатиснiть будь-яку клавiшу для закриття консолi..");
            Console.ReadKey();
        }
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Введiть час:\t");
            Console.ResetColor();
            string timeInStr = Console.ReadLine();
            string[] strTimeInArr = timeInStr.Split(':');
            int[] intTimeInArr = new int[strTimeInArr.Length];
            if (strTimeInArr.Length != 3)
                Error();
            else
            {
                for (int i = 0; i < intTimeInArr.Length; i++)
                    intTimeInArr[i] = Convert.ToInt32(strTimeInArr[i]);

                Time time = new Time(intTimeInArr[0], intTimeInArr[1], intTimeInArr[2]);
                time.ShowTime();
                TimeSerialization.Serialize(time);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nБажаєте внести додатковi змiни?");
                Console.ResetColor();

                int up = Console.CursorTop;
                int y = up;

                Console.WriteLine("Змiнити кiлькiсть годин.");
                Console.WriteLine("Змiнити кiлькiсть хвилин.");
                Console.WriteLine("Змiнити кiлькiсть секунд.");
                Console.WriteLine("Залишити все як є.");

                int down = Console.CursorTop;
                Console.CursorSize = 100;
                Console.CursorTop = up;

                ConsoleKey key;
                while ((key = Console.ReadKey(true).Key) != ConsoleKey.Enter)
                {
                    if (key == ConsoleKey.UpArrow)
                    {
                        if (y > up)
                        {
                            y--;
                            Console.CursorTop = y;
                        }
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        if (y < down - 1)
                        {
                            y++;
                            Console.CursorTop = y;
                        }
                    }
                }
                Console.CursorTop = down;

                if (y == up)
                {
                    Console.Write("\nЗмiнити кiлькiсть годин на..");
                    int plusHours = Convert.ToInt32(Console.ReadLine());
                    time.AddHours(plusHours);
                    time.ShowTime();
                }
                else if (y == up + 1)
                {
                    Console.Write("\nЗмiнити кiлькiсть хвилин на..");
                    int plusMinutes = Convert.ToInt32(Console.ReadLine());
                    time.AddMinutes(plusMinutes);
                    time.ShowTime();
                }
                else if (y == up + 2)
                {
                    Console.Write("\nЗмiнити кiлькiсть секунд на..");
                    int plusSeconds = Convert.ToInt32(Console.ReadLine());
                    time.AddSeconds(plusSeconds);
                    time.ShowTime();
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nБажаєте вiдктрити .json файл?(так|нi)\t");
                Console.ResetColor();
                string reply = Console.ReadLine();
                if (reply == "так")
                {
                    Time savedTime = TimeSerialization.Deserialize("file.json");
                    savedTime.ShowSavedTime();
                    End();
                }
                else if (reply == "нi")
                    End();
                else
                    Error();
            }
        }
    }
}
