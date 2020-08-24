using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

    [OperationContract]
    ConfigData GetAllocations(ConfigData cd);
    [OperationContract]
    string GetIPAddress();

}
    [DataContract]
    public class Processors
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public double Frequnecy { get; set; }

        [DataMember]
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
[DataContract]
public class Tasks
{
    public double Runtime;
    public double Runtimes;
    public double Energy;
    public bool allocated = false;

    [DataMember]
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





