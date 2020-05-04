using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multithreading_04
{
    class Writer : ThreadObject
    {
        private BoundedBuffer mySharedBuffer;
        private List<string> myTextToWrite;

        public Writer(BoundedBuffer sharedBuffer, List<string> sourceText)
        {
            this.mySharedBuffer = sharedBuffer;
            this.myTextToWrite = sourceText;

            StartThread();
        }

        public override void Update()
        {
            for (int i = 0; i < myTextToWrite.Count;)
            {
                if (mySharedBuffer.Write(myTextToWrite[i]))
                {
                    i++;
                }
            }
        }
    }
}
