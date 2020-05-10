using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        private string[] myStringBuffer;
        private Status[] myStatusBuffer;

        private RichTextBox mySourceTextBox;

        private bool myNotifyUser;         //Notify user on each replacement

        private int myBufferSize;
        private int myNbrOfReplacements;
        private int myStartPosition;       //Start position in textbox to use for selecting/marking

        private int myWritePos;            //Writer Pointer
        private int myFindPos;             //Modify Pointer
        private int myReadPos;             //Reader Pointer

        private string myFindString;       //The inputted string for modifier to find and replace
        private string myReplaceString;    //The inputted string to replace the found string

        //Lock access to string buffer to only allow only one thread at a time to access it
        private readonly object myLockStringBuffer = new object();
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

            myNbrOfReplacements = 0;
            myStartPosition = -(myFindString.Length + 1);

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

        public bool Write(string stringToWrite)
        {
            if (myStatusBuffer[myWritePos] == Status.Empty)
            {
                lock (myLockStringBuffer)
                {
                    myStringBuffer[myWritePos] = stringToWrite;
                }

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
                myStartPosition += myStringBuffer[myFindPos].Length + 1;

                if (myStringBuffer[myFindPos] == myFindString)
                {
                    lock (myLockStringBuffer)
                    {
                        myStringBuffer[myFindPos] = myReplaceString;
                    }

                    //Select and mark in source richtextbox where word has been modififed
                    Select();
                    Mark();

                    //For each modification, increase and show in form how many replacements have been performed
                    myNbrOfReplacements++;
                    MainForm.Form.SetNbrOfReplacements(myNbrOfReplacements);

                    if (myNotifyUser)
                    {
                        lock (myLockNotify)
                        {
                            //If notify user has been selected, block thread until notified from user
                            Monitor.Wait(myLockNotify);
                        }
                    }
                }

                myStatusBuffer[myFindPos] = Status.Checked;
                myFindPos = (myFindPos + 1) % myBufferSize;
                
                return true;
            }
            return false;
        }

        public string Read()
        {
            string readString = null;

            if (myStatusBuffer[myReadPos] == Status.Checked)
            {
                lock (myLockStringBuffer)
                {
                    readString = myStringBuffer[myReadPos];
                }

                myStatusBuffer[myReadPos] = Status.Empty;
                myReadPos = (myReadPos + 1) % myBufferSize;
            }
            return readString;
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
                //Notify modify which is waiting, that it can proceed
                Monitor.Pulse(myLockNotify);
            }
        }
    }
}
