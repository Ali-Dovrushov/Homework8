﻿using System;

namespace Дополнительное_Задание
{
    class Person
    {
        public string surname { get; set; }
        public byte course { get; set; }
        public int idBook { get; set; }
        public string desertation { get; set; }
    }

    class Student
    {
        Person[] data;
        public Student()
        {
            data = new Person[100];
        }
        public Person this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
    }

    class Aspirant : Student
    {

    }

    class Program
    {
        public static bool checkerName = true;

        public static string NameForCompare;

        public static void Menu()
        {
            Console.WriteLine("1) Add student");
            Console.WriteLine("2) Add aspirant");
            Console.WriteLine("3) How many student");
            Console.WriteLine("4) How many aspirant");
            Console.WriteLine("5) Student list");
            Console.WriteLine("6) Aspirant list");
            Console.WriteLine("7) Enter index of student");
            Console.WriteLine("8) Enter index of aspirant");
            Console.WriteLine("9) Delete index of student ");
            Console.WriteLine("10) Delete index of aspirant");
            Console.WriteLine("11) Exit");
            Console.Write("Your select: ");
        }

        public static void Read()
        {
            Console.Write("\nPress any button...");
            Console.ReadKey();
            Console.WriteLine("\n\n\n");
        }

        public static string PersonName()
        {
            do
            {
                string personName = Convert.ToString(Console.ReadLine());

                for (int i = 0; i < personName.Length; i++)
                {
                    char element = personName[i];

                    if (!Char.IsLetter(element))
                    {
                        checkerName = false;
                        Console.Write("Incorrect name type, please enter correct name: ");
                        break;
                    }
                    else
                    {
                        checkerName = true;
                    }
                }

                NameForCompare = personName;
            }
            while (checkerName == false);

            return NameForCompare;
        }

        public static int NumberCheckerForId()
        {
            int number;

            for (; ; )
            {
                string numberInString = Console.ReadLine();

                if (Int32.TryParse(numberInString, out number))
                {
                    if (numberInString.Length == 5)
                    {
                        return number;
                    }
                    else
                    {
                        Console.Write("Incorrect, id card can be 5 digit number: ");
                    }
                }

                else
                {
                    Console.Write("Incorrect number, please enter again: ");
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

        public static byte NumberCheckerForCourse()
        {
            byte number;

            for (; ; )
            {
                string numberInString = Console.ReadLine();

                if (Byte.TryParse(numberInString, out number))
                {
                    if (number > 6 || number == 0)
                    {
                        Console.Write("Incorrect course, course can be only from 1 till 6 please enter again: ");
                    }
                    else
                    {
                        return number;
                    }
                }

                else
                {
                    Console.Write("Incorrect course, course can be only from 1 till 6 please enter again: ");
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
            Student student = new Student();
            Aspirant aspirant = new Aspirant();
            int studentsCounter = 0;
            int aspirantsCounter = 0;
            int delete;
            bool selectionForSwitch = false;
            bool selectionForAll = false;

            do
            {
                Menu();
                do
                {
                    byte choice = NumberCheckerForSwitch();
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.Write("Enter surname: ");
                                string studentSurname = PersonName();

                                Console.Write("Enter course: ");
                                byte studentCourse = NumberCheckerForCourse();

                                Console.Write("Enter ID card: ");
                                int studentIDBook = NumberCheckerForId();

                                student[studentsCounter] = new Person { surname = studentSurname, course = studentCourse, idBook = studentIDBook };
                                studentsCounter++;
                                selectionForSwitch = true;

                                Read();
                                break;
                            }
                        case 2:
                            {
                                Console.Write("Enter surname: ");
                                string aspirantSurname = PersonName();

                                Console.Write("Enter course: ");
                                byte aspirantCourse = NumberCheckerForCourse();

                                Console.Write("Enter ID card: ");
                                int aspirantIDBook = NumberCheckerForId();

                                Console.Write("Enter diplom work: ");
                                string diplom = Console.ReadLine();

                                aspirant[aspirantsCounter] = new Person { surname = aspirantSurname, course = aspirantCourse, idBook = aspirantIDBook, desertation = diplom };
                                aspirantsCounter++;
                                selectionForSwitch = true;

                                Read();
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine($"\nTotal students: { studentsCounter }");

                                Read();
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine($"\nTotal aspirants: { aspirantsCounter }");

                                Read();
                                break;
                            }
                        case 5:
                            {
                                if (studentsCounter == 0)
                                {
                                    Console.WriteLine("\nThis sheet empty");
                                }
                                else
                                {
                                    Console.WriteLine("\nStudent list");
                                    for (int i = 0; i < studentsCounter; i++)
                                    {
                                        if (student[i] == null)
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            Person studentList = student[i];
                                            Console.WriteLine($"Surname: { studentList.surname }, Course: { studentList.course }, ID card: { studentList.idBook }");
                                        }
                                    }
                                }

                                Read();
                                break;
                            }
                        case 6:
                            {
                                if (aspirantsCounter == 0)
                                {
                                    Console.WriteLine("\nThis sheet empty");
                                }
                                else
                                {
                                    Console.WriteLine("\nAspirant list");
                                    for (int i = 0; i < aspirantsCounter; i++)
                                    {
                                        if (aspirant[i] == null)
                                        {
                                            continue;
                                        }
                                        Person aspirantList = aspirant[i];
                                        Console.WriteLine($"Surname: { aspirantList.surname }, Course: { aspirantList.course }, ID book: { aspirantList.idBook }, Diplom work: { aspirantList.desertation }");
                                    }
                                }

                                Read();
                                break;
                            }
                        case 7:
                            {
                                bool checkerForCase7 = true;

                                do
                                {
                                    Console.Write("\nEnter student index: ");
                                    int indexStudent = NumberCheckerForInt();
                                    if (indexStudent > studentsCounter)
                                    {
                                        Console.Write($"Out of array we have index from 0 till { studentsCounter - 1 }");
                                        checkerForCase7 = false;
                                    }
                                    else
                                    {
                                        Person choiceStudent = student[indexStudent];
                                        Console.WriteLine($"\nSurname: { choiceStudent.surname }, Course: { choiceStudent.course }, ID card: { choiceStudent.idBook }");
                                        checkerForCase7 = true;
                                    }
                                } while (checkerForCase7 == false);

                                Read();
                                break;
                            }
                        case 8:
                            {
                                bool checkerForCase8 = true;

                                do
                                {
                                    Console.Write("\nEnter aspirant index: ");
                                    int indexAspirant = NumberCheckerForInt();
                                    if (indexAspirant > aspirantsCounter)
                                    {
                                        Console.WriteLine();
                                        checkerForCase8 = false;
                                    }
                                    else
                                    {
                                        Person choiceAspirant = aspirant[indexAspirant];
                                        Console.WriteLine($"\nSurname: { choiceAspirant.surname }, Course: { choiceAspirant.course }, ID card: { choiceAspirant.idBook }, Diplom work: { choiceAspirant.desertation }");
                                        checkerForCase8 = true;
                                    }

                                } while (checkerForCase8 == false); ;

                                Read();
                                break;
                            }
                        case 9:
                            {
                                Console.Write("\nEnter index student which you want delete: ");
                                delete = NumberCheckerForInt();
                                Person deleteStudent = student[delete];
                                Console.WriteLine($"\nStudent { deleteStudent.surname } deleted.");
                                student[delete] = null;
                                studentsCounter--;

                                Read();
                                break;
                            }
                        case 10:
                            {
                                Console.WriteLine("Enter index aspirant which you want delete: ");
                                delete = NumberCheckerForInt();
                                Person deleteAspirant = aspirant[delete];
                                Console.WriteLine($"Aspirant { deleteAspirant.surname } deleted.");
                                aspirant[delete] = null;
                                aspirantsCounter--;

                                Read();
                                break;
                            }
                        case 11:
                            {
                                Console.WriteLine("Have a good day :)");
                                selectionForAll = true;
                                selectionForSwitch = true;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("You enter incorrect number, please enter from 1 till 11");
                                Menu();
                                selectionForSwitch = false;
                                continue;
                            }
                    }
                } while (selectionForSwitch == false);
            }while(selectionForAll == false);
            Console.ReadKey();
        }
    }
}