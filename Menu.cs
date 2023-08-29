using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_App___Cold_Plunge_Tracker
{
    internal class Menu
    {
        private int _SelectedIndex;
        private string[] _options;
        private string _prompt;

        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options; 
            _SelectedIndex = 0;
        }

        public string Prompt { get => _prompt; set => _prompt = value; }
        public string[] Options { get => _options; set => _options = value; }

        private void DisplayOptions()
        {
            Console.WriteLine(Prompt);

            for(int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;

                if(i == _SelectedIndex)
                {
                    prefix = "**";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor= ConsoleColor.Black;
                }
                Console.WriteLine($"{prefix} <{currentOption}> {prefix}");
            }
            Console.ResetColor();
            
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();
                Console.ForegroundColor = ConsoleColor.Blue;

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                // Update selectedIndex based on arrow keys.
                if(keyPressed == ConsoleKey.UpArrow)
                {
                    _SelectedIndex--;
                    if( _SelectedIndex == -1)
                    {
                        _SelectedIndex = Options.Length - 1;
                    }
                }
                else if(keyPressed == ConsoleKey.DownArrow)
                {
                    _SelectedIndex++;
                    if(_SelectedIndex == Options.Length)
                    {
                        _SelectedIndex = 0;
                    }
                }
            }
            while (keyPressed != ConsoleKey.Enter);

            return _SelectedIndex;
        }
    }
}
