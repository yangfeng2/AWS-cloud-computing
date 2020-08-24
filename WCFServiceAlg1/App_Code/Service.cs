using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
        //---------------------------- Algorithm 1 ------------------------------
        //a list to save the task which are allocated
        List<int> allocatedID = new List<int>();

        for (int a = configData.programProcessors; a > 0; a--)
        {
            double totalRuntimes = 0;
            for (int b = configData.programTasks; b > 0; b--)
            {
                if (!allocatedID.Contains(configData.processorsList[a - 1].Tasks[b - 1].ID))
                {
                    configData.processorsList[a - 1].Tasks[b - 1].allocated = true;
                    totalRuntimes += configData.processorsList[a - 1].Tasks[b - 1].Runtimes;
                    allocatedID.Add(configData.processorsList[a - 1].Tasks[b - 1].ID);
                }
                if (totalRuntimes > configData.maxDuration)
                {
                    configData.processorsList[a - 1].Tasks[b - 1].allocated = false;
                    totalRuntimes -= configData.processorsList[a - 1].Tasks[b - 1].Runtimes;
                    allocatedID.Remove(configData.processorsList[a - 1].Tasks[b - 1].ID);
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
        return "VM1: 172.31.38.95\nVM2: 172.31.46.31\nVM3: 172.31.37.151";
    }
}

