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

namespace TTRPG_Audio_Manager
{
    public partial class Creator : Form
    {
        public Creator()
        {
            InitializeComponent();
        }
        //creators purpose is to get an input from user and assign it as the set/scene name
        public string CreatorName(string name)
        {
            return name;
        }

        public void submitCreator_Click(object sender, EventArgs e)
        {
            if(textBoxCreator.Modified == true)
            {
                CreatorName(textBoxCreator.Text);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
