using System.Threading;
using System.Windows.Forms;
using System.Drawing;

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

        private readonly string[] myStringBuffer;
        private readonly Status[] myStatusBuffer; //Empty -> New -> Checked -> Empty
                                                  //Writer -> Modifier -> Reader -> Writer
        private RichTextBox mySourceTextBox;

        private bool myNotifyUser;         //Notify user on each replacement

        private int myBufferSize;
        private int myReplacementCount;
        private int myStartPosition;       //Start position in textbox to use for selecting/marking

        private int myWritePos;            //Writer Pointer
        private int myFindPos;             //Modify Pointer
        private int myReadPos;             //Reader Pointer

        private string myFindString;       //The inputted string for modifier to find and replace
        private string myReplaceString;    //The inputted string to replace the found string

        //Lock access to shared resources and allow only one thread to be working with buffer at a time
        private readonly object mySyncLock = new object();
        //Lock used for notifying user when string is set to be modified
        private readonly object myLockNotify = new object();

        public bool NotifyUser => myNotifyUser;
        public string ReplaceString => myReplaceString;

        public BoundedBuffer(int bufferSize, RichTextBox richTextBox, bool notifyUser, string findString, string replaceString)
        {
            this.myBufferSize = bufferSize;
            this.mySourceTextBox = richTextBox;
            this.myNotifyUser = notifyUser;
            this.myFindString = findString;
            this.myReplaceString = replaceString;

            myReplacementCount = 0;
            myStartPosition = -(myFindString.Length);

            myWritePos = 0;
            myFindPos = 0;
            myReadPos = 0;

            //Create string buffer and set each string to empty
            myStringBuffer = new string[bufferSize];
            for (int i = 0; i < myStringBuffer.Length; i++)
            {
                myStringBuffer[i] = string.Empty;
            }

            //Create status buffer and set each status to empty
            myStatusBuffer = new Status[bufferSize];
            for (int i = 0; i < myStatusBuffer.Length; i++)
            {
                myStatusBuffer[i] = Status.Empty;
            }
        }

        /// <summary>
        /// Put stringToWrite in buffer if position is empty
        /// </summary>
        public bool Write(string stringToWrite)
        {
            lock (mySyncLock)
            {
                if (myStatusBuffer[myWritePos] == Status.Empty)
                {
                    myStringBuffer[myWritePos] = stringToWrite;

                    myStatusBuffer[myWritePos] = Status.New;
                    myWritePos = (myWritePos + 1) % myBufferSize;

                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Modifies string in buffer if position is new
        /// </summary>
        public bool Modify()
        {
            lock (mySyncLock)
            {
                if (myStatusBuffer[myFindPos] == Status.New)
                {
                    myStartPosition += myStringBuffer[myFindPos].Length;

                    if (myStringBuffer[myFindPos] == myFindString)
                    {
                        myStringBuffer[myFindPos] = myReplaceString;

                        HasBeenModified();
                    }

                    myStatusBuffer[myFindPos] = Status.Checked;
                    myFindPos = (myFindPos + 1) % myBufferSize;

                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Read string from buffer and return it
        /// </summary>
        public string Read()
        {
            lock (mySyncLock)
            {
                if (myStatusBuffer[myReadPos] == Status.Checked)
                {
                    string readString = myStringBuffer[myReadPos];

                    myStatusBuffer[myReadPos] = Status.Empty;
                    myReadPos = (myReadPos + 1) % myBufferSize;

                    return readString;
                }
            }
            return null;
        }

        /// <summary>
        /// If string buffer was successfully modified, select, mark and if checked, notify user
        /// </summary>
        private void HasBeenModified()
        {
            //Select and mark in source richtextbox which word has been modififed
            Select();
            Mark();

            //For each modification, increase count and show in form how many replacements have been performed
            myReplacementCount++;
            MainForm.Form.SetReplacementCount(myReplacementCount);

            //If notify user has been selected, block thread until notified from user
            if (myNotifyUser)
            {
                lock (myLockNotify)
                {
                    Monitor.Wait(myLockNotify);
                }
            }
        }

        private void Select()
        {
            mySourceTextBox.InvokeIfRequired(() => 
            {
                mySourceTextBox.SelectionStart = myStartPosition;
                mySourceTextBox.SelectionLength = myFindString.Length;
            });       
        }

        private void Mark()
        {
            mySourceTextBox.InvokeIfRequired(() => 
            {
                mySourceTextBox.SelectionBackColor = Color.Green;
                mySourceTextBox.SelectionColor = Color.White;
            });
        }

        public void Notify()
        {
            lock (myLockNotify)
            {
                //Notify modifier which is waiting, that it can proceed
                Monitor.Pulse(myLockNotify);
            }
        }
    }
}
