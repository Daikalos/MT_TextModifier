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
using System.Text.RegularExpressions;

namespace Multithreading_04
{
    public partial class MainForm : Form
    {
        private BoundedBuffer myBuffer; //Handle find and replace logic here
        private Writer myWriter;        //Writer puts string in buffer
        private Modifier myModifier;    //Modifier modifies string in buffer
        private Reader myReader;        //Reader stores string in buffer to output list

        private int myBufferSize;       //Size of how many strings can be handled before writer has to wait
        private string mySavedSourceText;    //The loaded text from txt file

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
                openTextFile.Filter = "txt files|*.txt";

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
            using (SaveFileDialog saveTextFile = new SaveFileDialog())
            {
                saveTextFile.Title = "Save Text File";
                saveTextFile.Filter = "txt files|*.txt";

                if (saveTextFile.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveTextFile.FileName, DestinationTextBox.Text);
                }
            }
        }

        private void FileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CopyToDestButton_Click(object sender, EventArgs e)
        {
            //Split by any character that does not match a word character
            List<string> splitSourceText = Regex.Split(SourceTextBox.Text, @"([^\w])").ToList();

            //Create new buffer and make sure buffer size is not larger than amount of words in text
            myBuffer = (splitSourceText.Count > myBufferSize) ?
                new BoundedBuffer(myBufferSize, SourceTextBox, NotifyUserCheck.Checked, FindTextBox.Text, ReplaceTextBox.Text) :
                new BoundedBuffer((splitSourceText.Count - 1), SourceTextBox, NotifyUserCheck.Checked, FindTextBox.Text, ReplaceTextBox.Text);

            myWriter = new Writer(myBuffer, splitSourceText);
            myModifier = new Modifier(myBuffer, splitSourceText.Count);
            myReader = new Reader(myBuffer, splitSourceText.Count);

            mySavedSourceText = SourceTextBox.Text;

            CopyToDestButton.Enabled = false;
            ClearDestButton.Enabled = true;
        }

        private void ClearDestButton_Click(object sender, EventArgs e)
        {
            DestinationTextBox.Clear();

            //Clear sourcetextbox to remove marks and assign loaded text again
            SourceTextBox.Clear();
            SourceTextBox.Text = mySavedSourceText;

            CopyToDestButton.Enabled = true;
            ClearDestButton.Enabled = false;
        }

        private void NextMatchButton_Click(object sender, EventArgs e)
        {
            if (myBuffer != null)
            {
                if (myBuffer.NotifyUser)
                {
                    myBuffer.Notify();
                }
            }
        }

        private void NotifyUserCheck_CheckedChanged(object sender, EventArgs e)
        {
            NextMatchButton.Enabled = NotifyUserCheck.Checked;
        }

        public void SetDestinationText()
        {
            DestinationTextBox.InvokeIfRequired(() =>
            {
                DestinationTextBox.Text = string.Join("", myReader.GetText);

                int wordPosition = 0;
                foreach (string word in myReader.GetText)
                {
                    //Go through each word in output text, and if anything matches the ReplaceString, select and mark it
                    if (word == myBuffer.ReplaceString)
                    {
                        DestinationTextBox.SelectionStart = wordPosition;
                        DestinationTextBox.SelectionLength = word.Length;

                        DestinationTextBox.SelectionBackColor = Color.Green;
                        DestinationTextBox.SelectionColor = Color.White;
                    }
                    wordPosition += word.Length;
                }
            });
        }

        public void SetReplacementCount(int nbrOfReplacements)
        {
            ReplacementCountLabel.InvokeIfRequired(() =>
            {
                ReplacementCountLabel.Text = nbrOfReplacements.ToString();
            });
        }
    }
}
