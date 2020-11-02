using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public string Name { get; set; }
        public int Age { 
            get
            {
                return this.age;
            }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be positive number.");
                }
                this.age = value;
            } 
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Name: {this.Name}, Age: {this.Age}");
            return stringBuilder.ToString();
        }

    }
}
