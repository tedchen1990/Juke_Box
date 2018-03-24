using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Juke_Box;
using System.IO;

namespace Juke_Box
{
    public partial class Juke_Box : Form
    {
        public Juke_Box()
        {
            InitializeComponent();
        }

        #region Variables
        // Creat a 2D array to store the information about Title and Tracks 
        string[,] title_track;
        #endregion

        #region Initial stage

        /// <summary>
        /// Running the event first when the program starts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Juke_Box_Load(object sender, EventArgs e)
        {

        }

        // Method: Get the information into 2D array from Media and Tracks folder
        private void store_infromation()
        {
            // The media floder of information is already made in this path
            string InfoPath = Directory.GetCurrentDirectory() + "\\Media\\";
            // Open the file 
            StreamReader media = File.OpenText(InfoPath + "Media.txt");
            //
            title_track = new string[,] { };
            //lineOfText = media.ReadLine();
           // while (lineOfText != null)
            //{
                //string[,] title_track[] = { {lineOfText} };
            //}
            media.Close();
        }
        #endregion

        #region Menus

        /// <summary>
        /// Clicking event of Set up to show the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // The methos of showing the window 
            Set_up set_up = new Set_up();
            set_up.ShowDialog();
        }

        /// <summary>
        /// Clicking event of About to show the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(lineOfText);
        }
    }
}
