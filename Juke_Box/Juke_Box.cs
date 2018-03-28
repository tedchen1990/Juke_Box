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

        #region Global variable
        // Global variable in Juke_Box
        public ListBox[] lst_media;
        public string[] genre_titles;
        public bool load_media;
 
        #endregion

        #region Initial stage
        /// <summary>
        /// Running the event first when the program starts
        /// </summary>
        private void Juke_Box_Load(object sender, EventArgs e)
        {
            load_display();
        }

        private void load_display()
        {
            if (Load_Media() == true) // If Load_Media() is sucessful 
            {
                // hsc_Select_Title.value as Number_of_Genre
                hscorllbar_display(hsc_Select_Title.Value);
            }
            else{ MessageBox.Show("Unable to load the Content !");}
        }

        //method of storing infos from media
        private bool Load_Media()
        {
            // The media floder of information is already made in this path
            string InfoPath = Directory.GetCurrentDirectory() + "\\Media\\";
            StreamReader media = File.OpenText(InfoPath + "Media.txt");

            // Read first line from file
            string lineOfText = media.ReadLine();
            int count_load_genre;
            //Make sure the fisrt line is not null and is number which means how mang genre
            if (lineOfText != null && int.TryParse(lineOfText, out count_load_genre))
            {
                load_media = true;

                /* Set up the 20 left space for creating new genre when it is Loading Media for each time */
                lst_media = new ListBox[count_load_genre + 20];
                genre_titles = new string[count_load_genre + 20];
                hsc_Select_Title.Maximum = count_load_genre - 1;

                // Read second line of text
                lineOfText = media.ReadLine();
                int judgement;
                int genre_index = 0;
                try
                {
                    while (genre_index < count_load_genre)
                    {
                        lst_media[genre_index] = new ListBox();
                        if (lineOfText != null && int.TryParse(lineOfText, out judgement)==true)
                        {
                            lineOfText = media.ReadLine();
                            genre_titles[genre_index] = lineOfText;
                            lineOfText = media.ReadLine();
                        }
                        while (lineOfText != null && int.TryParse(lineOfText, out judgement) == false)
                        {
                            lst_media[genre_index].Items.Add(lineOfText);
                            lineOfText = media.ReadLine();
                        }
                        genre_index += 1;
                    }                   
                }
                catch (Exception)
                {
                    //
                    load_media = false;
                    //throw;
                }
            }
            media.Close();
            return load_media;
        }

        #endregion

        #region Hscrollbar
        /// <summary>
        /// Slither the hscrollbar
        /// </summary>
        private void hsc_Select_Title_ValueChanged(object sender, EventArgs e)
        {
            // Run the method of display
            hscorllbar_display(hsc_Select_Title.Value);
        }

        //
        private void hscorllbar_display(int Number_of_Genre)
        {
            lst_Blank_Templet.Items.Clear();
            txt_Title.Text = genre_titles[Number_of_Genre];
            for (int i = 0; i < lst_media[Number_of_Genre].Items.Count; i++)
            {
                lst_Blank_Templet.Items.Add(lst_media[Number_of_Genre].Items[i]);
            }
        }

        #endregion

        #region Menu
        /// <summary>
        /// 
        /// </summary>
        private void setUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Set_up set_Up = new Set_up();
            // Send vaules to set_up       
            set_Up.load_media = load_media;
            set_Up.lst_genre = lst_media; // 
            set_Up.genre_titles = genre_titles; // 
            set_Up.genre_max = hsc_Select_Title.Maximum;
            set_Up.ShowDialog();
        }
        #endregion

    }

}
