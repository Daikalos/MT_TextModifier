﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading_04
{
    class Reader : ThreadObject
    {
        private BoundedBuffer mySharedBuffer;
        private int myNbrOfStrings; //How many words to go through in source

        private readonly List<string> myReadList; //Output list used to generate destination text

        public List<string> GetText => myReadList;

        public Reader(BoundedBuffer sharedBuffer, int nbrOfStrings)
        {
            this.mySharedBuffer = sharedBuffer;
            this.myNbrOfStrings = nbrOfStrings;

            myReadList = new List<string>();

            StartThread();
        }

        public override void Update()
        {
            for (int i = 0; i < myNbrOfStrings;)
            {
                string wordRead = mySharedBuffer.Read();
                if (wordRead != null)
                {
                    //After having successfully read word in string buffer, add string to readlist
                    myReadList.Add(wordRead);
                    i++;
                }
            }
            MainForm.Form.SetDestinationText();
        }
    }
}
