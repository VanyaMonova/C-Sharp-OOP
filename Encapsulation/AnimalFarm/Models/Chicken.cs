﻿using System;

namespace AnimalFarm.Models
{
    public class Chicken
    {
        private const int MinAge = 0;
        private const int MaxAge = 15;

        private string name;
        private int age;

        public Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                ValidateName(value);
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                ValidateAge(value);
                this.age = value;
            }
        }

        public double ProductPerDay
        {
            get
            {
                return this.CalculateProductPerDay();
            }
        }


        public double CalculateProductPerDay()
        {
            switch (this.Age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;
                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;
                default:
                    return 0.75;
            }
        }
        private static void ValidateName(string value)
        {
            if (String.IsNullOrWhiteSpace(value) || String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty.");
            }
        }
        private void ValidateAge(int age)
        {
            if (age < MinAge || age > MaxAge)
            {
                throw new ArgumentException($"Age should be between {MinAge} and {MaxAge}.");
            }
        }
    }
}
