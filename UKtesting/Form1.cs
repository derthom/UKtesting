using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UKtesting.ServiceReference1;

namespace UKtesting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ukxml = XDocument.Load(@"C:\Users\derrthom\Desktop\data.xml");

            var county = from c in ukxml.Root.Descendants("Table") select c.Element("County").Value;
            var town = from c in ukxml.Root.Descendants("Table") select c.Element("Town").Value;
            var pc = from c in ukxml.Root.Descendants("Table") select c.Element("PostCode").Value;
            foreach (string key1 in county)
            comboBox1.Items.Add(key1);
            //var town = from c in ukxml.Root.Descendants("Table") where c.Element("County").Value = (comboBox1.SelectedText.ToUpper()) select c.Element("Town").Value;
            foreach (string key2 in town )
                //var town1= from c in ukxml.Root.Descendants("Table") where (string)c.Attribute("Town")=
               //comboBox2.Items.Add(ukxml.Root.Descendants("Table").Select(x=>x.Element("Town")).Where(y=>y.Element("County")=))
                comboBox2.Items.Add(key2);
            foreach (string key3 in pc)
                comboBox3.Items.Add(key3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.UKLocationSoapClient kkk = new ServiceReference1.UKLocationSoapClient("UKLocationSoap12");
            string c = comboBox1.SelectedItem.ToString();
            Console.WriteLine(c);
            string t = comboBox2.SelectedItem.ToString();
            string p = comboBox3.SelectedItem.ToString();
            string result = kkk.ValidateUKAddress(t,c,p);
             if(result== "<NewDataSet />")
             {
                richTextBox1.Text = "NOT A VALID ADDRESS";
             }
             else
             {
               richTextBox1.Text = "SUCCESSFULLY VALIDATED";
             }  
            
            
        }
    }
}
