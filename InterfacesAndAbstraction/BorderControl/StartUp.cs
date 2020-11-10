using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IControlable> inhabitants = new List<IControlable>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs.Length == 3)
                {
                    string name = cmdArgs[0];
                    int age = int.Parse(cmdArgs[1]);
                    string id = cmdArgs[2];
                    Citizen citizen = new Citizen(name, age, id);
                    inhabitants.Add(citizen);
                }
                else if (cmdArgs.Length == 2)
                {
                    string model = cmdArgs[0];
                    string id = cmdArgs[1];
                    Robot robot = new Robot(model, id);
                    inhabitants.Add(robot);
                }
            }

            string fakeIdDigits = Console.ReadLine();

            foreach (var inhabitant in inhabitants)
            {
                if (inhabitant.Id.EndsWith(fakeIdDigits))
                {
                    Console.WriteLine(inhabitant.Id);
                }

            }
        }
    }
}
