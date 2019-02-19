using System;
using System.Collections.Generic;

namespace lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            String[] fraza =
            {
                "ПОБЕДА ИЛИ СМЕРТЬ, угадывай дальше",
                "я думал ты будешь угадывать бытсрей",
                "у меня нет времени на игры, но ты молодец(нет)",
                "даже мой 2-х летний брат угадывает быстрей..."
            };

            List<String> history = new List<string>();
            int cout = 0;
            int result = 0;
            int a = 0;

            Random rand = new Random();
            int fraz = rand.Next(fraza.Length);
            Console.WriteLine("Введите ваше имя");
            String name = Console.ReadLine();
            int answer = rand.Next(51);

            Console.WriteLine("Хорошо " + name + " угадай число от 0 до 50");

            DateTime date1 = DateTime.Now;
            String s = Console.ReadLine();

            if (s.Equals("q"))
            {
                Console.WriteLine("Извини, пока");
            }
            else
            {
                try
                {
                    a = Int32.Parse(s);
                    result++;
                    while (answer != a)
                    {
                        if (a < answer)
                        {
                            Console.WriteLine("число больше");
                            history.Add(s + " меньше");
                            cout++;
                        }
                        else if (a > answer)
                        {
                            Console.WriteLine("число меньше");
                            history.Add(s + " больше");
                            cout++;
                        }

                        if (cout % 4 == 0)
                        {
                            Console.WriteLine(name + ", " + fraza[fraz]);
                            fraz = rand.Next(fraza.Length);
                        }

                        s = Console.ReadLine();

                        if (s.Equals("q"))
                        {
                            Console.WriteLine("Извини, пока");
                            break;
                        }

                        a = Int32.Parse(s);
                        result++;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Нужно вводить число");
                }

                if (a == answer)
                {
                    Console.WriteLine("Хорошо, угадал");
                    history.Add(s + " ровно");
                    Console.WriteLine($"Кол - во попыток {result}");
                    foreach (String h in history)
                    {
                        Console.WriteLine(h);
                    }

                    DateTime date2 = DateTime.Now;
                    TimeSpan interval = date2 - date1;
                    Console.WriteLine($"Ты потратил {interval.ToString()}");
                }
            }
        }
    }
}