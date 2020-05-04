using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading_04
{
    class Writer : ThreadObject
    {
        private BoundedBuffer mySharedBuffer;

        public Writer(BoundedBuffer sharedBuffer)
        {
            this.mySharedBuffer = sharedBuffer;
        }

        public override void Update()
        {

        }
    }
}
