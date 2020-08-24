using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Tasks
    {
        public double Runtime;
        public double Runtimes;
        public double Energy;
        public bool allocated = false;
        public int ID { get; set; }

        public Tasks() { }
        public Tasks(int _ID)
        {
            ID = _ID;
        }

        public void showData()
        {

        }
    }
}
