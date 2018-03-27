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
        // Global variable
        public ListBox[] lst_genre;
        public string[] genre_titles;
        #endregion

        #region Initial stage

        /// <summary>
        /// Running the event first when the program starts
        /// </summary>
        private void Juke_Box_Load(object sender, EventArgs e)
        {
            // storing into listbox, textbox
            if (storing_infromation())
            {
                display(hsc_Select_Title.Value);
            }
            else
            {
                MessageBox.Show("worry");
            }
        }

        //method of storing infos
        private bool storing_infromation()
        {
            //
            bool store_Yes_No = false;
            //
            int genre_maximum;
            // The media floder of information is already made in this path
            string InfoPath = Directory.GetCurrentDirectory() + "\\Media\\";
            // Open the file 
            StreamReader media = File.OpenText(InfoPath + "Media.txt");
            // Read first line from file
            string lineOfText = media.ReadLine();
            //Make sure the fisrt line is not null and is number which means how mang genre
            if (lineOfText != null && int.TryParse(lineOfText, out genre_maximum))
            {   
                //
                store_Yes_No = true;
                //
                genre_titles = new string[genre_maximum];
                //
                lst_genre = new ListBox[genre_maximum];
                // Set the num of genre to the hscrollbar
                hsc_Select_Title.Maximum = genre_maximum-1;

                // second line of text
                lineOfText = media.ReadLine();
                //
                int num;
                for (int i = 0; i < genre_maximum ; i++)
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
            media.Close();
            return store_Yes_No;
        }

        private void display(int Int_Number_of_Genre)
        {
            lst_Blank_Templet.Items.Clear();
            txt_Title.Text = genre_titles[Int_Number_of_Genre];
            for (int i = 0; i < lst_genre[Int_Number_of_Genre].Items.Count; i++)
            {
                lst_Blank_Templet.Items.Add(lst_genre[Int_Number_of_Genre].Items[i]);
            }
        }

        #endregion

        #region Hscrollbar_Event
        private void hsc_Select_Title_ValueChanged(object sender, EventArgs e)
        {
            display(hsc_Select_Title.Value);
        }
        #endregion

        #region Menu
        private void setUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Set_up set_Up = new Set_up();
            set_Up.ShowDialog();
        }
        #endregion

        //test code :
        private void button1_Click(object sender, EventArgs e)
        {
           MessageBox.Show(lst_genre[2].Items[1].ToString());
        }
    }

}
