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
            if (load_media == true)
            {
                Number_of_Genre = 0;
                Select_Num_display(Number_of_Genre);
                // can't set into the track file over 100 songs at once time 
            }
            else
            {
                Number_of_Genre = genre_max = -1;
            }
        }

        #endregion

        #region Import & Clear - Get Files

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
                edit = true;
                foreach (string file in Directory.EnumerateFiles(folderBrowserDialog.SelectedPath, "*.*", SearchOption.AllDirectories).Where
                        (a => a.EndsWith(".mp3") || a.EndsWith(".wma") || a.EndsWith(".wav") || a.EndsWith(".MP3") || a.EndsWith(".WMA") || a.EndsWith(".WAV")))
                {
                    lst_Read_File.Items.Add(file);
                }

                //
                if (lst_Read_File.Items.Count > 0)
                {
                    btn_Import_Tracks.Enabled = false;
                }

                // The default is true,leave out below code
                //else
                //{
                //    btn_Import_Tracks.Enabled = true;
                //}
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

        #region Coyp & Move & Detele Tracks
        
        /// <summary>
        /// 
        /// </summary>
        private void btn_Coyp_Track_Click(object sender, EventArgs e)
        {
            // 0 is coyp path
            add_track(0);
        }

        /// <summary>
        /// 
        /// </summary>
        private void btn_Move_Track_Click(object sender, EventArgs e)
        {
            // 1 is move path
            add_track(1);
        }

        /// <summary>
        /// 
        /// </summary>
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

                // copy or move song from sourced place to the track file
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
            else
            {
                MessageBox.Show("You must to select one !", "Warning");
            }
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
            else
            {
                MessageBox.Show("You must to select one !", "Warning");
            }
        }

        #endregion

        #region Add & Delete - Genre Titles

        /// <summary>
        /// 
        /// </summary>
        private void btn_Add_Title_Click(object sender, EventArgs e)
        {
            add_genre();
        }

        /// <summary>
        /// 
        /// </summary>
        private void btn_Delete_Title_Click(object sender, EventArgs e)
        {
            DialogResult comfrim = MessageBox.Show("All the song will be delete in this title, will you continue?", "Warning", MessageBoxButtons.YesNo);
            if (comfrim == DialogResult.Yes)
            {
                delete_genre();
            }
        }

        private void add_genre()
        {
            string title = Input_box.InputBox("Please enter a title :");
            while (title.Length == 0)
            {
                MessageBox.Show("You must enter a title !");
                title = Input_box.InputBox("Please enter a title :");
            }
            genre_max += 1;
            Number_of_Genre = genre_max;
            genre_titles[Number_of_Genre] = title;
            lst_media[Number_of_Genre] = new ListBox();
            Select_Num_display(Number_of_Genre);
        }

        private void delete_genre()
        {
            if (genre_max >= 0)
            {
                int num = Number_of_Genre;

                while (num < genre_max)
                {
                    genre_titles[num] = genre_titles[num + 1];
                    lst_media[num].Items.Clear();
                    int max_index = lst_media[num + 1].Items.Count;
                    int index = 0;
                    while (index < max_index)
                    {
                        lst_media[num].Items.Add(lst_media[num + 1].Items[index].ToString());
                        index += 1;
                    }
                    num += 1;
                }
                genre_titles[genre_max] = null;
                lst_media[genre_max] = null;
                genre_max -= 1;
                Number_of_Genre = genre_max;
                Select_Num_display(Number_of_Genre);
            }
                         
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
            }
        }

        //
        private void Select_Num_display(int Number_of_Genre)
        {
            lst_Blank_Templet.Items.Clear();

            if (Number_of_Genre > -1)
            {
                txt_Title.Text = genre_titles[Number_of_Genre];

                int max_index = lst_media[Number_of_Genre].Items.Count;
                int index = 0;
                while (index < max_index)
                {
                    lst_Blank_Templet.Items.Add(lst_media[Number_of_Genre].Items[index]);
                    index += 1;
                }
                if (Number_of_Genre < 1 && genre_max > -1)
                {
                    btn_Previous_Title.Enabled = false;
                    btn_Next_Title.Enabled = true;
                }
                else if (Number_of_Genre == (genre_max) && genre_max > 0)
                {
                    btn_Previous_Title.Enabled = true;
                    btn_Next_Title.Enabled = false;
                }
            }
            else
            {
                txt_Title.Text = "No contents !";
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
                // do something
                input_media();
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
                DialogResult comfrim = MessageBox.Show("You have made somthing change.Do you want to save your change ?", "Warning", MessageBoxButtons.YesNo);
                if (comfrim == DialogResult.Yes)
                {
                    // do something
                    input_media();
                }
            }
            this.Close();
        }
       
        //
        private void input_media()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

      
    }
}
