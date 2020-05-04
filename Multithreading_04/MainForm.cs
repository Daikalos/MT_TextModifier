using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Multithreading_04
{
    public partial class MainForm : Form
    {
        private BoundedBuffer myBuffer;
        private Reader myReader;
        private Writer myWriter;
        private Modifier myModifier;

        private int myBufferSize;

        public MainForm()
        {
            InitializeComponent();

            myBufferSize = 15;
        }

        private void FileSelect_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openTextFile = new OpenFileDialog())
            {
                openTextFile.Title = "Open Text File";
                openTextFile.Filter = "TXT Files|*.txt";

                if (openTextFile.ShowDialog() == DialogResult.OK)
                {
                    if (openTextFile.CheckFileExists)
                    {
                        SourceTextBox.Text = File.ReadAllText(openTextFile.FileName);
                        myBuffer = (SourceTextBox.Text.Length > myBufferSize) ?
                            new BoundedBuffer(myBufferSize) : 
                            new BoundedBuffer(SourceTextBox.Text.Length - 1);
                    }
                }
            }
        }

        private void CopyToDestButton_Click(object sender, EventArgs e)
        {

        }

        private void ClearDestButton_Click(object sender, EventArgs e)
        {

        }
    }
}
