using System;

namespace Question2
{
    class Scet
    {
        public decimal sum { get; set; }
        public int numberScet { get; set; }
        private byte day;
        private byte month;
        private int year;

        public byte Day
        {
            get
            {
                return day;
            }
            set
            {
                day = value;
            }
        }

        public byte Month
        {
            get
            {
                return month;
            }
            set
            {
                month = value;
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

        public Scet() { }

        public Scet(byte day, byte month, int year)
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }

        public virtual void DisplaySum()
        {
            Console.WriteLine($"Balance: { sum }");
        }

        public virtual void AccountOpenDate()
        {
            Console.WriteLine($"Account is open: { Day }.{ Month }.{ Year }");
        }
    }

    class Individual : Scet
    {
        public byte vidSceta { get; set; }

        public override void AccountOpenDate()
        {
            Console.WriteLine($"Individual account is open: { Day }.{ Month }.{ Year }");
        }

        public void Menu()
        {
            Console.Write("\n1)Withdraw\n2)Percent per year\nYour choice: ");
        }

        public static int NumberCheckerForInt()
        {
            int number;

            for (; ; )
            {
                string numberInString = Console.ReadLine();

                if (Int32.TryParse(numberInString, out number))
                {
                    return number;
                }
                else
                {
                    Console.Write("Incorrect number, please enter again: ");
                }
            }
        }

        public void Procent(double year, decimal sumProc)
        {
            decimal a = 10M;

            for (int i = 0; i < year; i++)
            {
                sumProc *= a / 100;
                Console.WriteLine($"Percent per year: { sumProc }$");
                break;
            }
        }

        public void Withdraw()
        {
            bool checkerForSum = true;
            do
            {
                Console.Write("Enter how many money, you want to withdraw: ");
                decimal a = NumberCheckerForInt();
                if (a > 0)
                {
                    if (a > sum)
                    {
                        Console.Write("You don't have this money in balance.\n");
                        checkerForSum = false;
                    }
                    else
                    {
                        Console.WriteLine($"Please take your money: { a }$\nBalance: { sum - a }$");
                        checkerForSum = true;
                    }
                }
                else
                {
                    Console.WriteLine("Withdraw choice cannot be zero or negativ number.");
                    checkerForSum = false;
                }
            } while (checkerForSum == false);
        }

        public Individual() { }

        public Individual(byte Day, byte Month, int Year)
            : base(Day, Month, Year)
        {

        }
    }

    class Legal : Scet
    {
        public override void AccountOpenDate()
        {
            Console.WriteLine($"Legal account is open: { Day }.{ Month }.{ Year }");
        }

        public void Procent(double year, decimal sumProc)
        {
            decimal a = 10M;

            for (int i = 0; i < year; i++)
            {
                sumProc *= a / 100;
                Console.WriteLine($"Percent per year: { sumProc }$");
                break;
            }
        }

        public Legal() { }

        public Legal(byte Day, byte Month, int Year)
            : base(Day, Month, Year)
        {

        }
    }

    class Program
    {
        public static byte NumberCheckerForDay()
        {
            byte number;

            for (; ; )
            {
                string numberInString = Console.ReadLine();

                if (Byte.TryParse(numberInString, out number))
                {
                    if (number > 31 || number == 0)
                    {
                        Console.Write("Incorrect day, enter again: ");
                    }
                    else
                    {
                        return number;
                    }
                }

                else
                {
                    Console.Write("Incorrect day, enter again: ");
                }
            }
        }

        public static byte NumberCheckerForMonth()
        {
            byte number;

            for (; ; )
            {
                string numberInString = Console.ReadLine();

                if (Byte.TryParse(numberInString, out number))
                {
                    if (number > 13 || number == 0)
                    {
                        Console.Write("Incorrect month, enter again: ");
                    }
                    else
                    {
                        return number;
                    }
                }

                else
                {
                    Console.Write("Incorrect month, enter again: ");
                }
            }
        }

        public static int NumberCheckerForInt()
        {
            int number;

            for (; ; )
            {
                string numberInString = Console.ReadLine();

                if (Int32.TryParse(numberInString, out number))
                {
                    return number;
                }
                else
                {
                    Console.Write("Incorrect number, please enter again: ");
                }
            }
        }

        public static byte NumberCheckerForSwitch()
        {
            byte number;

            for (; ; )
            {
                string numberInString = Console.ReadLine();

                if (Byte.TryParse(numberInString, out number))
                {
                    return number;
                }

                else
                {
                    Console.Write("You enter not a number, please try again: ");
                }
            }
        }

        static void Main(string[] args)
        {
            bool selectionForSwitch = true;
            do
            {
                Console.Write("1)Individual account\n2)Legal account\n3)Exit\nYour choice: ");
                byte choiceAccount = NumberCheckerForSwitch();
                switch (choiceAccount)
                {
                    case 1:
                        {
                            Individual individual = new Individual();
                            bool selectionForSwitch2 = true;
                            do
                            {
                                individual.Menu();
                                byte individualChoice = NumberCheckerForSwitch();
                                switch (individualChoice)
                                {
                                    case 1:
                                        {
                                            Console.Write("Enter balance: ");
                                            individual.sum = NumberCheckerForInt();

                                            Console.Write("Enter day: ");
                                            individual.Day = NumberCheckerForDay();

                                            Console.Write("Enter month: ");
                                            individual.Month = NumberCheckerForMonth();

                                            Console.Write("Enter year: ");
                                            individual.Year = NumberCheckerForInt();

                                            individual.AccountOpenDate();
                                            individual.Withdraw();

                                            selectionForSwitch = true;
                                            selectionForSwitch2 = true;
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Write("Enter balance: ");
                                            individual.sum = NumberCheckerForInt();
                                            decimal summa = individual.sum;

                                            Console.Write("Enter day: ");
                                            individual.Day = NumberCheckerForDay();

                                            Console.Write("Enter month: ");
                                            individual.Month = NumberCheckerForMonth();

                                            Console.Write("Enter year: ");
                                            individual.Year = NumberCheckerForInt();
                                            double year = 2021 - individual.Year;

                                            individual.AccountOpenDate();
                                            individual.Procent(year, summa);
                                            selectionForSwitch = true;
                                            selectionForSwitch2 = true;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("You enter incorrect number, please enter from 1 till 2");
                                            selectionForSwitch2 = false;
                                            break;
                                        }
                                } 
                            } while (selectionForSwitch2 == false);
                            break;
                        }
                    case 2:
                        {
                            Legal legal = new Legal();

                            Console.Write("Enter balance: ");
                            legal.sum = NumberCheckerForInt();
                            decimal summa = legal.sum;

                            Console.Write("Enter day: ");
                            legal.Day = NumberCheckerForDay();

                            Console.Write("Enter month: ");
                            legal.Month = NumberCheckerForMonth();

                            Console.Write("Enter year: ");
                            legal.Year = NumberCheckerForInt();
                            double year = 2021 - legal.Year;

                            legal.AccountOpenDate();
                            legal.Procent(year, summa);
                            selectionForSwitch = true;
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Have a good day :)");
                            selectionForSwitch = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("You enter incorrect number, please enter from 1 till 2");
                            selectionForSwitch = false;

                            break;
                        }
                }
            } while (selectionForSwitch == false);



            Console.ReadKey();

        }
    }
}
