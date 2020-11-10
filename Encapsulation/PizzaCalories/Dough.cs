using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double BaseCaloriesPerGram = 2;
        private const double MinGrams = 1;
        private const double MaxGrams = 200;
        
        private readonly Dictionary<string, double> DefaultFlourTypes = new Dictionary<string, double>
        {
            { "white", 1.5},
            { "wholegrain", 1.0}
        };

        private readonly Dictionary<string, double> DefaultBakingTechniques = new Dictionary<string, double>
        {
            {"crispy", 0.9},
            {"chewy", 1.1},
            {"homemade", 1.0}
        };

        private string flourType;
        private string bakingTechnique;
        private double grams;

        public Dough(string flourtype, string bakingTechnique, double grams)
        {
            this.FlourType = flourtype;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }

        public string FlourType
        {
            get { return this.flourType; }
            private set 
            {
                if (!this.DefaultFlourTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value.ToLower(); 
            }
        }

        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            private set
            {
                if (!this.DefaultBakingTechniques.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value.ToLower();
            }
        }

        public double Grams
        {
            get { return this.grams; }
            private set
            {
                if (value < MinGrams || value > MaxGrams)
                {
                    throw new ArgumentException($"Dough weight should be in the range[{MinGrams}..{MaxGrams}].");
                }

                this.grams = value;
            }
        }
        public double Calories => (BaseCaloriesPerGram * this.Grams)
                * this.DefaultFlourTypes [this.FlourType]
                * this.DefaultBakingTechniques[this.BakingTechnique];

        }
}
