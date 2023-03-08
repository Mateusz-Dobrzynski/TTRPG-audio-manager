using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTRPG_Audio_Manager
{
    public partial class SceneEditor : Form
    {
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
            //if chosen scene have any tracks, they will be loaded
            if (currentScene.tracks.Count > 0)
            {
                onLoadContent();
            }
            //creating button, which adds new track
            Button btnAddTrack = new Button();
            btnAddTrack.Text = "Add New Track";
            btnAddTrack.Height = 50;
            btnAddTrack.Width = 80;
            btnAddTrack.BackColor = Color.Gray;
            btnAddTrack.Click += new EventHandler(newTrackbtn_Click);
            tblPanel.Controls.Add(btnAddTrack, 1, tblPanel.RowCount - 1);
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

            //creating button, which adds new track
            Button btnAddTrack = new Button();
            btnAddTrack.Text = "Add New Track";
            btnAddTrack.Height = 50;
            btnAddTrack.Width = 80;
            btnAddTrack.BackColor = Color.Gray;
            btnAddTrack.Click += new EventHandler(newTrackbtn_Click);
            tblPanel.Controls.Add(btnAddTrack, 1, tblPanel.RowCount - 1);

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
        }
        //function for stoping chosen track
        private void stop_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; //temporary button is created, based on the button that initiated the event
            int count = Convert.ToInt32(btn.Name);
            Track chosenTrack = currentScene.tracks[count];
            chosenTrack.Stop();
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
            chosenTrack.volume = vol;
            scenesSet.Save(directory); //scene is saved
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
                tblPanel.Controls.Add(label, 0, tblPanel.RowCount - 1);

                //creating button used to add new audio to the track
                Button btnAdd = new Button();
                btnAdd.Text = "Add Audio";
                btnAdd.Name = Convert.ToString(count);
                btnAdd.Height = 50;
                btnAdd.Width = 80;
                btnAdd.BackColor = Color.MediumSeaGreen;
                EventArgs e = new EventArgs();
                btnAdd.Click += new EventHandler(addAudio_Click);
                tblPanel.Controls.Add(btnAdd, 1, tblPanel.RowCount - 1);

                //creating new combobox to show audio files in the track. Later may be added function to start playing from chosen audio file
                ComboBox songList = new ComboBox();
                songList.Width = 200;
                songList.Name = Convert.ToString(count);
                foreach (var song in track.audioFiles)
                {
                    songList.Items.Add(song.name);
                }
                tblPanel.Controls.Add(songList, 2, tblPanel.RowCount - 1);

                //creating label with word "Volume"
                Label volumeText = new Label();
                volumeText.Text = "Volume";
                volumeText.Name = Convert.ToString(count);
                volumeText.Height = 50;
                volumeText.TextAlign = ContentAlignment.TopCenter;
                tblPanel.Controls.Add(volumeText, 3, tblPanel.RowCount - 1);

                //creating volume picker used to change volume of the track
                NumericUpDown volumePicker = new NumericUpDown();
                volumePicker.Width = 100;
                volumePicker.Name = Convert.ToString(count);
                volumePicker.Value = currentScene.tracks[count].volume;
                volumePicker.ValueChanged += new EventHandler(volumeChange_Modified);
                tblPanel.Controls.Add(volumePicker, 4, tblPanel.RowCount - 1);

                //creating button used to play the track
                Button btnPlay = new Button();
                btnPlay.Text = "Play";
                btnPlay.Name = Convert.ToString(count);
                btnPlay.Height = 50;
                btnPlay.BackColor = Color.MediumSpringGreen;
                btnPlay.Click += new EventHandler(play_Click);
                tblPanel.Controls.Add(btnPlay, 5, tblPanel.RowCount - 1);

                //creating button used to stop the track
                Button btnStop = new Button();
                btnStop.Text = "Stop";
                btnStop.Name = Convert.ToString(count);
                btnStop.Height = 50;
                btnStop.BackColor = Color.PaleVioletRed;
                btnStop.Click += new EventHandler(stop_Click);
                tblPanel.Controls.Add(btnStop, 6, tblPanel.RowCount - 1);

                //added new row and incremented the count variable
                tblPanel.RowCount += 1;
                count += 1;
            }
        }
    }
}
