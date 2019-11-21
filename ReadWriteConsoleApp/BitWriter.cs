using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ReadWriteConsoleApp
{
    public class BitWriter 
    {
        private FileStream outputFileContent;
        private byte bufferWriter;
        private int numberOfBitsWritten;

        public BitWriter(string filePath)
        {
            numberOfBitsWritten = 0;
            
            outputFileContent = new FileStream(filePath,FileMode.Create,FileAccess.Write);

        }

        private bool IsBufferFull()
        {
            return numberOfBitsWritten == 8;
        }

        private void WriteBit(int value)
        {

          
            bufferWriter = (byte)((int)bufferWriter +(value<<(7-numberOfBitsWritten)));
            numberOfBitsWritten++;
            if (IsBufferFull())
            {
                numberOfBitsWritten = 0;
                outputFileContent.WriteByte(bufferWriter);
                bufferWriter = 0;

            }
          
               
            
        }

        public void WriteNBits( int nr, int value)
        {
            int bit;
            for (int i = nr - 1; i >= 0; i--)
            {
                bit = value << (nr - 1 - i);
                bit = bit >> (nr - 1);
                bit = bit & 0x01;
                WriteBit(bit);


            }
        }
       
    }
}
