using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Juke_Box
{
    public partial class Set_up : Form
    {
        public Set_up()
        {
            InitializeComponent();
        }

        #region Global variable
        // Get this vaule from Juke_Box
        public string media_Path;
        public ListBox[] lst_media; 
        public string[] genre_titles;
        public int genre_max;
        public bool load_media;
        //for << Previous and Next >>
        public int Number_of_Genre;
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
                Select_Num_display(Number_of_Genre);
            }
        }

        #endregion

        #region Import & Clear track 

        /// <summary>
        /// Click the button to get list track from 
        /// a file of currently dectory
        /// </summary>
        private void btn_Import_Tracks_Click(object sender, EventArgs e)
        {
            Open_tracks();
        }

        // Open a folder and put data to the listbox
        private void Open_tracks()
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in Directory.EnumerateFiles(folderBrowserDialog.SelectedPath, "*.*", SearchOption.AllDirectories).Where
                        (a => a.EndsWith(".mp3") || a.EndsWith(".wma") || a.EndsWith(".wav") || a.EndsWith(".MP3") || a.EndsWith(".WMA") || a.EndsWith(".WAV")))
                {
                    lst_Read_File.Items.Add(file);
                }
                if (lst_Read_File.Items.Count > 0)
                {
                    btn_Import_Tracks.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No songs in the folder !");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void btn_Clear_Tracks_Click(object sender, EventArgs e)
        {
            lst_Read_File.Items.Clear();
            btn_Import_Tracks.Enabled = true;
        }

        #endregion

        #region MyRegion

        #endregion

        #region << Previous - Next title >>

        /// <summary>
        /// 
        /// </summary>
        private void btn_Previous_Title_Click(object sender, EventArgs e)
        {
            Number_of_Genre -= 1;
            Select_Num_display(Number_of_Genre);

            if (Number_of_Genre == 0)
            {
                btn_Previous_Title.Enabled = false;
            }
            btn_Next_Title.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void btn_Next_Title_Click(object sender, EventArgs e)
        {
            if (genre_max > 0){ Number_of_Genre += 1;} 
            Select_Num_display(Number_of_Genre);

            if (Number_of_Genre == (genre_max))
            {
                btn_Next_Title.Enabled = false;
            }
            btn_Previous_Title.Enabled = true;
        }

        //
        private void Select_Num_display(int Number_of_Genre)
        {
            lst_Blank_Templet.Items.Clear();

            txt_Title.Text = genre_titles[Number_of_Genre];

            int max_index = lst_media[Number_of_Genre].Items.Count;
            int items_index = 0;
            while (items_index < max_index)
            {
                lst_Blank_Templet.Items.Add(lst_media[Number_of_Genre].Items[items_index]);
                items_index += 1;
            }
        }
        #endregion

        #region OK & Cancle - Button

        /// <summary>
        /// 
        /// </summary>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

       
    }
}
