using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading_04
{
    class Modifier : ThreadObject
    {
        private BoundedBuffer mySharedBuffer;
        private int myNbrOfStrings;

        public Modifier(BoundedBuffer sharedBuffer, int nbrOfStrings)
        {
            this.mySharedBuffer = sharedBuffer;
            this.myNbrOfStrings = nbrOfStrings;

            StartThread();
        }

        public override void Update()
        {
            for (int i = 0; i < myNbrOfStrings;)
            {
                if (mySharedBuffer.Modify())
                {
                    i++;
                }
            }   
        }
    }
}
