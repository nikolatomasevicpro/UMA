using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UMA.ToolBox
{
    class Program
    {
        private static List<MethodInfo> _methods;
        private static string _optionSufix = @"Option";
        private static string _quitOption = @"exit";
        private static string _yesChoice = @"y";
        private static string _noChoice = @"n";

        static void Main(string[] args)
        {
            bool repeat = false;
            var allMethods = typeof(Program).GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            _methods = allMethods.Where(m => m.Name.EndsWith(_optionSufix)).ToList();

            do
            {
                repeat = MainMenu();
            } while (repeat);
            
        }

        private static bool MainMenu()
        {
            Console.WriteLine(@"Please choose from the menu by entering the corresponding number :");
            for (int i = 0; i < _methods.Count; i++)
            {
                Console.WriteLine($"{i} - {_methods[i].Name.Replace(_optionSufix, string.Empty)}");
            }
            Console.WriteLine($"{_quitOption} - quit the application");

            var choice = Console.ReadLine();

            if (choice.ToLower() == _quitOption)
            {
                Console.WriteLine(@"Stopping the application...");
                return false;
            }

            int choiceNumber;
            bool valid = int.TryParse(choice, out choiceNumber);

            if(!valid || choiceNumber < 0 || choiceNumber >= _methods.Count)
            {
                Console.WriteLine($"\"{choice}\" is an unrecognized choice. Please select from the available choices only");
                return true;
            }

            var method = _methods[choiceNumber];
            bool repeatMethod = false;

            do
            {
                method.Invoke(null, null);
                Console.WriteLine($"Would you like to repeat the option ({_yesChoice}/{_noChoice.ToUpper()})?");
                var repeatChoice = Console.ReadLine().ToLower();
                repeatMethod = repeatChoice == _yesChoice;
            } while (repeatMethod);

            Console.WriteLine($"Would you like to choose another option ({_yesChoice}/{_noChoice.ToUpper()})?");
            var finalChoice = Console.ReadLine().ToLower();
            return finalChoice == _yesChoice;
        }

        private static void GenerateGUIDOption()
        {
            bool repeat = false;

            do
            {
                Console.WriteLine(Guid.NewGuid().ToString());

                Console.WriteLine($"Would you like to generate another GUID? ({_yesChoice}/{_noChoice.ToUpper()})");
                var choice = Console.ReadLine().ToLower();
                repeat = choice == _yesChoice;

            } while (repeat);
        }
    }
}
