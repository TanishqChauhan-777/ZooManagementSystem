using System;

namespace ZooManagementSystem
{
    public class Animal
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public Species Species { get; set; }
        public Gender Gender { get; set; }


    }
}