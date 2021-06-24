using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Vehicle.VehicleList = "FORM 1";
        } 


        

        private void Form1_Load(object sender, EventArgs e)
        {                      
            

            DG_VEHICLE.DataSource = Vehicle.VehicleList;            

            // METHOD 1 - EASY
            //List<Vehicle> records = vehicleList.
            //    Where(c => c.VehicleName.Contains("") | c.VehicleName == "CULT" | c.Price > 0).ToList();

            // METHOD 1 - INTERESTING
            //records = (from v in vehicleList
            //           where v.VehicleName.Contains("CIVIC") &
            //                v.Model != "2021"
            //           select v).ToList();

            // SELECT * FROM Vehicle WHERE VehicleName LIKE ‘%CIVIC%’ AND Model = '2021'

            //foreach (Vehicle item in myList)
            //{

            //    MessageBox.Show($" VEHICLE MadeBy: { item.MadeBy } and VehicleName is: { item.VehicleName } and so on...");

            //    // concaternation
            //}
        }

        

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            //;
            

            List<Vehicle> records = Vehicle.VehicleList
                .Where(c => 
                c.VehicleName.ToUpper().Contains(tbSearch.Text.ToUpper()) | 
                c.MadeBy.ToUpper().Contains(tbSearch.Text.ToUpper()) |
                c.Price.ToString().Contains(tbSearch.Text)
                ).ToList();
            DG_VEHICLE.DataSource = records;

            //DG_VEHICLE.Refresh();
        }

        private void tbPrice_TextChanged(object sender, EventArgs e)
        {
            //tbPrice.Text
            decimal price;
            
            if (!decimal.TryParse(tbPrice.Text, out price))
            {
                MessageBox.Show("Price Value is not a decimal number");
                tbPrice.Text = "";
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (tbVehicleName.Text == "" | tbMadeBy.Text == "" |
                tbModel.Text == "" | tbPrice.Text == "")
            {
                MessageBox.Show("Please entered required values.");
                return;
            }

            Vehicle vehicle = new Vehicle()
            {
                Id = 25,
                VehicleName = tbVehicleName.Text,
                Model = tbModel.Text,
                MadeBy = tbMadeBy.Text,
                Price = decimal.Parse(tbPrice.Text),
            };

            Vehicle.VehicleList.Add(vehicle);

            DG_VEHICLE.DataSource = new BindingSource(Vehicle.VehicleList, ""); ;
            //DG_VEHICLE.Refresh();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
    }
}
