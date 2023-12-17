using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MdPl
{
    public partial class Form1 : Form
    {
        List<string> path = new List<string>();
        private bool isMuted = false;
        bool sidebarExpand;
        public Form1()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.uiMode = "none";
            timer1.Enabled = true;
            Playlist.ScrollAlwaysVisible = true;
            Playlist.HorizontalScrollbar = true;
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.uiMode = "none";
        }

        private void pilihPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Video MP4 | *.mp4| MP3 Audio File | *.mp3|\" + \" Windows Media File | *.wma |WAV Audio File | *.wav";
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {
                    path.Add(openFileDialog1.FileNames[i]);
                    Playlist.Items.Add(Path.GetFileNameWithoutExtension(openFileDialog1.FileNames[i]));
                }
                axWindowsMediaPlayer1.URL = openFileDialog1.FileNames[0];
            }
        }

        private void playlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == true)
            {
                panel3.Hide();
                playlistToolStripMenuItem.CheckState = CheckState.Unchecked;
            }
            else
            {
                panel3.Show();
                playlistToolStripMenuItem.CheckState = CheckState.Checked;

            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = path[Playlist.SelectedIndex];
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int currentMediaPosition = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition; // Dalam detik
            progressBar1.Value = currentMediaPosition;
            label3.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            if (Playlist.SelectedIndex < Playlist.Items.Count + 1)
            {
                Playlist.SelectedIndex = Playlist.SelectedIndex - 1;
            }
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition -= 10;
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition += 10;
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            if (Playlist.SelectedIndex < Playlist.Items.Count - 1)
            {
                Playlist.SelectedIndex = Playlist.SelectedIndex + 1;
            }
        }

        private void bunifuImageButton10_Click(object sender, EventArgs e)
        {
            if (isMuted)
            {
                axWindowsMediaPlayer1.settings.mute = false; // Unmute
                bunifuImageButton10.Text = "Mute";
            }
            else
            {
                axWindowsMediaPlayer1.settings.mute = true; // Mute
                bunifuImageButton10.Text = "Unmute";
            }

            isMuted = !isMuted;
        }

        private void bunifuHSlider1_Scroll(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = bunifuHSlider1.Value;
            label2.Text = bunifuHSlider1.Value.ToString();
        }

        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton12_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void bunifuImageButton13_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Video MP4 | *.mp4| *.wav|";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path.Add(openFileDialog1.FileName);
                axWindowsMediaPlayer1.URL = openFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Video MP4 | *.mp4| *.wav|";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path.Add(openFileDialog1.FileName);
                axWindowsMediaPlayer1.URL = openFileDialog1.FileName;
            }
        }

        private void bunifuImageButton2_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "MP3 Audio File | *.mp3|\" + \" Windows Media File | *.wma |WAV Audio File | *.wav";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path.Add(openFileDialog1.FileName);
                axWindowsMediaPlayer1.URL = openFileDialog1.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "MP3 Audio File | *.mp3|\" + \" Windows Media File | *.wma |WAV Audio File | *.wav";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path.Add(openFileDialog1.FileName);
                axWindowsMediaPlayer1.URL = openFileDialog1.FileName;
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
