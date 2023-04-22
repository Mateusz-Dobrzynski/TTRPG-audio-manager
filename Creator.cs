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
    }
}