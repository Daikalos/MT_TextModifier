using System;
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
        private int myNbrOfStrings;

        private List<string> myReadList;

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
                if (!string.IsNullOrEmpty(wordRead))
                {
                    myReadList.Add(wordRead);
                    i++;
                }
            }
            MainForm.Form.SetDestinationText();
        }
    }
}
