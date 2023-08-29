using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_App___Cold_Plunge_Tracker
{
    internal class ColdPlungeEntry
    {
        private DateTime _date;
        private TimeSpan _duration;
        private double _waterTemp;
        private string _notes;

        public DateTime Date { get => _date; set => _date = value; }
        public TimeSpan Duration { get => _duration; set => _duration = value; }
        public double WaterTemp { get => _waterTemp; set => _waterTemp = value; }
        public string Notes { get => _notes; set => _notes = value; }
    }
}
