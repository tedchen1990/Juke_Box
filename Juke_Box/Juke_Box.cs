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
        public ListBox[] lst_genre;
        public string[] genre_titles;

        public bool load_media;
        /* preinstall num of creating genres when loading Media at each time
        and not allow more than 10 genre can be create at once time in Set_up*/
        public int create_genre_limit = 10; 
        #endregion

        #region Initial stage
        /// <summary>
        /// Running the event first when the program starts
        /// </summary>
        private void Juke_Box_Load(object sender, EventArgs e)
        {
            if (Load_Media() == true) // If Load_Media() is sucessful 
            {
                // hsc_Select_Title.value as Number_of_Genre
                display(hsc_Select_Title.Value);
            }
            else
            {
                hsc_Select_Title.Maximum = 0;
                MessageBox.Show("Unable to load the Content !");
            }
        }

        //method of display 
        private void display(int Number_of_Genre)
        {
                lst_Blank_Templet.Items.Clear();
                txt_Title.Text = genre_titles[Number_of_Genre];
                for (int i = 0; i < lst_genre[Number_of_Genre].Items.Count; i++)
                {
                    lst_Blank_Templet.Items.Add(lst_genre[Number_of_Genre].Items[i]);
                }              
        }

        //method of storing infos from media
        private bool Load_Media()
        {
            load_media = false;
            // The media floder of information is already made in this path
            string InfoPath = Directory.GetCurrentDirectory() + "\\Media\\";
            // Open the file 
            StreamReader media = File.OpenText(InfoPath + "Media.txt");
            // Read first line from file
            string lineOfText = media.ReadLine();
            int count_load_genre;
            //Make sure the fisrt line is not null and is number which means how mang genre
            if (lineOfText != null && int.TryParse(lineOfText, out count_load_genre))
            {
                load_media = true;
                //
                lst_genre = new ListBox[count_load_genre + create_genre_limit];
                genre_titles = new string[count_load_genre + create_genre_limit];
                hsc_Select_Title.Maximum = count_load_genre - 1;

                // second line of text
                lineOfText = media.ReadLine();
                //
                int num;
                try
                {
                    for (int i = 0; i < count_load_genre; i++)
                    {
                        lst_genre[i] = new ListBox();
                        do
                        {
                            if (int.TryParse(lineOfText, out num))
                            {
                                lineOfText = media.ReadLine();
                                genre_titles[i] = lineOfText;
                            }
                            else
                            {
                                lst_genre[i].Items.Add(lineOfText);
                            }

                            lineOfText = media.ReadLine();
                        }
                        while (lineOfText != null && int.TryParse(lineOfText, out num) != true);
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
            display(hsc_Select_Title.Value);
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
            set_Up.lst_genre = lst_genre; // 
            set_Up.genre_titles = genre_titles; // 
            set_Up.genre_maximum = hsc_Select_Title.Maximum;
            set_Up.create_genre_limit = create_genre_limit;
            set_Up.ShowDialog();
        }
        #endregion

    }

}
