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
            string input;

            do
            {
                Console.Write(message);
                input = Console.ReadLine() ?? "";

                if (input.Trim() == "")
                {
                    Console.WriteLine("Input cannot be empty.");
                }

            } while (input.Trim() == "");

            return input;
        }
    }
}