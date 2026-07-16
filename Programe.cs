using System;
using System.IO;
using System.Collections.Generic;

namespace ZooManagementSystem
{
    internal class Program
    {



        static void ShowMenu()
        {
            Console.WriteLine("========== Zoo Management System ==========");
            Console.WriteLine();
            Console.WriteLine("1. Add Animal");
            Console.WriteLine("2. Display Animals");
            Console.WriteLine("3. Search Animal");
            Console.WriteLine("4. Update Animal");
            Console.WriteLine("5. Delete Animal");
            Console.WriteLine("6. Exit");
            Console.WriteLine();
        }



        static void Main(string[] args)
        {
            AnimalManager manager = new AnimalManager();



            while (true)
            {
                Console.Clear();

                ShowMenu();

                try
                {
                    Console.Write("Enter Choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine();

                    switch (choice)
                    {
                        case 1:
                            manager.AddAnimal();
                            break;

                        case 2:
                            manager.DisplayAnimals();
                            break;

                        case 3:
                            manager.SearchAnimal();
                            break;

                        case 4:
                            manager.UpdateAnimal();
                            break;

                        case 5:
                            manager.DeleteAnimal();
                            break;

                        case 6:
                            Console.WriteLine("Thank You for Using Zoo Management System!");
                            return;

                        default:
                            Console.WriteLine("Invalid Choice!");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter menu number only.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
    }