using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wordpad
{
    public partial class Finder : Form
    {
        Wordpad caller;
        
        internal Wordpad Caller
        {
            set { caller = value; }
        }
        public Finder()
        {
            InitializeComponent();
        }
        private RichTextBoxFinds GetOptions()
        {
            RichTextBoxFinds rtbf = new RichTextBoxFinds();

            rtbf = RichTextBoxFinds.None;

            if (this.chkMatchCase.Checked == true)
            {
                rtbf = rtbf | RichTextBoxFinds.MatchCase;
            }

            if (this.chkWholeWord.Checked == true)
            {
                rtbf = rtbf | RichTextBoxFinds.WholeWord;
            }

            return rtbf;
        }

        int lastStop = 0;
        private void btNext_Click(object sender, EventArgs e)
        {

            if (lastStop == -1) { lastStop = 0; }

            lastStop = caller.rtbMain.Find(this.tbFinder.Text, lastStop, GetOptions());

            if (lastStop == -1)
            {
                MessageBox.Show("Search is completed.");
            }
            else
            {
                lastStop = lastStop + this.tbFinder.Text.Length;
                caller.Focus();
            }

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Finder_Load(object sender, EventArgs e)
        {

        }
    }
}
