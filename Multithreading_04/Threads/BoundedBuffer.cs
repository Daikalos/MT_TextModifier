using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        private Status[] myBuffer;
        private int mySize;

        private object myLock = new object();

        public BoundedBuffer(int size)
        {
            this.mySize = size;

            myBuffer = new Status[size];
            Array.ForEach(myBuffer, s => s = Status.Empty);
        }

        private void WritePos()
        {
            try
            {
                Monitor.Wait(myLock);


            }
            finally
            {
                Monitor.Pulse(myLock);
            }
        }

        private void ReadPos()
        {
            try
            {
                Monitor.Wait(myLock);


            }
            finally
            {
                Monitor.Pulse(myLock);
            }
        }
        
        private void FindPos()
        {
            try
            {
                Monitor.Wait(myLock);


            }
            finally
            {
                Monitor.Pulse(myLockObject);
            }
        }
    }
}
