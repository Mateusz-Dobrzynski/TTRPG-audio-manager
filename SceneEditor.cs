using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTRPG_Audio_Manager
{
    public partial class SceneEditor : Form
    {
        //allowing to drag and drop the window
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //creating instance
        public static SceneEditor instance;
        //assigning local variables using SceneSelector instance
        Scene currentScene = SceneSelector.instance.chosenScene;
        ScenesSet scenesSet = SceneSelector.instance.currentSet;
        string directory = SceneSelector.instance.directory;
        public SceneEditor()
        {
            InitializeComponent();
            //assigning object to instance and adding scrollbar
            instance = this;
            tblPanel.MaximumSize = new Size(810, 480);
            tblPanel.AutoScroll = true;
            sceneNameLabel.Text = currentScene.name;
            //loading content
            onLoadContent();
        }
        //function for creating new track
        private void newTrackbtn_Click(object sender, EventArgs e)
        {
            //opening the window to choose name
            Creator creator = new Creator();
            creator.ShowDialog();
            string name = Creator.instance.txtBox.Text;
            //adding track, saving file and refreshing content
            currentScene.AddTrack(name);
            scenesSet.Save(directory);
            onLoadContent();

        }
        //funtion for closing the form
        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //function for playing chosen track
        private void play_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; //temporary button is created, based on the button that initiated the event
            int count = Convert.ToInt32(btn.Name);
            Track chosenTrack = currentScene.tracks[count];
            chosenTrack.Play();
            btn.BackgroundImage = global::TTRPG_Audio_Manager.Properties.Resources.stopSign;
            btn.Click += new EventHandler(stop_Click);
            btn.Click -= new EventHandler(play_Click);
        }
        //function for stoping chosen track
        private void stop_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; //temporary button is created, based on the button that initiated the event
            int count = Convert.ToInt32(btn.Name);
            Track chosenTrack = currentScene.tracks[count];
            chosenTrack.Stop();
            btn.BackgroundImage = global::TTRPG_Audio_Manager.Properties.Resources.playSign;
            btn.Click -= new EventHandler(stop_Click);
            btn.Click += new EventHandler(play_Click);
        }
        //function for adding new audio to chosen track
        private void addAudio_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; //temporary button is created, based on the button that initiated the event
            int count = Convert.ToInt32(btn.Name);
            Track chosenTrack = currentScene.tracks[count];
            //opening dialog to choose the file, then scene is saved and form is refreshed
            OpenFileDialog loadSFD = new OpenFileDialog();
            if(loadSFD.ShowDialog() == DialogResult.OK)
            {
                string audioPath = loadSFD.FileName;
                chosenTrack.AddAudioFile(audioPath);
                scenesSet.Save(directory);
                onLoadContent();
            }
            
        }
        //function for changing volume
        private void volumeChange_Modified(object sender, EventArgs e)
        {
            NumericUpDown numUpDwn = (NumericUpDown)sender; //temporary Number Picker is created, based on the Number Picker that initiated the event
            int count = Convert.ToInt32(numUpDwn.Name);
            Track chosenTrack = currentScene.tracks[count];
            int vol = Convert.ToInt32(numUpDwn.Value);
            //volume cannot be lesser than 0 and greater than 100
            if (vol < 0) vol = 0;
            else if(vol > 100) vol = 100;
            chosenTrack.ChangeVolume(vol);
            scenesSet.Save(directory); //scene is saved
        }

        //function for enabling/disabling shuffle
        private void shuffle_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int count = Convert.ToInt32(btn.Name);
            Track chosenTrack = currentScene.tracks[count];
            if(chosenTrack.shuffle == false)
            {
                chosenTrack.shuffle = true;
            }
            else
            {
                chosenTrack.shuffle = false;
            }
            //changing color
            if (btn.ForeColor == System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222))))))
            {
                btn.ForeColor = System.Drawing.Color.Green;
                btn.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            }
            else
            {
                btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
                btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            }
        }

        private void del_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int count = Convert.ToInt32(btn.Name);
            Track chosenTrack = currentScene.tracks[count];
            currentScene.RemoveTrack(chosenTrack);
            scenesSet.Save(directory);
            onLoadContent();
        }
        //function for loading the elements dynamicaly in tableLayoutPanel
        private void onLoadContent()
        {
            //clearing previous elements (used only for refreshing)
            tblPanel.Controls.Clear();
            tblPanel.RowStyles.Clear();
            //count is used further as a way to name elements based on the row they're in. Row = Corresponding Track, and value Name is used in functions to select the track
            int count = 0;
            foreach (var track in currentScene.tracks)
            {
                //creating label with name of the track
                Label label = new Label();
                label.Text = track.name;
                label.Name = Convert.ToString(count);
                label.Height = 50;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
                tblPanel.Controls.Add(label, 0, tblPanel.RowCount - 1);

                //creating button used to add new audio to the track
                Button btnAdd = new Button();
                btnAdd.Text = "Add Audio";
                btnAdd.Name = Convert.ToString(count);
                btnAdd.Height = 50;
                btnAdd.Width = 80;
                btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
                btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
                btnAdd.FlatAppearance.BorderSize = 2;
                btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
                EventArgs e = new EventArgs();
                btnAdd.Click += new EventHandler(addAudio_Click);
                tblPanel.Controls.Add(btnAdd, 1, tblPanel.RowCount - 1);

                //creating new combobox to show audio files in the track. Later may be added function to start playing from chosen audio file
                ComboBox songList = new ComboBox();
                songList.Width = 300;
                songList.Name = Convert.ToString(count);
                songList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                songList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
                songList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
                foreach (var song in track.audioFiles)
                {
                    songList.Items.Add(song.name);
                }
                tblPanel.Controls.Add(songList, 2, tblPanel.RowCount - 1);

                //creating label with word "Volume"
                Label volumeText = new Label();
                volumeText.Text = "Volume";
                volumeText.Name = Convert.ToString(count);
                volumeText.Height = 20;
                volumeText.TextAlign = ContentAlignment.TopCenter;
                volumeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
                tblPanel.Controls.Add(volumeText, 3, tblPanel.RowCount - 1);

                //creating volume picker used to change volume of the track
                NumericUpDown volumePicker = new NumericUpDown();
                volumePicker.Width = 100;
                volumePicker.Name = Convert.ToString(count);
                volumePicker.Value = currentScene.tracks[count].volume;
                volumePicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
                volumePicker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
                volumePicker.ValueChanged += new EventHandler(volumeChange_Modified);
                tblPanel.Controls.Add(volumePicker, 4, tblPanel.RowCount - 1);

                //creating button used to play the track
                Button btnPlayStop = new Button();
                btnPlayStop.Name = Convert.ToString(count);
                btnPlayStop.Height = 50;
                btnPlayStop.Width = 50;
                btnPlayStop.BackgroundImage = global::TTRPG_Audio_Manager.Properties.Resources.playSign;
                btnPlayStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                btnPlayStop.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnPlayStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
                btnPlayStop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
                btnPlayStop.FlatAppearance.BorderSize = 2;
                btnPlayStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnPlayStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
                btnPlayStop.Click += new EventHandler(play_Click);
                tblPanel.Controls.Add(btnPlayStop, 5, tblPanel.RowCount - 1);

                //creating button used to enable/disable shuffle
                Button btnShuff = new Button();
                btnShuff.Text = "Shuffle";
                btnShuff.Name = Convert.ToString(count);
                btnShuff.Height = 50;
                btnShuff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
                btnShuff.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
                btnShuff.FlatAppearance.BorderSize = 2;
                btnShuff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnShuff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
                btnShuff.Click += new EventHandler(shuffle_Click);
                tblPanel.Controls.Add(btnShuff, 6, tblPanel.RowCount - 1);

                //creating button used to deleting whole tracks
                Button btnDelete = new Button();
                btnDelete.Name = Convert.ToString(count);
                btnDelete.Height = 50;
                btnDelete.Width = 50;
                btnDelete.Text = "X";
                btnDelete.TextAlign = ContentAlignment.MiddleCenter;
                btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
                btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
                btnDelete.FlatAppearance.BorderSize = 2;
                btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
                btnDelete.Click += new EventHandler(del_Click);
                tblPanel.Controls.Add(btnDelete, 7, tblPanel.RowCount - 1);

                //added new row and incremented the count variable
                tblPanel.RowCount += 1;
                count += 1;

            }
            //creating button, which adds new track
            Button btnAddTrack = new Button();
            btnAddTrack.Text = "Add New Track";
            btnAddTrack.Height = 50;
            btnAddTrack.Width = 80;
            btnAddTrack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            btnAddTrack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            btnAddTrack.FlatAppearance.BorderSize = 2;
            btnAddTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            btnAddTrack.Click += new EventHandler(newTrackbtn_Click);
            tblPanel.Controls.Add(btnAddTrack, 1, tblPanel.RowCount - 1);
        }

        private void playSceneBtn_Click(object sender, EventArgs e)
        {
            Button playScene = (Button)sender;
            if(playScene.Text == "Play Scene")
            {
                currentScene.Play();
                playScene.Text = "Stop Scene";
                playScene.ForeColor = System.Drawing.Color.DarkRed;
                playScene.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            }
            else
            {
                currentScene.Stop();
                playScene.Text = "Play Scene";
                playScene.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
                playScene.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            }
        }
        private void minBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
