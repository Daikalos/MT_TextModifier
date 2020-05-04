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
        private BoundedBuffer myBuffer; //Store each string in here
        private Writer myWriter;        //Writer puts string in buffer
        private Modifier myModifier;    //Modifier modifies string in buffer
        private Reader myReader;        //Reader stores string in buffer to output list

        private int myBufferSize;       //Size of how many strings can be handled before writer has to wait

        public static MainForm Form;

        public MainForm()
        {
            InitializeComponent();

            Form = this;

            myBufferSize = 15;
        }

        private void OpenFile_Click(object sender, EventArgs e)
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
                    }
                }
            }
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {

        }

        private void FileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CopyToDestButton_Click(object sender, EventArgs e)
        {
            List<string> sourceText = SourceTextBox.Text.Split(' ').ToList();

            myBuffer = (sourceText.Count > myBufferSize) ?
                new BoundedBuffer(myBufferSize, SourceTextBox, NotifyUserCheck.Checked, FindTextBox.Text, ReplaceTextBox.Text) :
                new BoundedBuffer((sourceText.Count - 1), SourceTextBox, NotifyUserCheck.Checked, FindTextBox.Text, ReplaceTextBox.Text);

            myWriter = new Writer(myBuffer, sourceText);
            myModifier = new Modifier(myBuffer, sourceText.Count);
            myReader = new Reader(myBuffer, sourceText.Count);
        }

        private void ClearDestButton_Click(object sender, EventArgs e)
        {

        }

        public void SetDestinationText()
        {
            DestinationTextBox.InvokeIfRequired(() =>
            {
                DestinationTextBox.Text = string.Join(" ", myReader.GetText);
            });
        }
    }
}
