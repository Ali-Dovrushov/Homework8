using System;
using System.Globalization;
/*Создать базовый класс Счет,
 * который содержит информацию - сумма, номер счета, дата открытия, а также методы Выдача суммы и Выдача даты открытия счета.
 * 
 * С помощью механизма наследования создать класс "Счет физического лица" и "Счет юридического лица.

"Счет физического лица" содержит:
поле "Вид счета"
методы "Начисление процентов" и "Снятие денег со счета"

"Счет юридического лица содержит:
метод начисления процентов*/


namespace Question2
{
    class Scet
    {
        public decimal sum { get; set; }
        public int numberScet { get; set; }
        DateTime dateTime = new DateTime(2020, 05, 17);

        public void DisplaySum()
        {
            Console.WriteLine($"Summa: { sum }");
        }

        public void DisplayDate()
        {
            Console.WriteLine($"Open: { dateTime }");
        }
    }

    class FizScet : Scet
    {
        public int vidSceta { get; set; }

        public void Procent(int year, decimal sumProc)
        {
            decimal a = 12M;

            for (int i = 0; i < year; i++)
            {
                sumProc *= a / 100;
                Console.WriteLine($"Za god { sumProc }\b\b%\b");
            }
        }


        public void Withdraw(int a)
        {
            bool checkerForSum = true;
            do
            {
                if (a > sum)
                {
                    Console.WriteLine($"{ a - sum }");
                    checkerForSum = true;
                }
                else
                {
                    Console.WriteLine("Nedostatocno deneg");
                    checkerForSum = false;
                }
            } while (checkerForSum == false);
        }
    }

    class UridScet : Scet
    {
        public void Procent()
        {

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = new DateTime(2020, 05, 16);

            FizScet scet = new FizScet();

            int year = DateTime.Now.Year - date.Year;


            decimal sum = 1000M;
            scet.Procent(year, sum);



            Console.ReadKey();

        }
    }
}
