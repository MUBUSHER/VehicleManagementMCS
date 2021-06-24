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
    public partial class form2 : Form
    {
        
        Vehicle _vehicle;
        public form2(Vehicle vehicle)
        {
            _vehicle = vehicle;
            InitializeComponent();

            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string abc;
            

            string chesisNo = _vehicle.GetChesisNo();
            MessageBox.Show(chesisNo);
            //name = "";
        }
        
    }
}
