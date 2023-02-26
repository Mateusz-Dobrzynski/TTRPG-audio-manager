using System.ComponentModel;

namespace TTRPG_Audio_Manager
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }
        //Loading existing set by choosing the exact directory path
        private void LoadSetFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadSFD = new OpenFileDialog();
            if (loadSFD.ShowDialog() == DialogResult.OK)
            {
                //not implemented fully, because of lack of serializer, but implemented the procedure to choose a directory
                MessageBox.Show(text: $"Not implemented yet but chosen path is: {loadSFD.FileName}");
            }
        }
        //Opening a Set Selector window, where user can open downloaded sets
        private void OpenSet_Click(object sender, EventArgs e)
        {
            SceneSelector sceneSelector = new SceneSelector();
            this.Hide();
            sceneSelector.ShowDialog();
            this.Show();
        }
        //Creating new set from scratch. Initially it'll create empty set, which then can be choosed end edited in Set Selector
        public void CreateNewSet_Click(object sender, EventArgs e)
        {
            Creator creator = new Creator("set");
            ScenesSet scenesSet = new ScenesSet();
            creator.ShowDialog();
        }
    }
}
