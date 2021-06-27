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
    public partial class frmVehicle : Form
    {
        public frmVehicle()
        {
            InitializeComponent();
        }

        private void frmVehicle_Load(object sender, EventArgs e)
        {
            
            
            
            DG_VEHICLE.DataSource = Vehicle.VehicleList;
        }

        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            tbSearch.BackColor = Color.Brown;
            DG_VEHICLE.DataSource = Vehicle.VehicleList.Where(c=> 
            c.VehicleName.ToLower().Contains(tbSearch.Text.ToLower()) |
            c.MadeBy.ToLower().Contains(tbSearch.Text.ToLower()) 
            ).ToList();
            
        }
    }
}
