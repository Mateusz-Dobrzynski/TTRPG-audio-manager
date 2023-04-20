namespace TTRPG_Audio_Manager
{
    partial class Index
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
            this.loadSetFile = new System.Windows.Forms.Button();
            this.createNewSet = new System.Windows.Forms.Button();
            this.directoryBtn = new System.Windows.Forms.Button();
            this.dLabel = new System.Windows.Forms.Label();
            this.directoryPath = new System.Windows.Forms.Label();
            this.setLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // loadSetFile
            // 
            this.loadSetFile.BackColor = System.Drawing.SystemColors.AppWorkspace;
            resources.ApplyResources(this.loadSetFile, "loadSetFile");
            this.loadSetFile.Name = "loadSetFile";
            this.loadSetFile.UseVisualStyleBackColor = false;
            this.loadSetFile.Click += new System.EventHandler(this.LoadSetFile_Click);
            // 
            // createNewSet
            // 
            this.createNewSet.BackColor = System.Drawing.SystemColors.AppWorkspace;
            resources.ApplyResources(this.createNewSet, "createNewSet");
            this.createNewSet.Name = "createNewSet";
            this.createNewSet.UseVisualStyleBackColor = false;
            this.createNewSet.Click += new System.EventHandler(this.CreateNewSet_Click);
            // 
            // directoryBtn
            // 
            this.directoryBtn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            resources.ApplyResources(this.directoryBtn, "directoryBtn");
            this.directoryBtn.Name = "directoryBtn";
            this.directoryBtn.UseVisualStyleBackColor = false;
            this.directoryBtn.Click += new System.EventHandler(this.directoryBtn_Click);
            // 
            // dLabel
            // 
            resources.ApplyResources(this.dLabel, "dLabel");
            this.dLabel.Name = "dLabel";
            // 
            // directoryPath
            // 
            resources.ApplyResources(this.directoryPath, "directoryPath");
            this.directoryPath.Name = "directoryPath";
            // 
            // setLayout
            // 
            resources.ApplyResources(this.setLayout, "setLayout");
            this.setLayout.Name = "setLayout";
            // 
            // Index
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.setLayout);
            this.Controls.Add(this.dLabel);
            this.Controls.Add(this.directoryPath);
            this.Controls.Add(this.directoryBtn);
            this.Controls.Add(this.createNewSet);
            this.Controls.Add(this.loadSetFile);
            this.Name = "Index";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button loadSetFile;
        private Button createNewSet;
        private Button directoryBtn;
        private Label dLabel;
        private Label directoryPath;
        private FlowLayoutPanel setLayout;
    }
}