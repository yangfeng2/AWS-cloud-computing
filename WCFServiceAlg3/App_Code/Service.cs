using ClassLibrary;
using System;
using System.Collections.Generic;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    //--------------------------- Alogrithm 3 ------------------------
    public ConfigData GetAllocations(ConfigData cd)
    {
        //---------------------------------- allocating ------------------------------

        int[] runtime = new int[cd.programTasks];
        int[] energy = new int[cd.programTasks];

        for (int a = 0; a < cd.processorsList[0].Tasks.Count; a++)
        {
            runtime[a] = Convert.ToInt32(cd.processorsList[0].Tasks[a].Runtimes);
            energy[a] = Convert.ToInt32(cd.processorsList[0].Tasks[a].Energy);
        }


        List<int> output = new List<int>();
        List<int> allocatedID = new List<int>();

        printknapSack(Convert.ToInt32(cd.maxDuration - 1), runtime, energy, cd.programTasks, output);
        foreach (int i in output)
            Console.WriteLine(i);

        foreach (int i in output)
        {
            cd.processorsList[0].Tasks[i].allocated = true;
            allocatedID.Add(i + 1);
        }

        

        for (int i = 1; i < cd.processorsList.Count; i++)
        {
            double totalRuntimes = 0;
            foreach (ClassLibrary.Tasks t in cd.processorsList[i].Tasks)
            {
                if (!allocatedID.Contains(t.ID))
                {
                    t.allocated = true;
                    allocatedID.Add(t.ID);
                    totalRuntimes += t.Runtimes;
                    if (totalRuntimes >= cd.maxDuration)
                    {
                        t.allocated = false;
                        allocatedID.Remove(t.ID);
                    }
                }
            }
        }

        for (int a = 1; a <= cd.programTasks; a++)
        {
            if (!allocatedID.Contains(a))
            {
                cd.totalEnergy = 1000000;
            }
        }


        return cd;
    }

    public void printknapSack(int W, int[] wt,
                            int[] val, int n, List<int> output)
    {
        int i, w;
        int[,] K = new int[n + 1, W + 1];

        // Build table K[][] in bottom up manner  
        for (i = 0; i <= n; i++)
        {
            for (w = 0; w <= W; w++)
            {
                if (i == 0 || w == 0)
                    K[i, w] = 0;
                else if (wt[i - 1] <= w)
                    K[i, w] = Math.Max(val[i - 1] +
                            K[i - 1, w - wt[i - 1]], K[i - 1, w]);
                else
                    K[i, w] = K[i - 1, w];
            }
        }

        // stores the result of Knapsack  
        int res = K[n, W];

        w = W;
        for (i = n; i > 0 && res > 0; i--)
        {

            // either the result comes from the top  
            // (K[i-1][w]) or from (val[i-1] + K[i-1]  
            // [w-wt[i-1]]) as in Knapsack table. If  
            // it comes from the latter one/ it means  
            // the item is included.  
            if (res == K[i - 1, w])
                continue;
            else
            {

                // This item is included.  
                output.Add(i - 1);

                // Since this weight is included its  
                // value is deducted  
                res = res - val[i - 1];
                w = w - wt[i - 1];
            }
        }
    }

    public string GetIPAddress()
    {
        return "VM1: 172.31.44.219\nVM2: 172.31.45.190\nVM3: 172.31.41.238";
    }
}
