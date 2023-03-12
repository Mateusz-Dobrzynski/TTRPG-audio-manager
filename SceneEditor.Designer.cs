namespace TTRPG_Audio_Manager
{
    partial class SceneEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SceneEditor));
            this.tblPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnEnd = new System.Windows.Forms.Button();
            this.playSceneBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tblPanel
            // 
            this.tblPanel.ColumnCount = 8;
            this.tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 226F));
            this.tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tblPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tblPanel.Location = new System.Drawing.Point(12, 31);
            this.tblPanel.Name = "tblPanel";
            this.tblPanel.RowCount = 1;
            this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblPanel.Size = new System.Drawing.Size(770, 342);
            this.tblPanel.TabIndex = 0;
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnEnd.Location = new System.Drawing.Point(38, 394);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(97, 35);
            this.btnEnd.TabIndex = 1;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // playSceneBtn
            // 
            this.playSceneBtn.BackColor = System.Drawing.Color.LimeGreen;
            this.playSceneBtn.Location = new System.Drawing.Point(156, 394);
            this.playSceneBtn.Name = "playSceneBtn";
            this.playSceneBtn.Size = new System.Drawing.Size(97, 35);
            this.playSceneBtn.TabIndex = 2;
            this.playSceneBtn.Text = "Play Scene";
            this.playSceneBtn.UseVisualStyleBackColor = false;
            this.playSceneBtn.Click += new System.EventHandler(this.playSceneBtn_Click);
            // 
            // SceneEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(794, 441);
            this.Controls.Add(this.playSceneBtn);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.tblPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SceneEditor";
            this.Text = "TTRPG Audio Manager: Scene Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tblPanel;
        private Button btnEnd;
        private Button playSceneBtn;
    }
}