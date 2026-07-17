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
    }
}