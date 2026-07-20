using System;

namespace ZooManagementSystem
{
    internal class Program
    {
        static void ShowMainMenu()
        {
            Console.WriteLine("========== Zoo Management System ==========");
            Console.WriteLine();

            Console.WriteLine("1. Animal Management");
            Console.WriteLine("2. Employee Management");
            Console.WriteLine("3. Exit");

            Console.WriteLine();
        }

        static void ShowAnimalMenu()
        {
            Console.WriteLine("========== Animal Management ==========");
            Console.WriteLine();

            Console.WriteLine("1. Add Animal");
            Console.WriteLine("2. Display Animals");
            Console.WriteLine("3. Search Animal");
            Console.WriteLine("4. Update Animal");
            Console.WriteLine("5. Delete Animal");
            Console.WriteLine("6. Back");

            Console.WriteLine();
        }

        static void ShowEmployeeMenu()
        {
            Console.WriteLine("========== Employee Management ==========");
            Console.WriteLine();

            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Display Employees");
            Console.WriteLine("3. Search Employee");
            Console.WriteLine("4. Update Employee");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Back");

            Console.WriteLine();
        }

        static void ShowAnimalSearchMenu()
        {
            Console.WriteLine("========== Search Animal ==========");
            Console.WriteLine();

            Console.WriteLine("1. Search Animal By Id");
            Console.WriteLine("2. Search Animals By Species");
            Console.WriteLine("3. Back");

            Console.WriteLine();
        }

        static void ShowEmployeeSearchMenu()
        {
            Console.WriteLine("========== Search Employee ==========");
            Console.WriteLine();

            Console.WriteLine("1. Search Employee By Id");
            Console.WriteLine("2. Search Employee By Role");
            Console.WriteLine("3. Back");

            Console.WriteLine();
        }

        // =====================================================
        // ===== New Method (Changed by ChatGPT)
        // Animal Menu moved outside Main()
        // =====================================================

        static void AnimalManagementMenu(AnimalManager animalManager)
        {
            while (true)
            {
                Console.Clear();

                ShowAnimalMenu();

                int animalChoice = InputHelper.ReadInt("Enter Choice: ");
                Console.WriteLine();

                switch (animalChoice)
                {
                    case 1:
                        animalManager.AddAnimal();
                        break;

                    case 2:
                        animalManager.DisplayAnimals();
                        break;

                    case 3:

                        ShowAnimalSearchMenu();

                        int animalSearchChoice =
                            InputHelper.ReadInt("Enter Choice: ");

                        switch (animalSearchChoice)
                        {
                            case 1:
                                animalManager.SearchAnimalByID();
                                break;

                            case 2:
                                animalManager.SearchAnimalBySpecies();
                                break;

                            case 3:
                                break;

                            default:
                                Console.WriteLine("Invalid Choice!");
                                break;
                        }

                        break;

                    case 4:
                        animalManager.UpdateAnimal();
                        break;

                    case 5:
                        animalManager.DeleteAnimal();
                        break;

                    case 6:

                        // Return to Main Menu
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
        // =====================================================
        // ===== New Method (Changed by ChatGPT)
        // Employee Menu moved outside Main()
        // =====================================================

        static void EmployeeManagementMenu(EmployeeManager employeeManager)
        {
            while (true)
            {
                Console.Clear();

                ShowEmployeeMenu();

                int employeeChoice = InputHelper.ReadInt("Enter Choice: ");
                Console.WriteLine();

                switch (employeeChoice)
                {
                    case 1:
                        employeeManager.AddEmployee();
                        break;

                    case 2:
                        employeeManager.DisplayAllEmployee();
                        break;

                    case 3:

                        ShowEmployeeSearchMenu();

                        int employeeSearchChoice =
                            InputHelper.ReadInt("Enter Choice: ");

                        switch (employeeSearchChoice)
                        {
                            case 1:
                                employeeManager.SearchEmployeeByID();
                                break;

                            case 2:
                                employeeManager.SearchEmployeeByRole();
                                break;

                            case 3:
                                break;

                            default:
                                Console.WriteLine("Invalid Choice!");
                                break;
                        }

                        break;

                    case 4:
                        employeeManager.UpdateEmployee();
                        break;

                    case 5:
                        employeeManager.DeleteEmployee();
                        break;

                    case 6:

                        // ===== Changed by ChatGPT =====
                        // Back to Main Menu
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
        // =====================================================
        // ===== Changed by ChatGPT =====
        // Clean Main Method (goto removed)
        // =====================================================

        static void Main(string[] args)
        {
            AnimalManager animalManager = new AnimalManager();
            EmployeeManager employeeManager = new EmployeeManager();

            while (true)
            {
                Console.Clear();

                ShowMainMenu();

                int mainChoice = InputHelper.ReadInt("Enter Choice: ");
                Console.WriteLine();

                switch (mainChoice)
                {
                    case 1:

                        AnimalManagementMenu(animalManager);
                        break;

                    case 2:

                        EmployeeManagementMenu(employeeManager);
                        break;

                    case 3:

                        Console.WriteLine();
                        Console.WriteLine("Thank You For Using Zoo Management System!");
                        return;

                    default:

                        Console.WriteLine("Invalid Choice!");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}