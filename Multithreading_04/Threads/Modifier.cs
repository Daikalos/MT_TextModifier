namespace Multithreading_04
{
    class Modifier : ThreadObject
    {
        private BoundedBuffer mySharedBuffer;
        private int myStringsCount; //How many words to go through in source

        public Modifier(BoundedBuffer sharedBuffer, int stringsCount)
        {
            this.mySharedBuffer = sharedBuffer;
            this.myStringsCount = stringsCount;

            StartThread();
        }

        public override void Update()
        {
            for (int i = 0; i < myStringsCount;)
            {
                if (mySharedBuffer.Modify())
                {
                    i++;
                }
            }   
        }
    }
}
