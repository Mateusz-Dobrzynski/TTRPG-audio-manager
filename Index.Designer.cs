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
        /// 
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
            this.loadSetFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.loadSetFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.loadSetFile.FlatAppearance.BorderSize = 2;
            resources.ApplyResources(this.loadSetFile, "loadSetFile");
            this.loadSetFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.loadSetFile.Name = "loadSetFile";
            this.loadSetFile.UseVisualStyleBackColor = false;
            this.loadSetFile.Click += new System.EventHandler(this.LoadSetFile_Click);
            // 
            // createNewSet
            // 
            this.createNewSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.createNewSet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.createNewSet.FlatAppearance.BorderSize = 2;
            resources.ApplyResources(this.createNewSet, "createNewSet");
            this.createNewSet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.createNewSet.Name = "createNewSet";
            this.createNewSet.UseVisualStyleBackColor = false;
            this.createNewSet.Click += new System.EventHandler(this.CreateNewSet_Click);
            // 
            // directoryBtn
            // 
            this.directoryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.directoryBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.directoryBtn.FlatAppearance.BorderSize = 2;
            this.directoryBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            resources.ApplyResources(this.directoryBtn, "directoryBtn");
            this.directoryBtn.Name = "directoryBtn";
            this.directoryBtn.UseVisualStyleBackColor = false;
            this.directoryBtn.Click += new System.EventHandler(this.directoryBtn_Click);
            // 
            // dLabel
            // 
            resources.ApplyResources(this.dLabel, "dLabel");
            this.dLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.dLabel.Name = "dLabel";
            // 
            // directoryPath
            // 
            resources.ApplyResources(this.directoryPath, "directoryPath");
            this.directoryPath.Name = "directoryPath";
            // 
            // setLayout
            // 
            this.setLayout.BackgroundImage = global::TTRPG_Audio_Manager.Properties.Resources.graphic1;
            resources.ApplyResources(this.setLayout, "setLayout");
            this.setLayout.Name = "setLayout";
            // 
            // Index
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(24)))));
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