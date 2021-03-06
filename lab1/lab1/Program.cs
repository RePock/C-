﻿using System;
using System.Text;

namespace lab1 {
    internal class Program {
        private static void Main() {
            Console.WriteLine("Enter date:");
            var inputDate = Console.ReadLine();
            var calendar = new Calendar(inputDate);
            calendar.Show();
           // Console.ReadKey();
        }
    }

    internal class Calendar {
        private readonly string _date;
        private const int DayInWeek = 7;
        private const string RightOffsetOneDigit = "    ";
        private const string RightOffsetTwoDigit = "   ";
        private const string LeftOffset = "   ";
        private const string StartOffset = "   ";
        private const string Delimiter = "|";

        public Calendar(string date) {
            _date = date;
        }

        public void Show() {
            if (!ParseDate(_date, out var date)) {
                return;
            }

            ShowNamesOfDays(date);
            ShowCalendar(date, out var workingDays);
            ShowWorkingDays(workingDays);
        }

        private static bool ParseDate(string inputDate, out DateTime date) {
            StringBuilder sb = new StringBuilder(264);
            if (DateTime.TryParse(inputDate, out date)) {
                return true;
            }
            sb.Append("Wrong input. Please, use one of these formats:");
            sb.Append("\n05/01/2009 14:57:32.8");
            sb.Append("\n2009-05-01 14:57:32.8");
            sb.Append("\n2009-05-01T14:57:32.8375298-04:00");
            sb.Append("\n5/01/2008");
            sb.Append("\n5/01/2008 14:57:32.80 -07:00");
            sb.Append("\n1 May 2008 2:57:32.8 PM");
            sb.Append("\n16-05-2009 1:00:32 PM");
            sb.Append("\nFri, 15 May 2009 20:10:57 GMT");
            sb.Append("\n10.05.2019");
            sb.Append("\n10.05.19");
            sb.Append("10.05");
            Console.WriteLine(sb.ToString());
            return false;
        }

        private static void ShowNamesOfDays(DateTime date) {
            Console.WriteLine($"Calendar for {date:MMMM} {date.Year}");
            Console.Write(StartOffset);
            var curDate = new DateTime(date.Year, date.Month, 1);
            while (curDate.DayOfWeek != DayOfWeek.Monday) {
                curDate = curDate.AddDays(1);
            }

            do {
                Console.Write($"{curDate:ddd}" + RightOffsetTwoDigit + Delimiter + LeftOffset);
                curDate = curDate.AddDays(1);
            } while (curDate.DayOfWeek != DayOfWeek.Monday);

            Console.WriteLine();
        }

        private static void ShowCalendar(DateTime date, out int countOfWorkingDays) {
            countOfWorkingDays = 0;
            var currentDate = new DateTime(date.Year, date.Month, 1);
            SkipDays(currentDate);
            while (currentDate.Month == date.Month) {
                var space = currentDate.Day.ToString().Length > 1
                    ? RightOffsetTwoDigit + Delimiter
                    : RightOffsetOneDigit + Delimiter;
                if ((int)currentDate.DayOfWeek == 0) {
                    Console.Write(LeftOffset + currentDate.Day + space + "\n");
                } else {
                    Console.Write(LeftOffset + currentDate.Day + space);
                    if (currentDate.DayOfWeek != DayOfWeek.Saturday) {
                        countOfWorkingDays++;
                    }
                }

                currentDate = currentDate.AddDays(1);
            }
        }

        private static void SkipDays(DateTime dateTime) {
            for (var step = 0; step < ((int)dateTime.DayOfWeek - 1 + DayInWeek) % DayInWeek; step++) {
                Console.Write("         ");
            }
        }

        private static void ShowWorkingDays(int countOfWorkingDays) {
            Console.WriteLine($"\nNumber of working boring days: {countOfWorkingDays}");
        }
    }
}