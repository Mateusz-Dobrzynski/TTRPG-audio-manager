namespace TTRPG_Audio_Manager
{
    partial class SceneSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SceneSelector));
            this.ReturnButton = new System.Windows.Forms.Button();
            this.AddSceneBtn = new System.Windows.Forms.Button();
            this.sceneBox = new System.Windows.Forms.ComboBox();
            this.openSceneBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.minBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.deleteScene = new System.Windows.Forms.Button();
            this.notSoSureButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReturnButton
            // 
            this.ReturnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.ReturnButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.ReturnButton.FlatAppearance.BorderSize = 2;
            this.ReturnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReturnButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.ReturnButton.Location = new System.Drawing.Point(14, 439);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(141, 39);
            this.ReturnButton.TabIndex = 1;
            this.ReturnButton.Text = "Return";
            this.ReturnButton.UseVisualStyleBackColor = false;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // AddSceneBtn
            // 
            this.AddSceneBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.AddSceneBtn.CausesValidation = false;
            this.AddSceneBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.AddSceneBtn.FlatAppearance.BorderSize = 2;
            this.AddSceneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddSceneBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.AddSceneBtn.Location = new System.Drawing.Point(667, 55);
            this.AddSceneBtn.Name = "AddSceneBtn";
            this.AddSceneBtn.Size = new System.Drawing.Size(125, 35);
            this.AddSceneBtn.TabIndex = 2;
            this.AddSceneBtn.Text = "Add New Scene";
            this.AddSceneBtn.UseVisualStyleBackColor = false;
            this.AddSceneBtn.Click += new System.EventHandler(this.AddSceneBtn_Click);
            // 
            // sceneBox
            // 
            this.sceneBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.sceneBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sceneBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.sceneBox.FormattingEnabled = true;
            this.sceneBox.Location = new System.Drawing.Point(282, 170);
            this.sceneBox.Name = "sceneBox";
            this.sceneBox.Size = new System.Drawing.Size(225, 23);
            this.sceneBox.TabIndex = 3;
            // 
            // openSceneBtn
            // 
            this.openSceneBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.openSceneBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.openSceneBtn.FlatAppearance.BorderSize = 2;
            this.openSceneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openSceneBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.openSceneBtn.Location = new System.Drawing.Point(327, 215);
            this.openSceneBtn.Name = "openSceneBtn";
            this.openSceneBtn.Size = new System.Drawing.Size(125, 35);
            this.openSceneBtn.TabIndex = 4;
            this.openSceneBtn.Text = "Open Scene";
            this.openSceneBtn.UseVisualStyleBackColor = true;
            this.openSceneBtn.Click += new System.EventHandler(this.sceneOpener);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::TTRPG_Audio_Manager.Properties.Resources.panel;
            this.panel1.Controls.Add(this.minBtn);
            this.panel1.Controls.Add(this.exitBtn);
            this.panel1.Location = new System.Drawing.Point(-2, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 44);
            this.panel1.TabIndex = 5;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // minBtn
            // 
            this.minBtn.BackColor = System.Drawing.Color.Transparent;
            this.minBtn.FlatAppearance.BorderSize = 0;
            this.minBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.minBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.minBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.minBtn.Location = new System.Drawing.Point(750, 11);
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(25, 25);
            this.minBtn.TabIndex = 1;
            this.minBtn.Text = "_";
            this.minBtn.UseVisualStyleBackColor = true;
            this.minBtn.Click += new System.EventHandler(this.minBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Transparent;
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.exitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.exitBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.exitBtn.Location = new System.Drawing.Point(775, 11);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(25, 25);
            this.exitBtn.TabIndex = 0;
            this.exitBtn.Text = "X";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // deleteScene
            // 
            this.deleteScene.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.deleteScene.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.deleteScene.FlatAppearance.BorderSize = 2;
            this.deleteScene.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteScene.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.deleteScene.Location = new System.Drawing.Point(327, 270);
            this.deleteScene.Name = "deleteScene";
            this.deleteScene.Size = new System.Drawing.Size(125, 35);
            this.deleteScene.TabIndex = 6;
            this.deleteScene.Text = "Delete Scene";
            this.deleteScene.UseVisualStyleBackColor = true;
            this.deleteScene.Click += new System.EventHandler(this.deleteScene_Click);
            // 
            // notSoSureButton
            // 
            this.notSoSureButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.notSoSureButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.notSoSureButton.FlatAppearance.BorderSize = 2;
            this.notSoSureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notSoSureButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.notSoSureButton.Location = new System.Drawing.Point(458, 270);
            this.notSoSureButton.Name = "notSoSureButton";
            this.notSoSureButton.Size = new System.Drawing.Size(36, 35);
            this.notSoSureButton.TabIndex = 7;
            this.notSoSureButton.Text = "X";
            this.notSoSureButton.UseVisualStyleBackColor = true;
            this.notSoSureButton.Visible = false;
            this.notSoSureButton.Click += new System.EventHandler(this.notSoSureButton_Click);
            // 
            // SceneSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.notSoSureButton);
            this.Controls.Add(this.deleteScene);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.openSceneBtn);
            this.Controls.Add(this.sceneBox);
            this.Controls.Add(this.AddSceneBtn);
            this.Controls.Add(this.ReturnButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SceneSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TTRPG Audio Manager: Scene Selector";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Button ReturnButton;
        private Button AddSceneBtn;
        private ComboBox sceneBox;
        private Button openSceneBtn;
        private Panel panel1;
        private Button exitBtn;
        private Button minBtn;
        private Button deleteScene;
        private Button notSoSureButton;
    }
}