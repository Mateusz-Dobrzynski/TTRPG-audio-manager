using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TTRPG_Audio_Manager
{

    public partial class Creator : Form
    {
        //Allowing to drag and drop the window
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //Creating an instance so other windows can access certain objects in this window
        public static Creator instance;
        public TextBox txtBox;
        public Creator()
        {
            InitializeComponent();
            //assigning objects to instance
            instance = this;
            txtBox = textBoxCreator;
        }
        //submiting the name
        public void submitCreator_Click(object sender, EventArgs e)
        {
            if (textBoxCreator.Modified == true) //if textbox was modified the button ends the creator
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        private void minBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}