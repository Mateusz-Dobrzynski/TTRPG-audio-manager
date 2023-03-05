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
        public static SceneEditor instance;
        Scene currentScene = SceneSelector.instance.chosenScene;
        ScenesSet scenesSet = SceneSelector.instance.currentSet;
        string directory = SceneSelector.instance.directory;
        public SceneEditor()
        {
            InitializeComponent();
            instance = this;
            if (currentScene.tracks.Count > 0)
            {
                foreach (var track in currentScene.tracks)
                {
                    int count = 0;
                    Label label = new Label();
                    label.Text = track.name;
                    label.Height = 50;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    tblPanel.Controls.Add(label, 0, tblPanel.RowCount - 1);

                    Button btnAdd = new Button();
                    btnAdd.Text = "Add Audio";
                    btnAdd.Height = 50;
                    btnAdd.Width = 80;
                    btnAdd.BackColor = Color.MediumSeaGreen;
                    EventArgs e = new EventArgs();
                    btnAdd.Click += new EventHandler((sender, e) => addAudio_Click(sender, e, count));
                    tblPanel.Controls.Add(btnAdd, 1, tblPanel.RowCount - 1);

                    ComboBox songList = new ComboBox();
                    songList.Width = 300;
                    foreach (var song in track.audioFiles)
                    {
                        songList.Items.Add(song.name);
                    }
                    tblPanel.Controls.Add(songList, 2, tblPanel.RowCount - 1);

                    Button btnPlay = new Button();
                    btnPlay.Text = "Play";
                    btnPlay.Height = 50;
                    btnPlay.BackColor = Color.MediumSpringGreen;
                    btnPlay.Click += new EventHandler((sender, e) => play_Click(sender, e, count));
                    tblPanel.Controls.Add(btnPlay, 3, tblPanel.RowCount - 1);

                    Button btnStop = new Button();
                    btnStop.Text = "Stop";
                    btnStop.Height = 50;
                    btnStop.BackColor = Color.PaleVioletRed;
                    btnStop.Click += new EventHandler((sender, e) => stop_Click(sender, e, count));
                    tblPanel.Controls.Add(btnStop, 4, tblPanel.RowCount - 1);

                    tblPanel.RowCount += 1;
                    count++;
                }
            }
            Button btnAddTrack = new Button();
            btnAddTrack.Text = "Add New Track";
            btnAddTrack.Height = 50;
            btnAddTrack.Width = 80;
            btnAddTrack.BackColor = Color.Gray;
            btnAddTrack.Click += new EventHandler(newTrackbtn_Click);
            tblPanel.Controls.Add(btnAddTrack, 1, tblPanel.RowCount - 1);
        }

        private void newTrackbtn_Click(object sender, EventArgs e)
        {
            Creator creator = new Creator();
            creator.ShowDialog();
            string name = Creator.instance.txtBox.Text;
            currentScene.AddTrack(name);
            scenesSet.Save(directory);

        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void play_Click(object sender, EventArgs e, int count)
        {
            Track chosenTrack = currentScene.tracks[count];
            chosenTrack.Play();
        }
        private void stop_Click(object sender, EventArgs e, int count)
        {
            Track chosenTrack = currentScene.tracks[count];
            chosenTrack.Stop();
        }
        private void addAudio_Click(object sender, EventArgs e, int count)
        {
            Track chosenTrack = currentScene.tracks[count];
            OpenFileDialog loadSFD = new OpenFileDialog();
            if(loadSFD.ShowDialog() == DialogResult.OK)
            {
                string audioPath = loadSFD.FileName;
                chosenTrack.AddAudioFile(audioPath);
                scenesSet.Save(directory);
            }
            
        }
    }
}
