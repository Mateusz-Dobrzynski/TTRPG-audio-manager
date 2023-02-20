using System.ComponentModel;

namespace TTRPG_Audio_Manager
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
            //Adding EventHandlers and wiring them to the corresponding buttons
            this.loadSetFile.Click += new EventHandler(LoadSetFile_Click);
            this.openSetButton.Click += new EventHandler(OpenSet_Click);
            this.createNewSet.Click += new EventHandler(CreateNewSet_Click);
        }
        //Loading existing set by choosing the exact directory path
        private void LoadSetFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog loadSFD = new FolderBrowserDialog();
            if (loadSFD.ShowDialog() == DialogResult.OK)
            {
                //not implemented fully, because of lack of serializer, but implemented the procedure to choose a directory
                MessageBox.Show(text: $"Not implemented yet but chosen path is: {loadSFD.SelectedPath}"); 
            }
        }
        //Opening a Set Selector window, where user can open downloaded sets
        private void OpenSet_Click(object sender, EventArgs e)
        {
            SetSelector setSelector = new SetSelector();
            this.Hide();
            setSelector.ShowDialog();
            this.Show();
        }
        //Creating new set from scratch. Initially it'll create empty set, which then can be choosed end edited in Set Selector
        private void CreateNewSet_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet");
        }
        
    }
}