using System.ComponentModel;

namespace TTRPG_Audio_Manager
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
            this.loadSetFile.Click += new EventHandler(LoadSetFile_Click);
            this.openSetButton.Click += new EventHandler(OpenSet_Click);
            this.createNewSet.Click += new EventHandler(CreateNewSet_Click);
        }
        private void LoadSetFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog loadSFD = new FolderBrowserDialog();
            if (loadSFD.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show($"Not implemented but yet chosen path is: {loadSFD.SelectedPath}");
            }
        }
        private void OpenSet_Click(object sender, EventArgs e)
        {
            SetSelector setSelector = new SetSelector();
            this.Hide();
            setSelector.ShowDialog();
            this.Show();
        }
        private void CreateNewSet_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet");
        }
        
    }
}