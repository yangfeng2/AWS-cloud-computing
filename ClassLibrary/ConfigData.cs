using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class ConfigData
    {
        public List<string> Data = new List<string>();
        public List<double> runtimeList = new List<double>();
        public List<string> frequencyList = new List<string>();
        public List<Processors> processorsList = new List<Processors>();

        public int programProcessors;
        public int programTasks;
        public double runtimeFrequency;
        public double maxDuration;
        public double totalEnergy;

        public ConfigData(ConfigData cd)
        {
            Data = cd.Data;
            retrieveData();
        }


        public void FirstAllocation()
        {
            foreach (Tasks tasks in processorsList[0].Tasks)
                tasks.allocated = true;
        }

        public ConfigData() { }

        public string showData()
        {
            
            double energy = 0;
            double longgestruntime = 0;

            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder mainBuilder = new StringBuilder();

            foreach (Processors s in processorsList)
            {
                double runtime = 0;

                StringBuilder stringBuilder1 = new StringBuilder();
                foreach (Tasks t in s.Tasks)
                {
                    
                    stringBuilder1.Append(t.Runtimes).Append(", ");
                    if (t.allocated)
                    {
                        energy += t.Energy;
                        stringBuilder.Append("1").Append(", ");
                        runtime += t.Runtimes;

                    }
                    else
                    {
                        stringBuilder.Append("0").Append(", ");
                    }
                }
                if (runtime > longgestruntime)
                {
                    longgestruntime = runtime;
                }
                Console.WriteLine(stringBuilder1);
                Console.WriteLine(stringBuilder);
                stringBuilder.Append("\n");
                
            }
            mainBuilder.Append("Allocation ID = 1, Time = " + longgestruntime + ", Energy = " + energy).Append("\n");
            mainBuilder.Append(stringBuilder);
            Console.WriteLine(energy);
            if (totalEnergy != 1000000)
                totalEnergy = energy;
            return mainBuilder.ToString();
        }

        public void retrieveData()
        {
            for (int i = 0; i < Data.Count; i++)
            {
                //retrieve the program maximum duration
                string maxdurationSyntax = "PROGRAM-MAXIMUM-DURATION";
                if (Data[i].IndexOf(maxdurationSyntax) != -1)
                {
                    string[] parts = Data[i].Split(',');
                    string duration = parts[1];

                    maxDuration = Convert.ToDouble(duration);
                }

                //retrieve the program-tasks
                string programTasksSyntax = "PROGRAM-TASKS";
                if (Data[i].IndexOf(programTasksSyntax) != -1)
                {
                    string[] parts = Data[i].Split(',');
                    string result = parts[1];

                    programTasks = Convert.ToInt32(result);
                }

                //retrieve the program-processors
                string programProcessorsSyntax = "PROGRAM-PROCESSORS";
                if (Data[i].IndexOf(programProcessorsSyntax) != -1)
                {
                    string[] parts = Data[i].Split(',');
                    string result = parts[1];

                    programProcessors = Convert.ToInt32(result);
                }

                //retrieve the runtime data
                string runtimeSyntax = "TASK-ID,RUNTIME";
                if (Data[i] == runtimeSyntax)
                {
                    for (int task = 1; task <= programTasks; task++)
                    {
                        string[] separator = { task.ToString() + "," };
                        int count = programTasks;
                        string[] runtime = Data[i + task].Split(separator, count, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string s in runtime)
                            runtimeList.Add(Convert.ToDouble(s));
                    }
                }

                //retrieve the runtime reference frequency data
                string runtimeFreqSyntax = "RUNTIME-REFERENCE-FREQUENCY";
                if (Data[i].IndexOf(runtimeFreqSyntax) != -1)
                {
                    string[] parts = Data[i].Split(',');
                    runtimeFrequency = Convert.ToInt32(parts[1]);
                }

                //retrieve the frequency of processor
                string frequencySyntax = "PROCESSOR-ID,FREQUENCY";
                if (Data[i] == frequencySyntax)
                {
                    for (int processor = 1; processor <= programProcessors; processor++)
                    {
                        string[] separator = { processor.ToString() + "," };
                        int count = programTasks;
                        string[] runtime = Data[i + processor].Split(separator, count, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string s in runtime)
                            frequencyList.Add(s);
                    }
                }
            }

            //------------------------------- processing the processors ----------------------------------
            for (int i = 1; i <= frequencyList.Count; i++)
            {
                Processors processors = new Processors(i, Convert.ToDouble(frequencyList[i - 1]), maxDuration);
                processorsList.Add(processors);
            }

            //----------------------------- processing the task -----------------------
            foreach (Processors p in processorsList)
            {
                for (int i = 1; i <= runtimeList.Count; i++)
                {
                    Tasks task = new Tasks(i);
                    task.Runtime = runtimeList[i - 1];
                    task.Runtimes = Math.Round((double)task.Runtime * runtimeFrequency / p.Frequnecy, 2);
                    p.Tasks.Add(task);
                }

                p.TasksEnergy();
            }
        }
    }
}
