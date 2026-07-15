using System;
 

namespace ZooManagementSystem
{
    public class Animal
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            Console.WriteLine("========== Add Animals ==========");
            Console.WriteLine();

            Console.Write("Enter Animal Id :");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Animal Name :");
            string name = Console.ReadLine();

            Console.Write("Enter Animal Age :");
            int age = Convert.ToInt32(Console.ReadLine());

            Animal animal = new Animal();

            animal.Id = id;
            animal.Name = name;
            animal.Age = age;

            animals.Add(animal);

            Console.WriteLine();

            Console.WriteLine("========== Animals ==========");
            Console.WriteLine($"Animal Id   :{animals[0].ID}");
            Console.WriteLine($"Animal Name :{animals[0].Name}");
            Console.WriteLine($"Animal Age  :{animals[0].Age}");
        }
    }
}