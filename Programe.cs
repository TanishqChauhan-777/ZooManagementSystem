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

        static void ShowSearchMenu()
        {

            Console.WriteLine("========== Search Animal ==========");
            Console.WriteLine();

            Console.WriteLine("1. Find Animal By Id");
            Console.WriteLine("2. Find Animal By Name");
            Console.WriteLine("3. Back");
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            AnimalManager manager = new AnimalManager();



            while (true)
            {
                Console.Clear();

                ShowMenu();
 
                    int choice = InputHelper.ReadInt("Enter Choice: ");
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
                        ShowSearchMenu();

                        int searchChoice = InputHelper.ReadInt("Enter Choice: ");

                        switch (searchChoice)
                        {
                            case 1:
                                manager.SearchAnimalByID();
                                break;

                            case 2:
                                manager.SearchAnimalbyName();
                                break;
                        }
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
                
            
             
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
    }