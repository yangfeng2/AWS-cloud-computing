using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT323___Assignment_2
{
    public partial class Form1 : Form
    {
        //---------------------- variable ---------------------------
        ConfigData configData = new ConfigData();

        public Form1()
        {
            InitializeComponent();
         
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
;

            string source = comboBox1.Text;

            WebClient webClient = new WebClient();
            Stream stream = webClient.OpenRead(source);
            StreamReader streamReader = new StreamReader(stream);

            while (!streamReader.EndOfStream)
                configData.Data.Add(streamReader.ReadLine());
            streamReader.Close();

            //retrieve the data
            configData.retrieveData();

            //-----get the service from the laod balance 1 http://sit323lb-275663418.us-east-1.elb.amazonaws.com/WCFServiceAlg1/Service.svc
            AwsWebServer1.ServiceClient service = new AwsWebServer1.ServiceClient();

            //-----get the service from the load balance 2 http://sit323lb2-2035790830.us-east-1.elb.amazonaws.com/WCFServiceAlg2/Service.svc
            AwsWebServer2.ServiceClient service2 = new AwsWebServer2.ServiceClient();

            //-----get the service from the load balance 3 http://sit323lb3-414064062.us-east-1.elb.amazonaws.com/WCFServiceAlg3/Service.svc
            AwsWebServer3.ServiceClient service3 = new AwsWebServer3.ServiceClient();

            //------ local web server ----------------------
            //DemoWebServer1.ServiceClient service = new DemoWebServer1.ServiceClient();
            //DemoWebServer2.ServiceClient service2 = new DemoWebServer2.ServiceClient();
            //DemoWebServer3.ServiceClient service3 = new DemoWebServer3.ServiceClient();

            //return the config file which already allocated from the web server
            ConfigData cd = service.GetAllocations(configData);
            ConfigData cd2 = service2.GetAllocations(configData);
            ConfigData cd3 = service3.GetAllocations(configData);     

            //a list to save the config file
            List<ConfigData> configList = new List<ConfigData>();
            configList.Add(cd);
            configList.Add(cd2);
            configList.Add(cd3);

            foreach (ConfigData c in configList)
                c.showData();

            //find the minimum energy
            double minenergy = configList.Min(a => a.totalEnergy);
            Console.WriteLine(minenergy);

            foreach (ConfigData c in configList)
            {
                if (c != null)
                {                  
                    if (c.totalEnergy == minenergy)
                    {
                        if (configList.IndexOf(c) == 0)
                        {
                            //show ip address
                            var result = MessageBox.Show(service.GetIPAddress(), "Privare IPs of AWS VMs", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                richTextBox1.Text = c.showData();
                            }
                        }
                        else if (configList.IndexOf(c) == 1)
                        {
                            //show ip address
                            var result = MessageBox.Show(service2.GetIPAddress(), "Privare IPs of AWS VMs", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                richTextBox1.Text = c.showData();
                            }
                        }
                        else if (configList.IndexOf(c) == 2)
                        {
                            //show ip address
                            var result = MessageBox.Show(service3.GetIPAddress(), "Privare IPs of AWS VMs", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                richTextBox1.Text = c.showData();
                            }
                        }
                    }
                }
            }

            button1.Enabled = false;
        }


        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.Show();
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
