using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_App___Cold_Plunge_Tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlungApp plungApp = new PlungApp();
            plungApp.Start();
        }    
        
        public static void LogPlungeEntries()
        {
            while(true)
            {
                Console.WriteLine();
            }
        }

       

        
        

        
    }
}
