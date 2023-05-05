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
    public partial class SceneSelector : Form
    {
        //allowing to drag and drop the window
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //creating instances
        public static SceneSelector instance;
        public Scene chosenScene; 
        //assigning local variables using Index instance
        public string directory = Index.instance.dPath.Text;
        public ScenesSet currentSet = Index.instance.currentSet;
        public SceneSelector()
        {
            InitializeComponent();
            //assigning object to instance and checking if chosen set has already any scenes. If yes then they will be added to the lsit
            instance = this;
            foreach (Scene x in currentSet.scenes) {
                sceneBox.Items.Add(x.name);
            }

        }
        //return button to the Index window
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        //adding new scene
        private void AddSceneBtn_Click(object sender, EventArgs e)
        {
            //adding scene to the set with name provided by the user, then saving it and adding the scene to the list
            Creator creator = new Creator();
            creator.ShowDialog();
            string name = Creator.instance.txtBox.Text;
            currentSet.AddScene(name);
            currentSet.Save(directory);
            sceneBox.Items.Add(name);
        }
        //opening the chosen scene
        private void sceneOpener(object sender, EventArgs e)
        {
            //this takes the text value from list and iterates through all scenes. If the names match then the scene is selected
            string name = sceneBox.Text;
            foreach (Scene x in currentSet.scenes)
            {
                if(x.name == name)
                {
                    chosenScene = x;
                    SceneEditor sceneEditor = new SceneEditor();
                    sceneEditor.Show();
                }
            }
        }
        private void minBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            System.Windows.Forms.Application.ExitThread();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void deleteScene_Click(object sender, EventArgs e)
        {
            Button deleteText = (Button)sender;
            string name = sceneBox.Text;
            foreach (Scene x in currentSet.scenes.ToList())
            {
                if (x.name == name)
                {
                    chosenScene = x;
                    chosenScene.parentSet = currentSet;
                    if (deleteText.Text == "Delete Scene")
                    {
                        deleteScene.ForeColor = System.Drawing.Color.DarkRed;
                        deleteScene.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
                        deleteScene.Text = "Are you sure?";
                        notSoSureButton.Visible = true;
                    }
                    else
                    {
                        chosenScene.RemoveSelf();
                        sceneBox.Items.Clear();
                        sceneBox.Text = "";
                        foreach (Scene y in currentSet.scenes)
                        {
                            sceneBox.Items.Add(y.name);
                        }
                        currentSet.Save(directory);
                        deleteScene.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
                        deleteScene.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
                        deleteScene.Text = "Delete Scene";
                        notSoSureButton.Visible = false;
                    }
                }
            }
        }

        private void notSoSureButton_Click(object sender, EventArgs e)
        {
            deleteScene.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            deleteScene.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            deleteScene.Text = "Delete Scene";
            notSoSureButton.Visible = false;
        }
    }
}
