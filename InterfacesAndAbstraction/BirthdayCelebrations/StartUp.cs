using System;
using System.Collections.Generic;

namespace BirthdayCelebrations

{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> inhabitants = new List<IBirthable>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string inhabitant = cmdArgs[0];

                if (inhabitant == "Citizen")
                {
                    string name = cmdArgs[1];
                    int age = int.Parse(cmdArgs[2]);
                    string id = cmdArgs[3];
                    string birthdate = cmdArgs[4];
                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    inhabitants.Add(citizen);
                }
              
                else if (inhabitant == "Pet")
                {
                    string name = cmdArgs[1];
                    string birthdate = cmdArgs[2];
                    Pet pet = new Pet(name, birthdate);
                    inhabitants.Add(pet);
                }
            }

            string birthYear = Console.ReadLine();

            foreach (var inhabitant in inhabitants)
            {
                if (inhabitant.Birhtdate.EndsWith(birthYear))
                {
                    Console.WriteLine(inhabitant.Birhtdate);
                }

            }
        }
    }
}
