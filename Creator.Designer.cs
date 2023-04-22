using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;



namespace TTRPG_Audio_Manager
{
    partial class Creator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Creator));
            this.NameLabel = new System.Windows.Forms.Label();
            this.textBoxCreator = new System.Windows.Forms.TextBox();
            this.submitCreator = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.NameLabel.Location = new System.Drawing.Point(153, 25);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(66, 25);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name:";
            // 
            // textBoxCreator
            // 
            this.textBoxCreator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.textBoxCreator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCreator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.textBoxCreator.Location = new System.Drawing.Point(100, 65);
            this.textBoxCreator.Name = "textBoxCreator";
            this.textBoxCreator.Size = new System.Drawing.Size(175, 23);
            this.textBoxCreator.TabIndex = 1;
            // 
            // submitCreator
            // 
            this.submitCreator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.submitCreator.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.submitCreator.FlatAppearance.BorderSize = 2;
            this.submitCreator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitCreator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(47)))), ((int)(((byte)(222)))));
            this.submitCreator.Location = new System.Drawing.Point(144, 112);
            this.submitCreator.Name = "submitCreator";
            this.submitCreator.Size = new System.Drawing.Size(75, 25);
            this.submitCreator.TabIndex = 2;
            this.submitCreator.Text = "Submit";
            this.submitCreator.UseVisualStyleBackColor = false;
            this.submitCreator.Click += new System.EventHandler(this.submitCreator_Click);
            // 
            // Creator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(376, 178);
            this.Controls.Add(this.submitCreator);
            this.Controls.Add(this.textBoxCreator);
            this.Controls.Add(this.NameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Creator";
            this.Text = "Creator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label NameLabel;
        private TextBox textBoxCreator;
        private Button submitCreator;
    }
}