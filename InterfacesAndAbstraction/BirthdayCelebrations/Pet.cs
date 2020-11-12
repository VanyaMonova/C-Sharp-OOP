using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Pet : IBirthable
    {
        public string Birhtdate { get; }

        string Name { get; }

        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birhtdate = birthdate;
        }
    }

}
