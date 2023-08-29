using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;


namespace Fitness_App___Cold_Plunge_Tracker
{
    internal class MethodUtilities
    {
        public static void PlayMusic(string filepath)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = filepath;
            player.Play();
        }

        public static void StopMusic(string filepath)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = filepath;
            player.Stop();
        }

        public static void TwoMinGuided()
        {
            string prompt = @"
  
   ___     _    _   ___ _                      _____            _           
  / __|___| |__| | | _ \ |_  _ _ _  __ _ ___  |_   _| _ __ _ __| |_____ _ _ 
 | (__/ _ \ / _` | |  _/ | || | ' \/ _` / -_)   | || '_/ _` / _| / / -_) '_|
  \___\___/_\__,_| |_| |_|\_,_|_||_\__, \___|   |_||_| \__,_\__|_\_\___|_|  
                                   |___/                                   


Please choose from the menu below";

            string[] options = { "Play", "Stop", "Log Plunge Data", "Return to Main Menu" };
            Menu twoGuidedMenu = new Menu(prompt, options);
            int selectedIndex = twoGuidedMenu.Run();
            PlungApp plungApp = new PlungApp();

           
                
                switch (selectedIndex)
                {
                    case 0:
                        PlayMusic("2 Minute Guided.wav");
                        selectedIndex = twoGuidedMenu.Run();
                    switch (selectedIndex)
                    {
                        case 1:
                            StopMusic("2 Minute Guided.wav");
                            selectedIndex = twoGuidedMenu.Run();
                            switch (selectedIndex)
                            {                                
                                case 2:
                                    plungApp.LogPlungeData();
                                    plungApp.RunMainMenu();
                                    break;
                                case 3:
                                    plungApp.RunMainMenu();
                                    break;
                            }
                            break;
                        case 2:
                            plungApp.LogPlungeData();
                            plungApp.RunMainMenu();
                            break;
                        case 3:
                            plungApp.RunMainMenu();
                            break;
                    }
                        break;
                    case 1:
                        StopMusic("2 Minute Guided.wav");
                        selectedIndex = twoGuidedMenu.Run();
                        break;
                    case 2:
                        plungApp.LogPlungeData();
                        plungApp.RunMainMenu();
                        break;
                    case 3:
                        plungApp.RunMainMenu();
                        break;
                }
                
            
            
            
            
        }

        public static void ThreeMinGuided()
        {

        }

        public static void FourMinGuided()
        {

        }

        public static void HealingMeditation()
        {

        }

        public static void LetGoMeditation()
        {

        }
    }
}
