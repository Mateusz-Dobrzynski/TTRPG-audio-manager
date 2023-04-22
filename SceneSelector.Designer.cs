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
            this.SuspendLayout();
            // 
            // ReturnButton
            // 
            this.ReturnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.ReturnButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.ReturnButton.FlatAppearance.BorderSize = 2;
            this.ReturnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReturnButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.ReturnButton.Location = new System.Drawing.Point(12, 399);
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
            this.AddSceneBtn.Location = new System.Drawing.Point(665, 15);
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
            this.sceneBox.Location = new System.Drawing.Point(280, 130);
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
            this.openSceneBtn.Location = new System.Drawing.Point(325, 175);
            this.openSceneBtn.Name = "openSceneBtn";
            this.openSceneBtn.Size = new System.Drawing.Size(125, 35);
            this.openSceneBtn.TabIndex = 4;
            this.openSceneBtn.Text = "Open Scene";
            this.openSceneBtn.UseVisualStyleBackColor = true;
            this.openSceneBtn.Click += new System.EventHandler(this.sceneOpener);
            // 
            // SceneSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.openSceneBtn);
            this.Controls.Add(this.sceneBox);
            this.Controls.Add(this.AddSceneBtn);
            this.Controls.Add(this.ReturnButton);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SceneSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TTRPG Audio Manager: Scene Selector";
            this.ResumeLayout(false);

        }

        #endregion
        private Button ReturnButton;
        private Button AddSceneBtn;
        private ComboBox sceneBox;
        private Button openSceneBtn;
    }
}