﻿using System;
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
using WMPLib;

namespace Juke_Box
{
    public partial class Juke_Box : Form
    {
        public Juke_Box()
        {
            InitializeComponent();
        }

        #region Global variable
        // Global variable in Juke_Box
        public string media_Path = Directory.GetCurrentDirectory(); // the path of files
        public ListBox[] lst_media; 
        public string[] genre_titles;
        public bool load_media = false;
        public bool playing_song = false;
        #endregion

        #region Initial Loading

        /// <summary>
        /// Running the event first when the program starts
        /// </summary>
        private void Juke_Box_Load(object sender, EventArgs e)
        {
            // loading the contents
            // If Load_Media() is sucessful
            if (Load_Media() == true)  
            {
                // hsc_Select_Title.value as Number_of_Genre from 0, when the program start
                hsc_Select_Title.Value = 0;
                hscorllbar_display(hsc_Select_Title.Value);
            }
            else
            {
                MessageBox.Show("Unable to load the Content !");
            }
        }

        //method of storing infos from media
        private bool Load_Media()
        {
            // The media floder of information is already made in this path
            StreamReader media = File.OpenText(media_Path + "\\Media\\Media.txt");

            // Read first line from file
            string lineOfText = media.ReadLine();
            // Get the genre quantity 
            int count_load_genre;
            //Make sure the fisrt line is not null and is number which means how mang genre
            if (lineOfText != null && int.TryParse(lineOfText, out count_load_genre))
            {
                load_media = true;

                /* Set up more than 20 left space for creating new genres 
                   when it is Loading Media for each time */
                lst_media = new ListBox[count_load_genre + 20];
                genre_titles = new string[count_load_genre + 20];
                // hscrollbar index is from 0
                hsc_Select_Title.Maximum = count_load_genre - 1;

                // Read second line of text
                lineOfText = media.ReadLine();
                int judgement;
                int genre_index = 0;
                try
                {
                    // Run in fixed times which can not over the number of genres
                    while (genre_index < count_load_genre)
                    {
                        // Set up a real space of listbox for data
                        lst_media[genre_index] = new ListBox();
                        // If is is num of the second line
                        if (lineOfText != null && int.TryParse(lineOfText, out judgement)==true)
                        {
                            // Read the next line from text, which must be title
                            lineOfText = media.ReadLine();
                            // Put the title into genre_titles
                            genre_titles[genre_index] = lineOfText;
                            // Read the third line, which must be the track and follow the title
                            lineOfText = media.ReadLine();
                        }
                        /* If the tracks is a num or is null, 
                        then the loop will be end */
                        while (lineOfText != null && int.TryParse(lineOfText, out judgement) == false)
                        {
                            // Give the data of the line to the listbox
                            lst_media[genre_index].Items.Add(lineOfText);
                            // Read the next track
                            lineOfText = media.ReadLine(); 
                        }
                        /*Run the next title of listbox 
                          after this data of the title has been done */
                        genre_index += 1;
                    }                   
                }
                catch (Exception)
                {
                    // if it doesn't work,throw that load_media is false
                    load_media = false;
                }
            }
            media.Close();
            return load_media;
        }

        #endregion

        #region Hscrollbar & Display

        /// <summary>
        /// Slither the hscrollbar
        /// </summary>
        private void hsc_Select_Title_ValueChanged(object sender, EventArgs e)
        {
            // Run the method of display
            hscorllbar_display(hsc_Select_Title.Value);
        }

        // When change drag the hscorllbar it will show up different playlist
        private void hscorllbar_display(int Number_of_Genre)
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

        #region Double-clicking a track

        /// <summary>
        /// Playing songs when double click a track
        /// </summary>
        private void lst_Blank_Templet_DoubleClick(object sender, EventArgs e)
        {
            Coyp_track();
        }

        // copy the song to the playlist
        private void Coyp_track()
        {
            int Track_index = lst_Blank_Templet.SelectedIndex;
            if (Track_index > -1 )
            {
                // Song is playing
                if (playing_song == true)
                {
                    // add to playlist
                    lst_Playlist.Items.Add(lst_Blank_Templet.Items[Track_index]);
                }
                // No song in the playlist any more and song is not playing
                else if (lst_Playlist.Items.Count==0)
                {
                    txt_Presently_Playing.Text = lst_Blank_Templet.Items[Track_index].ToString();
                    // Start the first song if no music in the playlist
                    play_music(txt_Presently_Playing.Text);
                    /* set up playing_song is true  */
                    playing_song = true;
                }
            }
        }

        // Find the path of the song and play it
        private void play_music(string track)
        {
            Juke_box_MediaPlayer.URL = media_Path + "\\Tracks\\" + track;
            Juke_box_MediaPlayer.Ctlcontrols.play();  
        }

        #endregion

        #region Playing music
        /// <summary>
        /// Automatically play song one by one
        /// </summary>
        private void timer_player_Tick(object sender, EventArgs e)
        {
            // No sang playing then going to play next song 
            if (Juke_box_MediaPlayer.playState == WMPPlayState.wmppsStopped)
            {
                // Stop the timer with playing next song
                timer_player.Enabled = false;
                // Play the next song
                play_next();
            } 
            //If the Song is playing and make sure mark it is playing
            else if (Juke_box_MediaPlayer.playState == WMPPlayState.wmppsPlaying)
            {
               playing_song = true;
            }
        }

        /// <summary>
        /// get the state of the song 
        /// </summary>
        private void Juke_box_MediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (Juke_box_MediaPlayer.playState == WMPPlayState.wmppsStopped)
            {
                // No song playing
                playing_song = false;
                // Timer event will run
                timer_player.Enabled = true;
            }
        }

        private void play_next()
        {  
            //  If thera are songs into playlist then move next song to play
            if (lst_Playlist.Items.Count > 0)
            {
                txt_Presently_Playing.Text = lst_Playlist.Items[0].ToString();
                lst_Playlist.Items.RemoveAt(0);
                play_music(txt_Presently_Playing.Text);
            }
            else
            {
                //no song in the playlist anymore
                txt_Presently_Playing.Text = null;
            }  
        }
        #endregion

        #region Menu

        /// <summary>
        /// Open to setup form
        /// </summary>
        private void setUp_Menu_Click(object sender, EventArgs e)
        {
            Set_up set_Up = new Set_up();
            //Send vaules to set_up for edit
            set_Up.media_Path = media_Path;
            set_Up.load_media = load_media;
            set_Up.lst_media = lst_media;  
            set_Up.genre_titles = genre_titles;  
            set_Up.genre_max = hsc_Select_Title.Maximum;

            set_Up.ShowDialog();

            if (set_Up.DialogResult == DialogResult.OK)
            {
                // refresh
                if (Load_Media() == true) // If Load_Media() is sucessful 
                {
                    // hsc_Select_Title.value as Number_of_Genre
                    hsc_Select_Title.Value = 0;
                    hscorllbar_display(hsc_Select_Title.Value);
                }
            }
        }

        /// <summary>
        /// Open to about form
        /// </summary>
        private void about_Menu_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
        #endregion

    }

}
