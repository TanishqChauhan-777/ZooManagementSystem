using System;
using System.Collections.Generic;
using System.IO;

namespace ZooManagementSystem
{
    internal class AnimalManager
    {
        private List<Animal> animals = new List<Animal>();

        private string filePath = "Animal.txt";





        public void AddAnimal()
        {

            int id = InputHelper.ReadInt("Enter Animal Id: ");

            string name = InputHelper.ReadString("Enter Animal name:");

            int age = InputHelper.ReadInt("Enter Animal Age:");

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
        private void SaveAnimalToFile(Animal animal)
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

        private void SaveAllAnimalsToFile()
        {
            try
            {
                File.WriteAllText(filePath, "");

                foreach (Animal animal in animals)
                {
                    SaveAnimalToFile(animal);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("File Saving Error: " + ex.Message);
            }
        }

        private void LoadAnimalsFromFile()
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

        public void DisplayAnimals()
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
        public void SearchAnimal()
        {

            int id = InputHelper.ReadInt("Enter Animal Id: ");

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
            
        
        public void UpdateAnimal()
        {
            
                int id = InputHelper.ReadInt("Enter Animal ypur want to Update: ");

                bool found = false;

                foreach (Animal animal in animals)
                {
                    if (animal.Id == id)
                    {
                        found = true;

                    string newName = InputHelper.ReadString("Enter New Name: ");

                    int newAge = InputHelper.ReadInt("Enter New Age: ");

                    animal.Name = newName;
                        animal.Age = newAge;

                        SaveAllAnimalsToFile();

                        Console.WriteLine();
                        Console.WriteLine("Animal Updated Successfully!");

                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine();
                    Console.WriteLine("Animal Not Found!");
                }
            }
     
        public void DeleteAnimal()
        {

            int id = InputHelper.ReadInt("Enter Animal Id you want to Delete: ");

            Animal animalToDelete = null;

                foreach (Animal animal in animals)
                {
                    if (animal.Id == id)
                    {
                        animalToDelete = animal;
                        break;
                    }
                }

                if (animalToDelete != null)
                {
                    animals.Remove(animalToDelete);

                    SaveAllAnimalsToFile();

                    Console.WriteLine();
                    Console.WriteLine("Animal Deleted Successfully!");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Animal Not Found!");
                }
            }
           
        }
    }
    
    