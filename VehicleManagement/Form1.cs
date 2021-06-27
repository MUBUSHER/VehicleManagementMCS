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


        void BindDataGridView(List<Vehicle> vehList)
        {
            DG_VEHICLE.DataSource = new BindingSource(vehList, "");

        }

        private void Form1_Load(object sender, EventArgs e)
        {



            //Vehicle.VehicleList.Where()











            BindDataGridView(Vehicle.VehicleList);

            DG_VEHICLE.Columns[1].Width = 250;
            DG_VEHICLE.Columns[1].HeaderText = "VEHICLE COMPANY NAME";

            foreach (DataGridViewColumn gvColumn in DG_VEHICLE.Columns)
            {
                gvColumn.ReadOnly = true;
            }



            DG_VEHICLE.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "Selected ",

            });
            //DG_VEHICLE.Rows
            //DG_VEHICLE.Columns

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
            List<Vehicle> records = Vehicle.VehicleList
                .Where(c =>
                c.VehicleName.ToUpper().Contains(tbSearch.Text.ToUpper()) | // condition
                c.MadeBy.ToUpper().Contains(tbSearch.Text.ToUpper()) | // condition2
                c.Price.ToString().Contains(tbSearch.Text) // condition 3
                ).ToList();
            BindDataGridView(records);

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

            //tbPrice.Text
            decimal price;

            if (!decimal.TryParse(tbPrice.Text, out price))
            {
                MessageBox.Show("Price Value is not a decimal number", "COMAPPA");
                tbPrice.Text = "";
                return;
            }

            if (tbId.Text == "")
            {
                Vehicle vehicle = new Vehicle()
                {
                    Id = 25,
                    VehicleName = tbVehicleName.Text,
                    Model = tbModel.Text,
                    MadeBy = tbMadeBy.Text,
                    Price = decimal.Parse(tbPrice.Text),
                };

                Vehicle.VehicleList.Add(vehicle);

            }
            else
            {
                // update mode;
                Vehicle vehicle = Vehicle.VehicleList.FirstOrDefault(c => c.Id.ToString() == tbId.Text);
                vehicle.Id = int.Parse(tbId.Text);
                vehicle.VehicleName = tbVehicleName.Text;
                vehicle.Model = tbModel.Text;
                vehicle.MadeBy = tbMadeBy.Text;
                vehicle.Price = decimal.Parse(tbPrice.Text);
            }

            DG_VEHICLE.DataSource = new BindingSource(Vehicle.VehicleList, ""); ;
            //DG_VEHICLE.Refresh();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tbId.Text = "";

            button1.Text = "Add Vehicle";
            tbId.Text = "";
            tbMadeBy.Text = "";
            tbVehicleName.Text = "";
            tbModel.Text = "";
            tbPrice.Text = "0";

        }

        private void DG_VEHICLE_SelectionChanged(object sender, EventArgs e)
        {

            //int rowIndex = DG_VEHICLE.CurrentRow.Index;
            //int columnIndex = DG_VEHICLE.CurrentRow.Cells[0].ColumnIndex;

            if (DG_VEHICLE.SelectedRows.Count != 0)
            {
                tbId.Text = DG_VEHICLE.SelectedRows[0].Cells[0].Value.ToString();
                tbMadeBy.Text = DG_VEHICLE.SelectedRows[0].Cells[1].Value.ToString();
                tbVehicleName.Text = DG_VEHICLE.SelectedRows[0].Cells[2].Value.ToString();
                tbModel.Text = DG_VEHICLE.SelectedRows[0].Cells[3].Value.ToString();
                tbPrice.Text = DG_VEHICLE.SelectedRows[0].Cells[4].Value.ToString();

                button1.Text = "Edit Vehicle";
            }


        }

        private void removeVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult dlg = MessageBox.Show($"are you sure you want to delete Id: {DG_VEHICLE.SelectedRows[0].Cells[0].Value  } record?",
                "Vehicle Management",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {

                Vehicle.VehicleList.RemoveAll(c => c.Id.ToString() == tbId.Text);

                DG_VEHICLE.DataSource = new BindingSource(Vehicle.VehicleList, "");
            }

            if (DG_VEHICLE.Rows.Count == 0)
            {

                tbId.Text = "";

                button1.Text = "Add Vehicle";
                tbId.Text = "";
                tbMadeBy.Text = "";
                tbVehicleName.Text = "";
                tbModel.Text = "";
                tbPrice.Text = "0";

            }
        }
    }
}
