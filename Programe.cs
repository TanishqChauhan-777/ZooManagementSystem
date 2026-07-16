using System;
using System.Collections.Generic;

namespace ZooManagementSystem
{
    internal class Program
    {
        static List<Animal> animals = new List<Animal>();

        static void ShowMenu()
        {
            Console.WriteLine("========== Zoo Management System ==========");
            Console.WriteLine();
            Console.WriteLine("1. Add Animal");
            Console.WriteLine("2. Display Animals");
            Console.WriteLine("3. Search Animal");
            Console.WriteLine("4. Exit");
            Console.WriteLine();
        }

        static void AddAnimal()
        {
            Console.Write("Enter Animal Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Animal Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Animal Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Animal animal = new Animal();

            animal.Id = id;
            animal.Name = name;
            animal.Age = age;

            animals.Add(animal);

            Console.WriteLine();
            Console.WriteLine("Animal Added Successfully!");
        }

        static void DisplayAnimals()
        {
            Console.WriteLine("========== Animal List ==========");
            Console.WriteLine();

            if (animals.Count == 0)
            {
                Console.WriteLine("No Animals Found.");
                return;
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine($"Animal Id   : {animal.Id}");
                Console.WriteLine($"Animal Name : {animal.Name}");
                Console.WriteLine($"Animal Age  : {animal.Age}");
                Console.WriteLine(new string('-', 35));
            }
        }

        static void SearchAnimal()
        {
            Console.Write("Enter Animal Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool found = false;

            foreach (Animal animal in animals)
            {
                if (animal.Id == id)
                {
                    found = true;

                    Console.WriteLine();
                    Console.WriteLine("Animal Found!");
                    Console.WriteLine();
                    Console.WriteLine("========== Animal Details ==========");
                    Console.WriteLine();
                    Console.WriteLine($"Animal Id   : {animal.Id}");
                    Console.WriteLine($"Animal Name : {animal.Name}");
                    Console.WriteLine($"Animal Age  : {animal.Age}");

                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine();
                Console.WriteLine("Animal Not Found!");
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                ShowMenu();

                Console.Write("Enter Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        AddAnimal();
                        break;

                    case 2:
                        DisplayAnimals();
                        break;

                    case 3:
                        SearchAnimal();
                        break;

                    case 4:
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