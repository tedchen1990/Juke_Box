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
        // can know edit is true or not
        public bool edit = false;
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
                // can't set into the track file over 100 songs at once time 
            }
        }

        #endregion

        #region Import & Clear track - Buttons

        /// <summary>
        /// Click the button to get list track from 
        /// a file of currently dectory
        /// </summary>
        private void btn_Import_Tracks_Click(object sender, EventArgs e)
        {
            if (load_media == true)
            {
                Open_tracks();
            }
            else { MessageBox.Show("No titles ! Please create a genre first !","Wraning"); }
           
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

        #region Coyp & Move & Detele Track  
        private void btn_Coyp_Track_Click(object sender, EventArgs e)
        {
            // 0 is coyp path
            add_track(0);
        }

        private void btn_Move_Track_Click(object sender, EventArgs e)
        {
            // 1 is move path
            add_track(1);
        }

        private void btn_Delete_Track_Click(object sender, EventArgs e)
        {
            // delete songs
            delete_track();
        }

        private void add_track(int put_way)
        {
            int Track_index = lst_Read_File.SelectedIndex;
            if (Track_index > -1)
            {
                string song_path = lst_Read_File.Items[Track_index].ToString();
                string song_name = song_path.Substring(song_path.LastIndexOf("\\") + 1);

                lst_media[Number_of_Genre].Items.Add(song_name);
                Select_Num_display(Number_of_Genre);
                edit = true;

                string new_path = media_Path + "\\Tracks\\" + song_name;
                if (File.Exists(new_path) == false)
                {
                    if (put_way == 0)
                    {
                        File.Copy(song_path, new_path);
                    }
                    else if (put_way == 1)
                    {
                        File.Move(song_path, new_path);
                    }
                }     
            }
            else { MessageBox.Show("You must to select one !", "Warning"); }
        }

        private void delete_track()
        {
            int Track_index = lst_Blank_Templet.SelectedIndex;
            if (Track_index > -1)
            {
                string song_name = lst_Blank_Templet.Items[Track_index].ToString();

                lst_media[Number_of_Genre].Items.RemoveAt(Track_index);
                Select_Num_display(Number_of_Genre);
                edit = true;
            }
            else { MessageBox.Show("You must to select one !", "Warning"); }
        }

        #endregion

        #region << Previous - Next title >>

        /// <summary>
        /// 
        /// </summary>
        private void btn_Previous_Title_Click(object sender, EventArgs e)
        {
            Number_of_Genre -= 1;
            Select_Num_display(Number_of_Genre);
            btn_Next_Title.Enabled = true;
            if (Number_of_Genre == 0)
            {
                btn_Previous_Title.Enabled = false;
            }  
        }

        /// <summary>
        /// 
        /// </summary>
        private void btn_Next_Title_Click(object sender, EventArgs e)
        {
            if (genre_max > 0)
            {
                Number_of_Genre += 1;
                Select_Num_display(Number_of_Genre);
                btn_Previous_Title.Enabled = true;
                if (Number_of_Genre == (genre_max))
                {
                    btn_Next_Title.Enabled = false;
                }    
            }   
        }

        //
        private void Select_Num_display(int Number_of_Genre)
        {
            lst_Blank_Templet.Items.Clear();

            txt_Title.Text = genre_titles[Number_of_Genre];

            int max_index = lst_media[Number_of_Genre].Items.Count;
            int index = 0;
            while (index < max_index)
            {
                lst_Blank_Templet.Items.Add(lst_media[Number_of_Genre].Items[index]);
                index += 1;
            }
        }

        #endregion

        #region OK & Cancle - Buttons

        /// <summary>
        /// 
        /// </summary>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (edit == true)
            {
                DialogResult comfrim = MessageBox.Show("You have edited songs. Are you sure?", "Prompt", MessageBoxButtons.OKCancel);
                if (comfrim == DialogResult.OK)
                {
                    // real_input();
                }
            }
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (edit == true)
            {
                DialogResult comfrim = MessageBox.Show("You have edited songs. Do you want to save your change?", "Warning", MessageBoxButtons.OKCancel);
                if (comfrim == DialogResult.OK)
                {
                    // real_input();
                }
            }
            this.Close();
        }

        private void real_input()
        {
            
        }

        #endregion

       
    }
}
