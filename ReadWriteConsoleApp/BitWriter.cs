using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteConsoleApp
{
    public class BitWriter
    {
        private byte[] BufferWriter;

        private int NumberofBitsWrite;

        public BitWriter(string filePath)
        {
            NumberofBitsWrite = 0;

        }

        private bool IsBufferFull()
        {
            return NumberofBitsWrite == 8;
        }

        private void WriteBit(int value)
        {
            NumberofBitsWrite++;

            if (NumberofBitsWrite == 8)
            {
                NumberofBitsWrite = 0;
            }

        }

        public void WriteNBits(int nr, int value)
        {
           /* for (...)
            {

            }*/
        }
    }
}
