namespace Juke_Box
{
    partial class Juke_Box
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Juke_Box));
            this.label1 = new System.Windows.Forms.Label();
            this.lst_Playlist = new System.Windows.Forms.ListBox();
            this.txt_Title = new System.Windows.Forms.TextBox();
            this.lst_Blank_Templet = new System.Windows.Forms.ListBox();
            this.txt_Presently_Playing = new System.Windows.Forms.TextBox();
            this.hsc_Select_Title = new System.Windows.Forms.HScrollBar();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.setUp_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.about_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_player = new System.Windows.Forms.Timer(this.components);
            this.Juke_box_MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Juke_box_MediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlText;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(514, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Copyright © 2018. Ted Chen.";
            // 
            // lst_Playlist
            // 
            this.lst_Playlist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lst_Playlist.FormattingEnabled = true;
            this.lst_Playlist.ItemHeight = 16;
            this.lst_Playlist.Location = new System.Drawing.Point(242, 414);
            this.lst_Playlist.Name = "lst_Playlist";
            this.lst_Playlist.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lst_Playlist.Size = new System.Drawing.Size(261, 180);
            this.lst_Playlist.TabIndex = 1;
            // 
            // txt_Title
            // 
            this.txt_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txt_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Title.Location = new System.Drawing.Point(230, 199);
            this.txt_Title.Multiline = true;
            this.txt_Title.Name = "txt_Title";
            this.txt_Title.ReadOnly = true;
            this.txt_Title.Size = new System.Drawing.Size(282, 27);
            this.txt_Title.TabIndex = 2;
            this.txt_Title.Text = "No contents !";
            // 
            // lst_Blank_Templet
            // 
            this.lst_Blank_Templet.FormattingEnabled = true;
            this.lst_Blank_Templet.ItemHeight = 16;
            this.lst_Blank_Templet.Location = new System.Drawing.Point(230, 225);
            this.lst_Blank_Templet.Name = "lst_Blank_Templet";
            this.lst_Blank_Templet.Size = new System.Drawing.Size(282, 116);
            this.lst_Blank_Templet.TabIndex = 3;
            this.lst_Blank_Templet.DoubleClick += new System.EventHandler(this.lst_Blank_Templet_DoubleClick);
            // 
            // txt_Presently_Playing
            // 
            this.txt_Presently_Playing.BackColor = System.Drawing.Color.Lime;
            this.txt_Presently_Playing.Location = new System.Drawing.Point(207, 376);
            this.txt_Presently_Playing.Multiline = true;
            this.txt_Presently_Playing.Name = "txt_Presently_Playing";
            this.txt_Presently_Playing.ReadOnly = true;
            this.txt_Presently_Playing.Size = new System.Drawing.Size(334, 29);
            this.txt_Presently_Playing.TabIndex = 4;
            this.txt_Presently_Playing.Tag = "";
            // 
            // hsc_Select_Title
            // 
            this.hsc_Select_Title.LargeChange = 1;
            this.hsc_Select_Title.Location = new System.Drawing.Point(230, 341);
            this.hsc_Select_Title.Maximum = 0;
            this.hsc_Select_Title.Name = "hsc_Select_Title";
            this.hsc_Select_Title.Size = new System.Drawing.Size(282, 24);
            this.hsc_Select_Title.TabIndex = 5;
            this.hsc_Select_Title.ValueChanged += new System.EventHandler(this.hsc_Select_Title_ValueChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setUp_Menu,
            this.about_Menu});
            this.menuStrip.Location = new System.Drawing.Point(0, 733);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(745, 31);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip1";
            // 
            // setUp_Menu
            // 
            this.setUp_Menu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.setUp_Menu.Name = "setUp_Menu";
            this.setUp_Menu.Size = new System.Drawing.Size(63, 27);
            this.setUp_Menu.Text = "&Set up";
            this.setUp_Menu.Click += new System.EventHandler(this.setUp_Menu_Click);
            // 
            // about_Menu
            // 
            this.about_Menu.Name = "about_Menu";
            this.about_Menu.Size = new System.Drawing.Size(69, 27);
            this.about_Menu.Text = "A&bout";
            this.about_Menu.Click += new System.EventHandler(this.about_Menu_Click);
            // 
            // timer_player
            // 
            this.timer_player.Interval = 3000;
            this.timer_player.Tick += new System.EventHandler(this.timer_player_Tick);
            // 
            // Juke_box_MediaPlayer
            // 
            this.Juke_box_MediaPlayer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Juke_box_MediaPlayer.Enabled = true;
            this.Juke_box_MediaPlayer.Location = new System.Drawing.Point(0, 687);
            this.Juke_box_MediaPlayer.Name = "Juke_box_MediaPlayer";
            this.Juke_box_MediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Juke_box_MediaPlayer.OcxState")));
            this.Juke_box_MediaPlayer.Size = new System.Drawing.Size(745, 46);
            this.Juke_box_MediaPlayer.TabIndex = 7;
            this.Juke_box_MediaPlayer.Visible = false;
            this.Juke_box_MediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.Juke_box_MediaPlayer_PlayStateChange);
            // 
            // Juke_Box
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(745, 764);
            this.Controls.Add(this.Juke_box_MediaPlayer);
            this.Controls.Add(this.hsc_Select_Title);
            this.Controls.Add(this.txt_Presently_Playing);
            this.Controls.Add(this.lst_Blank_Templet);
            this.Controls.Add(this.txt_Title);
            this.Controls.Add(this.lst_Playlist);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "Juke_Box";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Juke Box v2.0";
            this.Load += new System.EventHandler(this.Juke_Box_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Juke_box_MediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lst_Playlist;
        private System.Windows.Forms.TextBox txt_Title;
        private System.Windows.Forms.ListBox lst_Blank_Templet;
        private System.Windows.Forms.TextBox txt_Presently_Playing;
        private System.Windows.Forms.HScrollBar hsc_Select_Title;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem setUp_Menu;
        private System.Windows.Forms.ToolStripMenuItem about_Menu;
        private System.Windows.Forms.Timer timer_player;
        private AxWMPLib.AxWindowsMediaPlayer Juke_box_MediaPlayer;
    }
}