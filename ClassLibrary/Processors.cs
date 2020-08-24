using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Processors
    {
        public int ID { get; set; }

        public double Frequnecy { get; set; }

        public double ProgramDuration { get; set; }

        public double TotalRuntimes;

        public List<Tasks> Tasks = new List<Tasks>();

        public Processors()
        {

        }

        public Processors(int _ID, double _frequency, double _Progduration)
        {
            ID = _ID;
            Frequnecy = _frequency;
            ProgramDuration = _Progduration;
        }

        public void TasksEnergy()
        {
            foreach (Tasks t in Tasks)
            {
                t.Energy = Math.Round((double)(10 * Frequnecy * Frequnecy + -25 * Frequnecy + 25) * t.Runtimes, 2);
            }
        }
    }
}
