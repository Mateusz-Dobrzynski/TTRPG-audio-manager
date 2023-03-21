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
    public partial class SceneSelector : Form
    {
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
    }
}
