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

        #region Global variable
        // Get the vaule from Juke_Box
        public ListBox[] lst_genre; 
        public string[] genre_titles;
        public int genre_maximum;
        public bool load_media;
        //for << Previous and Next >>
        public int Number_of_Genre;
        /* preinstall num of creating genres when loading Media at each time
        and not allow more than 10 genre can be create at once time in Set_up*/
        public int create_genre_limit;
        #endregion

        #region Initial stage
        /// <summary>
        /// 
        /// </summary>
        private void Set_up_Load(object sender, EventArgs e)
        {
            Number_of_Genre = 0;
            if (load_media == true)
            {
                display(Number_of_Genre);
            }
            if (genre_maximum == 0)
            {
                btn_Next_Title.Enabled = false;
            }               
        }

        //
        private void display(int Number_of_Genre)
        {
            lst_Blank_Templet.Items.Clear();
            txt_Title.Text = genre_titles[Number_of_Genre];
            for (int i = 0; i < lst_genre[Number_of_Genre].Items.Count; i++)
            {
                lst_Blank_Templet.Items.Add(lst_genre[Number_of_Genre].Items[i]);
            }
        }

        #endregion

        #region Import track from directory 
        /// <summary>
        /// Click the button to get list track from a file of currently dectory
        /// </summary>
        private void btn_Import_Tracks_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region << Previous 
        /// <summary>
        /// 
        /// </summary>
        private void btn_Previous_Title_Click(object sender, EventArgs e)
        {
            Number_of_Genre -= 1;
            display(Number_of_Genre);
            if (Number_of_Genre == 0)
            {
                btn_Previous_Title.Enabled = false;
            }
            btn_Next_Title.Enabled = true;
        }

        #endregion

        #region << Next title 
        /// <summary>
        /// 
        /// </summary>
        private void btn_Next_Title_Click(object sender, EventArgs e)
        {
            Number_of_Genre += 1;
            display(Number_of_Genre);
            if (Number_of_Genre == (genre_maximum))
            {
                btn_Next_Title.Enabled = false;
            }
            btn_Previous_Title.Enabled = true;
        }

        #endregion

        #region OK button
        /// <summary>
        /// 
        /// </summary>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion



    }
}
