using System.Collections.Generic;

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
                //Go through each word in source and go to next word if having succesfully
                //assigned current word into string buffer in bounded buffer
                if (mySharedBuffer.Write(myTextToWrite[i]))
                {
                    i++;
                }
            }
        }
    }
}
