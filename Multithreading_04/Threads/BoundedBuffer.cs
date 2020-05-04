using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multithreading_04
{
    class BoundedBuffer
    {
        public enum Status
        {
            Checked,
            Empty,
            New
        }

        private string[] myStringBuffer;
        private Status[] myStatusBuffer;

        private RichTextBox myRichTextBox;

        private bool myNotifyUser;         //Notify user on each replacement

        private int myBufferSize;
        private int myNbrOfReplacements;
        private int myStartPosition;       //Start position in textbox to use for marking

        private int myWritePos;            //Writer Pointer
        private int myFindPos;             //Modify Pointer
        private int myReadPos;             //Reader Pointer

        private string myFindString;       //The inputted string for modifier to find and replace
        private string myReplaceString;    //The inputted string to replace the found string

        private object myLock = new object();

        public BoundedBuffer(int bufferSize, RichTextBox richTextBox, bool notifyUser, string findString, string replaceString)
        {
            this.myBufferSize = bufferSize;
            this.myRichTextBox = richTextBox;
            this.myNotifyUser = notifyUser;
            this.myFindString = findString;
            this.myReplaceString = replaceString;

            myNbrOfReplacements = 0;

            myWritePos = 0;
            myFindPos = 0;
            myReadPos = 0;

            myStringBuffer = new string[bufferSize];
            for (int i = 0; i < myStringBuffer.Length; i++)
            {
                myStringBuffer[i] = string.Empty;
            }

            myStatusBuffer = new Status[bufferSize];
            for (int i = 0; i < myStatusBuffer.Length; i++)
            {
                myStatusBuffer[i] = Status.Empty;
            }
        }

        public bool Write(string stringToWrite)
        {
            if (myStatusBuffer[myWritePos] == Status.Empty)
            {
                myStringBuffer[myWritePos] = stringToWrite;

                myStatusBuffer[myWritePos] = Status.New;
                myWritePos = (myWritePos + 1) % myBufferSize;

                return true;
            }
            return false;
        }

        public bool Modify()
        {
            if (myStatusBuffer[myFindPos] == Status.New)
            {
                if (myStringBuffer[myFindPos] == myFindString)
                {
                    myStringBuffer[myFindPos] = myReplaceString;
                }

                myStatusBuffer[myFindPos] = Status.Checked;
                myFindPos = (myFindPos + 1) % myBufferSize;

                return true;
            }
            return false;
        }

        public string Read()
        {
            if (myStatusBuffer[myReadPos] == Status.Checked)
            {
                string readString = myStringBuffer[myReadPos];

                myStatusBuffer[myReadPos] = Status.Empty;
                myReadPos = (myReadPos + 1) % myBufferSize;

                return readString;
            }
            return string.Empty;
        }

        private void ReplaceAt()
        {

        }

        private void Select()
        {
            myRichTextBox.InvokeIfRequired(() => 
            {
                myRichTextBox.SelectionStart = myStartPosition;
                myRichTextBox.SelectionLength = myFindString.Length;
            });       
        }

        private void Mark()
        {

        }
    }
}
