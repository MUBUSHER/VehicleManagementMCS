using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vehicle vehicle = new Vehicle();
            

            

            vehicle.ChesisNo = "";
            

            form2 frm2 = new form2(vehicle);
            frm2.Show();

            int[] integerList = new int[] {
                1,
                2,
                3,
                4,
                5
            };
            string[] stringList = new string[] {
                "VARIABKLE 1.3",
                "VARIABKLE 1.4",
                "VARIABKLE 1.5",
                "VARIABKLE 2",
                "VARIABKLE 3",
            };

            

            List<string> list = new List<string>();
            list.Add("");

            foreach (string item in stringList)
            {
                MessageBox.Show(item);
            }

            List<int> intlist = new List<int>();
            intlist.Add(5);





        }
    }
}
