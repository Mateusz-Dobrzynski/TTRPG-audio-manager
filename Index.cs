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
        int count = 0;
        List<ScenesSet> setsList = new List<ScenesSet>();
        public Index()
        {
            InitializeComponent();
            //assigning objects to instance
            instance = this;
            dPath = directoryPath;

            //onLoadContent();
        }
        //Loading existing set by choosing the exact directory path
        private void LoadSetFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadSFD = new OpenFileDialog();
            if (loadSFD.ShowDialog() == DialogResult.OK)
            {
                //assigning to the shared object (currentSet) the loaded object
                ScenesSet scenesSet = new ScenesSet(loadSFD.FileName);
                setsList.Add(scenesSet);
                dPath.Text = Path.GetDirectoryName(loadSFD.FileName);

                //creating button and assigning an event to it to open scene selector for currentSet
                Button newSet = new Button();
                setLayout.Controls.Add(newSet);
                newSet.Text = scenesSet.name;
                newSet.UseVisualStyleBackColor = true;
                newSet.Width = 150;
                newSet.Height = 50;
                newSet.Name = Convert.ToString(count);
                newSet.Click += new EventHandler(OpenSet_Click);
                count += 1;
            }
        }
        //Opening a Set Selector window, where user can open downloaded sets
        public void OpenSet_Click(object sender, EventArgs e)
        {
            Button set = (Button)sender;
            int count = Convert.ToInt32(set.Name);
            currentSet = setsList[count];
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
            ScenesSet scenesSet = new ScenesSet();
            scenesSet.name = Creator.instance.txtBox.Text;
            scenesSet.Save(FBDPath);
            setsList.Add(scenesSet);

            //creating button and assigning an event to it to open scene selector for currentSet
            Button newSet = new Button();
            setLayout.Controls.Add(newSet);
            newSet.Text = scenesSet.name;
            newSet.UseVisualStyleBackColor = true;
            newSet.Width = 150;
            newSet.Height = 50;
            newSet.Name = Convert.ToString(count);
            newSet.Click += new EventHandler(OpenSet_Click);
            count += 1;
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
        private void onLoadContent()
        {
            setLayout.Controls.Clear();

            /* foreach(var set in configFile)
             {
                 Button setBtn = new Button();
                 setBtn.Text = set.name;
                 setBtn.UseVisualStyleBackColor = true;
                 setBtn.Height = 50;
                 setBtn.Width = 150;
                 setBtn.Name = Convert.ToString(count);
                 EventArgs e = new EventArgs();
                 setBtn.Click += new EventHandler(OpenSet_Click);
                 setLayout.Controls.Add(setBtn);
                 count += 1;
             }*/
        }
    }
}
