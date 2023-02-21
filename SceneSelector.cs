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
        //temp
        ScenesSet scenesSet = new ScenesSet();
        public SceneSelector()
        {
            InitializeComponent();

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
            //string cName = creator.CreatorName();
            scenesSet.AddScene();
        }
    }
}
