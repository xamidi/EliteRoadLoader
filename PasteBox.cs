using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EliteRoadLoader
{
    public partial class PasteBox : Form
    {
        public PasteBox(string Prompt, string Title = "", int XPos = -1, int YPos = -1)
        {
            InitializeComponent();
            lblPromt.Text = Prompt;
            Text = Title;
            Location = new Point(XPos, YPos);
        }

        public string Result
        {
            get
            {
                return txtInput.Text;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //Enable Ctrl+A for textboxes
        private void SelectAll_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }
    }
}
