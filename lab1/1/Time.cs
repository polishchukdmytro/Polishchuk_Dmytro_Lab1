using System;

namespace Lab1
{
    internal class Time
    {
        int hours;
        public int Hours { get { return hours; } }
        int minutes;
        public int Minutes { get { return minutes; } }
        int seconds;
        public int Seconds { get { return seconds; } }
        public Time(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            if (hours > 23 || hours < 0 || minutes > 59 || minutes < 0 || seconds > 59 || seconds < 0)
                Error();
        }
        public void ShowTime()
        {
            Console.WriteLine($"\nВстановлений час: {hours}:{minutes}:{seconds}");
        }
        public void ShowSavedTime()
        {
            Console.WriteLine($"\nЗбережений час: {hours}:{minutes}:{seconds}");
        }
        public void AddHours(int plusHours)
        {
            if (hours == 23 && plusHours == 1 || hours + plusHours == 24)
                hours = 00;
            else if (hours + plusHours <= 23)
                hours += plusHours;
            else if (hours + plusHours > 24)
                hours = plusHours - (24 - hours);
        }
        public void AddMinutes(int plusMinutes)
        {
            if (minutes + plusMinutes == 60)
            {
                minutes = 00;
                hours++;
            }
            else if (minutes + plusMinutes <= 59)
                minutes += plusMinutes;
            else if (minutes + plusMinutes > 59)
            {
                minutes = plusMinutes - (60 - minutes);
                hours++;
            }
        }
        public void AddSeconds(int plusSeconds)
        {
            if (seconds + plusSeconds == 60)
            {
                minutes++;
                seconds = 00;
            }
            else if (seconds + plusSeconds <= 59)
            {
                seconds += plusSeconds;
            }
            else if (seconds + plusSeconds > 59)
            {
                seconds = plusSeconds - (60 - seconds);
                minutes++;
            }
        }
        private void Error()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Некоректний ввiд!");
            Console.ResetColor();
            Console.WriteLine("\nНатиснiть будь-яку кнопку для закриття консолi..");
            Console.ReadKey();
        }
    }
}
