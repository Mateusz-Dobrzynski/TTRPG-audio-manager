using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTRPG_Audio_Manager
{
    public partial class SetSelector : Form
    {
        public SetSelector()
        {
            InitializeComponent();
            this.ReturnButton.Click += new EventHandler(ReturnButton_Click);
        }
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
