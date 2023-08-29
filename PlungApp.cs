using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace Fitness_App___Cold_Plunge_Tracker
{
    internal class PlungApp
    {
        public void Start()
        {
            Console.Title = "Cold Plunge Tracker";
            RunMainMenu();
        }

        public void RunMainMenu()
        {
            string prompt = @"
  
   ___     _    _   ___ _                      _____            _           
  / __|___| |__| | | _ \ |_  _ _ _  __ _ ___  |_   _| _ __ _ __| |_____ _ _ 
 | (__/ _ \ / _` | |  _/ | || | ' \/ _` / -_)   | || '_/ _` / _| / / -_) '_|
  \___\___/_\__,_| |_| |_|\_,_|_||_\__, \___|   |_||_| \__,_\__|_\_\___|_|  
                                   |___/                                    
 

Welcome to the Cold Plunge Tracker. What would you like to do?

(Use the arrow keys to cycle through options below. Press enter to select an option.)";

            
            Console.ForegroundColor = ConsoleColor.Blue;
            

            string[] options = { "Log Cold Plunge Data", "Timer", "Guided Plunge", "Exit" };

            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            
            switch (selectedIndex)
            {
                case 0:
                    LogPlungeData();
                    break;
                case 1:
                    StartTimer();
                    break;
                case 2:
                    StartGuidedPlunge();
                    break;
                case 3:
                    ExitApp();
                    break;
            }
        }

        public async void LogPlungeData()
        {
            ColdPlungeEntry entry = new ColdPlungeEntry();  
            
            DateTime Date = DateTime.Now;
            entry.Date = Date;
            Console.WriteLine($"Date: {Date}");
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("\nDuration: ");
            TimeSpan Duration = TimeSpan.Parse(Console.ReadLine());
            entry.Duration = Duration;

            Console.WriteLine("\nTemperature: ");
            double WaterTemp = double.Parse(Console.ReadLine());
            entry.WaterTemp = WaterTemp;

            Console.WriteLine("\nNotes: ");
            string Notes = Console.ReadLine();
            entry.Notes = Notes;

            string fileName = "C:\\Plunge Data\\Plunge Data.json";
            var myFile = File.Create(fileName);
            FileStream createStream = myFile;
            await JsonSerializer.SerializeAsync(createStream, entry);
            createStream.Close();
            myFile.Close();
                
            
            Console.WriteLine(File.ReadAllText(fileName));
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Press any key to return to the main menu.");
            RunMainMenu();
        }

        private void StartTimer()
        {
            Console.WriteLine("Press any key to return to the main menu.");
            RunMainMenu();
        }

        private void StartGuidedPlunge()
        {
            string prompt = @"
  
   ___     _    _   ___ _                      _____            _           
  / __|___| |__| | | _ \ |_  _ _ _  __ _ ___  |_   _| _ __ _ __| |_____ _ _ 
 | (__/ _ \ / _` | |  _/ | || | ' \/ _` / -_)   | || '_/ _` / _| / / -_) '_|
  \___\___/_\__,_| |_| |_|\_,_|_||_\__, \___|   |_||_| \__,_\__|_\_\___|_|  
                                   |___/                                   


Please choose from the menu below";
            
            string[] options = { "2 Minute Guided Plunge", "3 Minute Guided Plunge", "4 Minute Guided Plunge", "Mediation - Healing", "Meditation - Letting Go",
                "Return to Main Menu" };
            Menu guidedMenu = new Menu(prompt, options);
            int selectedIndex = guidedMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    MethodUtilities.TwoMinGuided();                    
                    break;
                case 1:
                    MethodUtilities.ThreeMinGuided();
                    break;
                case 2:
                    MethodUtilities.FourMinGuided();
                    break;
                case 3:
                    MethodUtilities.HealingMeditation();
                    break;
                case 4:
                    MethodUtilities.LetGoMeditation();
                    break;
                case 5:
                    RunMainMenu();
                    break;
            }                
        }

        private void ExitApp()
        {
            Console.WriteLine("Are you sure you would like to exit?");
            Console.ReadKey(true);
            Console.WriteLine("Exiting....");
            Environment.Exit(0);
        }
    }
}
