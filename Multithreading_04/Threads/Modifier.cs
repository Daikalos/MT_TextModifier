using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading_04
{
    class Modifier : ThreadObject
    {
        private BoundedBuffer mySharedBuffer;

        public Modifier(BoundedBuffer sharedBuffer)
        {
            this.mySharedBuffer = sharedBuffer;
        }

        public override void Update()
        {

        }
    }
}
