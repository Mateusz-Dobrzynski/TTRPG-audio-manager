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
        string directoryPath = Index.instance.dPath.Text;
        ScenesSet currentSet = Index.instance.currentSet;
        public SceneSelector()
        {
            InitializeComponent();
            instance = this;
            foreach (Scene x in currentSet.scenes) {
                //Button button = new Button();
                //button.Click += new EventHandler(sceneOpener);
                //button.Text = x.name;
                //button.Width = 220;
                //button.Height = 21;
                //button.ForeColor = Color.White;
                sceneBox.Items.Add(x.name);
            }

        }
        //Set Selector is a place, where user can open created/imported sets, which will open in new window
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        //adding new scene
        private void AddSceneBtn_Click(object sender, EventArgs e)
        {
            Creator creator = new Creator();
            creator.ShowDialog();
            string name = Creator.instance.txtBox.Text;
            currentSet.AddScene(name);
            currentSet.Save(directoryPath);
            sceneBox.Items.Add(name);
        }
        private void sceneOpener(object sender, EventArgs e)
        {
            string name = sceneBox.Text;
            foreach (Scene x in currentSet.scenes)
            {
                if(x.name == name)
                {
                    Scene chosenScene = x;
                }
            }
        }
        int x = 1;
    }
}
