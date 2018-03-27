using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Juke_Box
{
    public partial class Set_up : Form
    {
        public Set_up()
        {
            InitializeComponent();
        }

        #region Variables
        // Creat a 2D array to store the information in temporary about Title and Tracks 
        public string[,] Set_up_info;
        #endregion

        private void btn_OK_Click(object sender, EventArgs e)
        {
           // Set_up_info[0, 0] = "cas";
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Set_up_info[0, 0]);
        }
    }
}
