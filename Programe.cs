using System;
using System.IO;
using System.Collections.Generic;

namespace ZooManagementSystem
{
    internal class Program
    {
        static List<Animal> animals = new List<Animal>();

        static string filePath = "Animal.txt";

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
            try
            {
                Console.Write("Enter Animal Id: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Animal Name: ");
                string name = Console.ReadLine() ?? "";

                Console.Write("Enter Animal Age: ");
                int age = Convert.ToInt32(Console.ReadLine());

                Animal animal = new Animal()
                {
                    Id = id,
                    Name = name,
                    Age = age
                };

                animals.Add(animal);

                SaveAnimalToFile(animal);

                Console.WriteLine();
                Console.WriteLine("Animal Added Successfully!");
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
        }

        static void SaveAnimalToFile(Animal animal)
        {
            try
            {
                string data = $"{animal.Id},{animal.Name},{animal.Age}";
                File.AppendAllText(filePath, data + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("File Error: " + ex.Message);
            }
        }

        static void LoadAnimalsFromFile()
        {
            try
            {
                animals.Clear();

                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        string[] data = line.Split(',');

                        Animal animal = new Animal()
                        {
                            Id = Convert.ToInt32(data[0]),
                            Name = data[1],
                            Age = Convert.ToInt32(data[2])
                        };

                        animals.Add(animal);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("File Loading Error: " + ex.Message);
            }
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
            try
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
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid Animal Id.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void Main(string[] args)
        {
            LoadAnimalsFromFile();

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