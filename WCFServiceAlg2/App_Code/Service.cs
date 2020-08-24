using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    public ConfigData GetAllocations(ConfigData configData)
    {
        //---------------------------------- allocating ------------------------------
        //---------------------------------- alogrithm 2 -----------------------------
        //a list to save the task which are allocated
        List<int> allocatedID = new List<int>();

        for (int a = 0; a < configData.programProcessors; a++)
        {
            double totalRuntimes = 0;
            for (int b = configData.programTasks; b > 0; b--)
            {
                if (!allocatedID.Contains(configData.processorsList[a].Tasks[b - 1].ID))
                {
                    configData.processorsList[a].Tasks[b - 1].allocated = true;
                    totalRuntimes += configData.processorsList[a].Tasks[b - 1].Runtimes;
                    allocatedID.Add(configData.processorsList[a].Tasks[b - 1].ID);
                }
                if (totalRuntimes > configData.maxDuration)
                {
                    configData.processorsList[a].Tasks[b - 1].allocated = false;
                    totalRuntimes -= configData.processorsList[a].Tasks[b - 1].Runtimes;
                    allocatedID.Remove(configData.processorsList[a].Tasks[b - 1].ID);
                }
            }
           
        }

        for (int a = 1; a <= configData.programTasks; a++)
        {
            if (!allocatedID.Contains(a))
            {
                configData.totalEnergy = 1000000;
            }
        }

        return configData;
    }

    public string GetIPAddress()
    {
        return "VM1: 172.31.35.81\nVM2: 172.31.45.115\nVM3: 172.31.39.129";
    }
	
}
