using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace wordpad
{
    public partial class Wordpad : Form
    {
        float zoomFactor = 1;
        string memoryText = "";
        int currentFontSize = 16;
        int zoomValue = 0;
        FontFamily currentFontFamily = FontFamily.GenericSansSerif;
        FontStyle currentFontStyle = System.Drawing.FontStyle.Regular;
        Color currentFontColor;
        Color currentBackColor;
        bool currentFontItalic = false;
        bool currentFontBold = false;
        bool currentFontUnderline = false;
        private Size rtbOriginalSize;
        Point rtbOrginalLocation;
        int counter = 0;
        private PrintDocument docToPrint;
        private string stringToPrint;

        public Wordpad()
        {
            InitializeComponent();
            rtbOriginalSize = rtbMain.Size;
            rtbOrginalLocation = rtbMain.Location;
            CenterToScreen();
            this.docToPrint = new PrintDocument();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in FontFamily.Families)
            {
                cbFontStyle.Items.Add(font.Name);

            }
            for (int i = 10; i <= 72; i += 2)
            {
                cbFontSize.Items.Add(i);
            }

        }
        private void btpaste_Click(object sender, EventArgs e)
        {
            rtbMain.SelectedText = "";
            rtbMain.SelectedText = memoryText;
        }
        private void btCut_Click(object sender, EventArgs e)
        {
            memoryText = rtbMain.SelectedText;
            rtbMain.SelectedText = "";

        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            memoryText = rtbMain.SelectedText;
        }
        private void rtbMain_TextChanged(object sender, EventArgs e)
        {
            //rtbMain.SelectionFont = new Font(currentFontFamily, currentFontSize, currentFontStyle);
            //tbMain.SelectionFont = new Font(toolStripComboBox1.Text, int.Parse(comboBox1.Text));
        }



        private void boldTextBT_Click(object sender, EventArgs e)
        {
            if (currentFontBold == false)
            {
                currentFontStyle |= System.Drawing.FontStyle.Bold;
                rtbMain.SelectionFont = new Font(currentFontFamily, currentFontSize, currentFontStyle);
                currentFontBold = true;
            }
            else
            {
                currentFontStyle = System.Drawing.FontStyle.Regular;
                rtbMain.SelectionFont = new Font(currentFontFamily, currentFontSize, currentFontStyle);
                currentFontBold = false;
            }
        }

        private void italicTextBT_Click(object sender, EventArgs e)
        {
            if (currentFontItalic == false)
            {
                currentFontStyle |= System.Drawing.FontStyle.Italic;
                rtbMain.SelectionFont = new Font(currentFontFamily, currentFontSize, currentFontStyle);
                currentFontItalic = true;
            }
            else
            {
                currentFontStyle = System.Drawing.FontStyle.Regular;
                rtbMain.SelectionFont = new Font(currentFontFamily, currentFontSize, currentFontStyle);
                currentFontItalic = false;
            }
        }

        private void underlineTextBT_Click_1(object sender, EventArgs e)
        {
            if (currentFontUnderline == false)
            {
                currentFontStyle |= System.Drawing.FontStyle.Underline;
                rtbMain.SelectionFont = new Font(currentFontFamily, currentFontSize, currentFontStyle);
                currentFontUnderline = true;
            }
            else
            {
                currentFontStyle = System.Drawing.FontStyle.Regular;
                rtbMain.SelectionFont = new Font(currentFontFamily, currentFontSize, currentFontStyle);
                currentFontUnderline = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save my new File";
            saveFileDialog.Filter = "Rich Text Format | *.rtf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                rtbMain.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
            }
        }


        private void textColorChager_ButtonClick(object sender, EventArgs e)
        {

            rtbMain.SelectionColor = currentFontColor;

        }

        private void textColorChager_DropDownItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {
            if (textColorChager.DropDownItems[0].Selected)
            {
                rtbMain.SelectionColor = Color.Red;
                currentFontColor = Color.Red;
            }
            else if (textColorChager.DropDownItems[1].Selected)
            {
                rtbMain.SelectionColor = Color.Blue;
                currentFontColor = Color.Blue;
            }
            else if (textColorChager.DropDownItems[2].Selected)
            {
                rtbMain.SelectionColor = Color.Yellow;
                currentFontColor = Color.Yellow;
            }
            else if (textColorChager.DropDownItems[3].Selected)
            {
                rtbMain.SelectionColor = Color.White;
                currentFontColor = Color.White;
            }
            else if (textColorChager.DropDownItems[4].Selected)
            {
                rtbMain.SelectionColor = Color.Green;
                currentFontColor = Color.Green;
            }
        }


        private void textBackColorChanger_ButtonClick(object sender, EventArgs e)
        {
            rtbMain.SelectionBackColor = currentBackColor;
        }

        private void textBackColorChanger_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (textBackColorChanger.DropDownItems[0].Selected)
            {
                rtbMain.SelectionBackColor = Color.Red;
                currentBackColor = Color.Red;
            }
            else if (textBackColorChanger.DropDownItems[1].Selected)
            {
                rtbMain.SelectionBackColor = Color.Blue;
                currentBackColor = Color.Blue;
            }
            else if (textBackColorChanger.DropDownItems[2].Selected)
            {
                rtbMain.SelectionBackColor = Color.Yellow;
                currentBackColor = Color.Yellow;
            }
            else if (textBackColorChanger.DropDownItems[3].Selected)
            {
                rtbMain.SelectionBackColor = Color.White;
                currentBackColor = Color.White;
            }
            else if (textBackColorChanger.DropDownItems[4].Selected)
            {
                rtbMain.SelectionBackColor = Color.Green;
                currentBackColor = Color.Green;
            }
        }
        private void ColorChanger(ToolStripSplitButton childButton, Color color)
        {
            if (childButton.DropDownItems[0].Selected)
            {
                rtbMain.SelectionBackColor = Color.Red;
                color = Color.Red;
            }
            else if (childButton.DropDownItems[1].Selected)
            {
                rtbMain.SelectionBackColor = Color.Blue;
                color = Color.Blue;
            }
            else if (childButton.DropDownItems[2].Selected)
            {
                rtbMain.SelectionBackColor = Color.Yellow;
                color = Color.Yellow;
            }
            else if (childButton.DropDownItems[3].Selected)
            {
                rtbMain.SelectionBackColor = Color.White;
                color = Color.White;
            }
            else if (childButton.DropDownItems[4].Selected)
            {
                rtbMain.SelectionBackColor = Color.Green;
                color = Color.Green;
            }
        }

        private void rtbMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Control)
            {
                rtbMain.SelectedText = memoryText;

            }
            else if (e.KeyCode == Keys.C && e.Control)
            {
                memoryText = rtbMain.SelectedText;
            }
            int tempNum;
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (char.IsDigit(rtbMain.Text[rtbMain.GetFirstCharIndexOfCurrentLine()]))
                    {
                        if (char.IsDigit(rtbMain.Text[rtbMain.GetFirstCharIndexOfCurrentLine() + 1]) && rtbMain.Text[rtbMain.GetFirstCharIndexOfCurrentLine() + 2] == '.')
                        {
                            tempNum = int.Parse(rtbMain.Text.Substring(rtbMain.GetFirstCharIndexOfCurrentLine(), 2));
                        }
                        else { tempNum = int.Parse(rtbMain.Text[rtbMain.GetFirstCharIndexOfCurrentLine()].ToString()); }

                        if (rtbMain.Text[rtbMain.GetFirstCharIndexOfCurrentLine() + 1] == '.' || (char.IsDigit(rtbMain.Text[rtbMain.GetFirstCharIndexOfCurrentLine() + 1]) && rtbMain.Text[rtbMain.GetFirstCharIndexOfCurrentLine() + 2] == '.'))
                        {
                            tempNum++;
                            rtbMain.SelectedText = "\r\n" + tempNum.ToString() + ". ";
                            e.SuppressKeyPress = true;
                        }
                    }
                    else if (rtbMain.Text[rtbMain.GetFirstCharIndexOfCurrentLine()] == '•')
                    {

                        rtbMain.SelectedText = "\r\n" + "• ";
                        e.SuppressKeyPress = true;
                    }
                }
                catch { }
            }
        }
        private void btAa_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (btAa.DropDownItems[0].Selected)
            {
                rtbMain.SelectedText = rtbMain.SelectedText.ToLower();
            }
            else if (btAa.DropDownItems[1].Selected)
            {
                rtbMain.SelectedText = rtbMain.SelectedText.ToUpper().Trim();
            }
            else if (btAa.DropDownItems[2].Selected)
            {
                if (rtbMain.SelectedText.Length <= 0) return;
                string startLetter = rtbMain.SelectedText.Substring(0, 1).ToUpper();
                string restLetters = rtbMain.SelectedText.Substring(1, rtbMain.SelectedText.Length - 1).ToLower();
                rtbMain.SelectedText = startLetter + restLetters;

            }
        }

        private void cbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbMain.SelectionFont = new Font(rtbMain.Text, int.Parse(cbFontSize.Text), currentFontStyle);
            currentFontSize = int.Parse(cbFontSize.Text);

        }
        private void cbFontStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbMain.SelectionFont = new Font(cbFontStyle.Text, int.Parse(cbFontSize.Text), currentFontStyle);

        }

        private void btCenterAllign_Click(object sender, EventArgs e)
        {
            rtbMain.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void btLeftAllign_Click(object sender, EventArgs e)
        {

            rtbMain.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void btRightAllign_Click(object sender, EventArgs e)
        {
            rtbMain.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void listStylesDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string temptext = rtbMain.SelectedText;
            int SelectionStart = rtbMain.SelectionStart;
            int SelectionLength = rtbMain.SelectionLength;

            rtbMain.SelectionStart = rtbMain.GetFirstCharIndexOfCurrentLine();
            rtbMain.SelectionLength = 0;
            if (listStyles.DropDownItems[0].Selected)
            {

                rtbMain.SelectedText = "1. ";
                int j = 2;
                for (int i = SelectionStart; i < SelectionStart + SelectionLength; i++)
                    if (rtbMain.Text[i] == '\n')
                    {
                        rtbMain.SelectionStart = i + 1;
                        rtbMain.SelectionLength = 0;
                        rtbMain.SelectedText = j.ToString() + ". ";
                        j++;
                        SelectionLength += 3;
                    }
            }
            else if (listStyles.DropDownItems[1].Selected)
            {
                rtbMain.SelectedText = "• ";
                for (int i = SelectionStart; i < SelectionStart + SelectionLength; i++)
                    if (rtbMain.Text[i] == '\n')
                    {
                        rtbMain.SelectionStart = i + 1;
                        rtbMain.SelectionLength = 0;
                        rtbMain.SelectedText = "• ";
                        SelectionLength += 2;
                    }

            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            string lstrFile = fileDialog.FileName;
            Bitmap myBitmap = new Bitmap(lstrFile);

            Clipboard.SetDataObject(myBitmap);
            //Bitmap mubadile buferine kocuruldu.
            DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);
            //Obyekt novu ucun format secilir.
            //Verilənlərin yapışdırıla biləcəyini yoxladıqdan sonra yapışdırırsan
            if (rtbMain.CanPaste(myFormat))
            {
                rtbMain.Paste(myFormat);
            }
            else
            {
                MessageBox.Show("Secdiyiniz format desteklenmir .");
            }

        }

        private void btUndo_Click(object sender, EventArgs e)
        {
            rtbMain.Undo();
        }

        private void btRedo_Click(object sender, EventArgs e)
        {
            rtbMain.Redo();
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            Finder find = new Finder();
            find.tbFinder.Text = this.rtbMain.SelectedText;
            //rtbMain.SelectedText = find.tbFinder.Text;
            find.Caller = this;
            find.Show(this);
        }
        private void btReplace_Click(object sender, EventArgs e)
        {
            Replace replace = new Replace();
            replace.tbFinder.Text = this.rtbMain.SelectedText;
            rtbMain.SelectedText = replace.tbReplace.Text;
            replace.Caller = this;
            replace.Show(this);

        }


        private void btZoomIn_Click(object sender, EventArgs e)
        {
            Size rtbSize = rtbMain.Size;
            if (rtbMain.Left < 10) { rtbMain.Left = 0;rtbMain.SelectionRightIndent=25; }
            if (rtbMain.Left >10)
            {
                
                rtbSize.Width += rtbOriginalSize.Width / 10;
                //rtbMain.Left -= rtbOriginalSize.Width/20;
                rtbOrginalLocation = new Point(rtbMain.Left - (rtbOriginalSize.Width / 20), rtbMain.Top);
                rtbMain.Location = rtbOrginalLocation;
                rtbMain.Size = rtbSize;
                rtbMain.Location = this.rtbMain.Location;
                rtbMain.AutoWordSelection = true;
                zoomFactor += 0.05f;
                rtbMain.ZoomFactor = zoomFactor;
                if (counter == 0)
                {
                    rtbOriginalSize = rtbMain.Size;
                }
                counter++;
                if (30 < tbZoomChanger.Value && 40 > tbZoomChanger.Value)
                {
                    label7.Text = (tbZoomChanger.Value * 4).ToString();
                }
                else if (40 < tbZoomChanger.Value)
                {
                    label7.Text = (tbZoomChanger.Value * 10).ToString();
                }
                else if(tbZoomChanger.Value <30)
                {
                    label7.Text = (tbZoomChanger.Value+ (rtbOriginalSize.Width / 10)).ToString();
                }
                
            }
        }

        private void btZoomOut_Click(object sender, EventArgs e)
        {
           
                Size rtbSize = rtbMain.Size;
            if (rtbSize.Width> 200)
            {
                rtbSize.Width -= rtbOriginalSize.Width / 10;
                rtbOrginalLocation = new Point(rtbMain.Left + (rtbOriginalSize.Width / 20), rtbMain.Top);
                rtbMain.Location = rtbOrginalLocation;
                rtbMain.Size = rtbSize;
                rtbMain.Location = this.rtbMain.Location;
                rtbMain.AutoWordSelection = true;
                if (zoomFactor > 0.05f)
                    zoomFactor -= 0.05f;
                rtbMain.ZoomFactor = zoomFactor;

                if (30<tbZoomChanger.Value && 40 >tbZoomChanger.Value)
                {
                    label7.Text = (tbZoomChanger.Value * 4).ToString();
                }
                else if(40 < tbZoomChanger.Value)
                {
                    label7.Text = (tbZoomChanger.Value * 10).ToString();
                }
                else if(tbZoomChanger.Value == 30)
                {
                    label7.Text = 100.ToString();
                }
                else if (tbZoomChanger.Value < 30)
                {
                    label7.Text = (tbZoomChanger.Value + (rtbOriginalSize.Width / 10)).ToString();
                }
            }
        }

        private void btSelectAll_Click(object sender, EventArgs e)
        {
            rtbMain.SelectAll();
        }


        private void tbZoomChanger_Scroll(object sender, EventArgs e)
        {
            // bir int eded ustde qeyd ele sonra muqayse ile artib azalan oldugunu mueyyen ele 
            if (tbZoomChanger.Value > zoomValue)
            {

                btZoomIn.PerformClick();
                zoomValue = tbZoomChanger.Value;
                tbZoomChanger.Value = zoomValue;
            }
            else
            {
                zoomValue = tbZoomChanger.Value;
                tbZoomChanger.Value = zoomValue;
                btZoomOut.PerformClick();
            }
        }

        private void btZoomOut_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbFontSize_TextChanged(object sender, EventArgs e)
        {
            rtbMain.SelectionFont = new Font(currentFontFamily, int.Parse(cbFontSize.Text), currentFontStyle);
            currentFontSize = int.Parse(cbFontSize.Text);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            
            rtbMain.Left = 378;
            rtbMain.Size = rtbOriginalSize;
            tbZoomChanger.Value = 30;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
            {
                flowLayoutPanel1.Hide();
            }
            else flowLayoutPanel1.Show();
        }
        private string SetFilePath()
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "RTF (*.rtf)|*.rtf|TXT (*.txt)|*.txt";
            if (s.ShowDialog(this) == DialogResult.OK)
            {
                return s.FileName;
            }
            else
            {
                return "";
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rtbMain.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Open my new File";
            of.Filter = "RTF (*.rtf)|*.rtf|TXT (*.txt)|*.txt";
            if (of.ShowDialog() == DialogResult.OK)
            {
                rtbMain.LoadFile(of.FileName, RichTextBoxStreamType.RichText);
            }
            this.Text = of.FileName;
        }
        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            using (Brush brush = new SolidBrush(currentFontColor))
            {
                e.Graphics.DrawString(rtbMain.Text, new Font(rtbMain.Font.ToString(), rtbMain.Font.Size), brush, 66, 50);
                // perform operations
            }
        }
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument1 = new PrintDocument();
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", 1000, 1000);
            printDocument1.PrintPage += new PrintPageEventHandler(this.PrintDocument_PrintPage);
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = printDocument1;
            DialogResult result = printPreviewDialog1.ShowDialog();
            if (result == DialogResult.OK)
                printDocument1.Print();
        }

        private void Wordpad_SizeChanged(object sender, EventArgs e)
        {
            rtbOriginalSize = rtbMain.Size;
            rtbOrginalLocation = rtbMain.Location;
        }
     
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.ProcessStartInfo procInfo = new System.Diagnostics.ProcessStartInfo();
            //procInfo.FileName = ("mspaint.exe");
            System.Diagnostics.Process.Start("mspaint.exe");
            
        }
        //[DllImport("user32.dll")]
        //static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private void fastPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Document";
            printDlg.Document = printDoc;
            printDlg.Document = docToPrint;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            //Call ShowDialog  
            if(printDlg.ShowDialog() == DialogResult.OK)
            {
                StringReader reader = new StringReader(this.rtbMain.Text);
                stringToPrint = reader.ReadToEnd();
                this.docToPrint.PrintPage += new PrintPageEventHandler(this.docToPrintCustom);
                this.docToPrint.Print();
            }
        }
        private void docToPrintCustom(object sender, PrintPageEventArgs e)
        {
            Font PrintFont = this.rtbMain.Font;
            SolidBrush PrintBrush = new SolidBrush(Color.Black);

            int LinesPerPage = 0;
            int charactersOnPage = 0;

            e.Graphics.MeasureString(stringToPrint, PrintFont, e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out LinesPerPage);

            e.Graphics.DrawString(stringToPrint, PrintFont, PrintBrush, e.MarginBounds, StringFormat.GenericTypographic);

            stringToPrint = stringToPrint.Substring(charactersOnPage);

            MessageBox.Show(stringToPrint.Length.ToString());
            e.HasMorePages = (stringToPrint.Length > 0);

            PrintBrush.Dispose();
        }


        // formanin size change eventine orginal szie rtbmainin size sine beraber ele
        // eger miqyas 100% dirse
        //faiz labeli qoy 10- 100 - 500 button lar 10 % artirsin birde butonlara basanda gosterge deyissin acilanda ortada gelsin oda 100 olsun
        // duymeye basanda paint programini acsin'

    }
}