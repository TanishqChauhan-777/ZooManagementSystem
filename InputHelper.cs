using System;
namespace ZooManagementSystem
{
    internal class InputHelper
    {
        public static int ReadInt(string message)
        {
            int number;
            bool isValid;

            do
            {
                Console.Write(message);

                isValid = int.TryParse(Console.ReadLine(), out number);

                if (!isValid)
                {
                    Console.WriteLine("Invalid Input! Please enter a valid number.");
                }

            } while (!isValid);

            return number;
        }

        public static string ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine() ?? "";
        }

        public static HealthStatus ReadHealthStatus()
        {
            while (true)
            {
                Console.WriteLine("========== Select Health Status ==========");
                Console.WriteLine();
                Console.WriteLine("1. Healthy");
                Console.WriteLine("2. Sick");
                Console.WriteLine("3. Injured");
                Console.WriteLine("4. Under Treatment");
                Console.WriteLine();

                int choice = ReadInt("Enter Choice: ");

                switch (choice)
                {
                    case 1:
                        return HealthStatus.Healthy;

                    case 2:
                        return HealthStatus.Sick;

                    case 3:
                        return HealthStatus.Injured;

                    case 4:
                        return HealthStatus.UnderTreatment;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid Choice! Please enter 1 or 2.");
                        Console.WriteLine();
                        break;
                }
            }
        }
        public static Gender ReadGender()
        {
            while (true)
            {
                Console.WriteLine("========== Select Gender ==========");
                Console.WriteLine();
                Console.WriteLine("1. Male");
                Console.WriteLine("2. Female");
                Console.WriteLine();

                int choice = ReadInt("Enter Choice: ");

                switch (choice)
                {
                    case 1:
                        return Gender.Male;

                    case 2:
                        return Gender.Female;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid Choice! Please enter 1 or 2.");
                        Console.WriteLine();
                        break;
                }
            }
        }
        public static Species ReadSpecies()
        {
            while (true)
            {
                Console.WriteLine("========== Select Species ==========");
                Console.WriteLine();
                Console.WriteLine("1. Lion");
                Console.WriteLine("2. Tiger");
                Console.WriteLine("3. Elephant");
                Console.WriteLine("4. Giraffe");
                Console.WriteLine("5. Zebra");
                Console.WriteLine("6. Bear");
                Console.WriteLine("7. Monkey");
                Console.WriteLine("8. Deer");
                Console.WriteLine("9. Crocodile");
                Console.WriteLine("10. Penguin");
                Console.WriteLine();

                int choice = ReadInt("Enter Choice: ");

                switch (choice)
                {
                    case 1:
                        return Species.Lion;

                    case 2:
                        return Species.Tiger;

                    case 3:
                        return Species.Elephant;

                    case 4:
                        return Species.Giraffe;

                    case 5:
                        return Species.Zebra;

                    case 6:
                        return Species.Bear;

                    case 7:
                        return Species.Monkey;

                    case 8:
                        return Species.Deer;

                    case 9:
                        return Species.Crocodile;

                    case 10:
                        return Species.Penguin;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid Choice! Choice With Digits 1,2,3.....");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}