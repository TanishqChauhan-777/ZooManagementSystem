using System;
using System.Collections.Generic;
using System.IO; 

namespace ZooManagementSystem
{
    internal class AnimalManager
    {
        private List<Animal> animals = new List<Animal>();

        private string filePath = "Animal.txt";

        public AnimalManager()
        {
            LoadAnimalsFromFile();
        }


        //===== Add Animal =====
        public void AddAnimal()
        {
            int id = InputHelper.ReadInt("Enter Animal Id: ");

            bool found = false;

            foreach (Animal animal in animals)
            {
                if (animal.Id == id)
                {
                    found = true;
                    break;
                }
            }

            if (found)
            {
                Console.WriteLine("Animal Id already exists! Please enter a unique Id.");
                return;
            }

            Console.WriteLine();
            Species species = InputHelper.ReadSpecies();

            Console.WriteLine();
            Gender gender = InputHelper.ReadGender();


            Console.WriteLine();
            string name = InputHelper.ReadString("Enter Animal Name: ");

            int age;
            do
            {
                 age = InputHelper.ReadInt("Enter Animal Age: ");

                if (age < 0 || age > 100)
                {

                    Console.WriteLine("Enter a Valid Age");
                }
            } while (age < 0 || age > 100);

            
            Animal animalData = new Animal()
            {
                Id = id,
                Species = species,
                Gender = gender,
                Name = name,
                Age = age,
                HealthStatus = HealthStatus.Healthy

            };

            animals.Add(animalData);

            SaveAnimalToFile(animalData);

            Console.WriteLine();
            Console.WriteLine("Animal Added Successfully!");
        }

        //=====  Save Animal =====
        private void SaveAnimalToFile(Animal animal)
        {
            try
            {
                string data = $"{animal.Id},{animal.Species},{animal.Gender},{animal.Name},{animal.Age},{animal.HealthStatus}";

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
                            Species = Enum.Parse<Species>(data[1]),
                            Gender = Enum.Parse<Gender>(data[2]),
                            Name = data[3],
                            Age = Convert.ToInt32(data[4]),
                            HealthStatus = Enum.Parse<HealthStatus>(data[5])
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
                Console.WriteLine($"Animal Id            : {animal.Id}");
                Console.WriteLine($"Animal Species       : {animal.Species}");
                Console.WriteLine($"Animal Gender        : {animal.Gender}");
                Console.WriteLine($"Animal Name          : {animal.Name}");
                Console.WriteLine($"Animal Age           : {animal.Age}");
                Console.WriteLine($"Animal Health Status : {animal.HealthStatus}");
                Console.WriteLine(new string('-', 35));
            }
        }
        public void SearchAnimalByID()
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
                    Console.WriteLine($"Animal Id            : {animal.Id}");
                    Console.WriteLine($"Animal Species       : {animal.Species}");
                    Console.WriteLine($"Animal Gender        : {animal.Gender}");
                    Console.WriteLine($"Animal Name          : {animal.Name}");
                    Console.WriteLine($"Animal Age           : {animal.Age}");
                    Console.WriteLine($"Animal Health Status : {animal.HealthStatus}");

                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine();
                Console.WriteLine("Animal Not Found!");
            }

        }

        public void SearchAnimalbyName()
        {
            string name = InputHelper.ReadString("Enter Animal Name: ");

            bool found = false;

            foreach(Animal animal in animals)
            {
                if(animal.Name == name)
                {
                    found = true;

                    Console.WriteLine();
                    Console.WriteLine("Animal Found!");
                    Console.WriteLine();
                    Console.WriteLine("========== Animal Details ==========");
                    Console.WriteLine($"Animal Id            : {animal.Id}");
                    Console.WriteLine($"Animal Species       : {animal.Species}");
                    Console.WriteLine($"Animal Gender        : {animal.Gender}");
                    Console.WriteLine($"Animal Name          : {animal.Name}");
                    Console.WriteLine($"Animal Age           : {animal.Age}");
                    Console.WriteLine($"Animal Health Status : {animal.HealthStatus}");
                    break;


                }
            }

            if (!found)
            {
                Console.WriteLine();
                Console.WriteLine("Animal Not Found");
            }
        }
        
            
                public void UpdateAnimal()
        {
            
                int id = InputHelper.ReadInt("Enter Animal Id you  want to Update: ");

                bool found = false;

                foreach (Animal animal in animals)
                {
                    if (animal.Id == id)
                    {
                        found = true;

                    string newName = InputHelper.ReadString("Enter New Name: ");

                    int newAge = InputHelper.ReadInt("Enter New Age: ");

                    animal.HealthStatus = InputHelper.ReadHealthStatus();

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
    
    