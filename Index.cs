using System.ComponentModel;

namespace TTRPG_Audio_Manager
{
    public partial class Index : Form
    {
        //Creating an instance so other windows can access certain objects in this window
        public static Index instance;
        public Label dPath;
        public ScenesSet currentSet;
        string FBDPath;
        public Index()
        {
            InitializeComponent();
            //assigning objects to instance
            instance = this;
            dPath = directoryPath;
        }
        //Loading existing set by choosing the exact directory path
        private void LoadSetFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadSFD = new OpenFileDialog();
            if (loadSFD.ShowDialog() == DialogResult.OK)
            {
                //assigning to the shared object (currentSet) the loaded object
                currentSet = new ScenesSet(loadSFD.FileName);
                dPath.Text = Path.GetDirectoryName(loadSFD.FileName);
                
                //creating button and assigning an event to it to open scene selector for currentSet
                Button newSet = new Button();
                Controls.Add(newSet);
                newSet.Location = new Point(50, 50);
                newSet.Text = currentSet.name;
                newSet.UseVisualStyleBackColor = true;
                newSet.Width = 150;
                newSet.Height = 50;
                newSet.Click += new EventHandler(OpenSet_Click);
            }
        }
        //Opening a Set Selector window, where user can open downloaded sets
        public void OpenSet_Click(object sender, EventArgs e)
        {
            SceneSelector sceneSelector = new SceneSelector();
            this.Hide();
            sceneSelector.ShowDialog();
            this.Show();
        }
        //Creating new scene with pop-up window to give it a name. Then the set is saved in the chosen directory
        public void CreateNewSet_Click(object sender, EventArgs e)
        {
            //creating new object and assigning it to shared object (currentSet). Also saving file in the chosen directory (with name provided by the user)
            Creator creator = new Creator();
            creator.ShowDialog();
            currentSet = new ScenesSet();
            currentSet.name = Creator.instance.txtBox.Text;
            currentSet.Save(FBDPath);

            //creating button and assigning an event to it to open scene selector for currentSet
            Button newSet = new Button();
            Controls.Add(newSet);
            newSet.Location = new Point(50, 50);
            newSet.Text = currentSet.name;
            newSet.UseVisualStyleBackColor = true;
            newSet.Width = 150;
            newSet.Height = 50;
            newSet.Click += new EventHandler(OpenSet_Click);
        }
        //Chooses base directory in which sets will be saved
        private void directoryBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog loadFBD = new FolderBrowserDialog();
            if (loadFBD.ShowDialog() == DialogResult.OK)
            {
                FBDPath = loadFBD.SelectedPath;
                directoryPath.Text = loadFBD.SelectedPath;
            }
        }
    }
}
