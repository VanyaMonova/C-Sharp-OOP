using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizen : IControlable, IBirthable
    {
        public string Id { get; }

        public string Name { get; }

        public int Age { get; }

        public string Birhtdate { get; }

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birhtdate = birthdate;
        }

    }
}
