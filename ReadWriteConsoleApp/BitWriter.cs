using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ReadWriteConsoleApp
{
    public class BitWriter : IDisposable
    {
        private readonly BinaryWriter outputFileContent;
        private byte bufferWriter;
        private int numberOfBitsWritten;

        public BitWriter(string filePath)
        {
            numberOfBitsWritten = 0;
            bufferWriter = 0;
            outputFileContent = new BinaryWriter(new FileStream(filePath,FileMode.Create));

        }

        private bool IsBufferFull()
        {
            return numberOfBitsWritten == 8;
        }

        private void WriteBit(UInt32 value)
        {

            bufferWriter <<= 1;
            bufferWriter |= (byte)(value % 2);
            numberOfBitsWritten++;
            if (IsBufferFull())
            {
                numberOfBitsWritten = 0;
                outputFileContent.Write(bufferWriter);
                bufferWriter =0;

            }
           

        }

        public void WriteNBits( int nr, UInt32 value)
        {
            if (nr > 32)
            {
                throw new Exception("Numarul de biti care trebuie scris depaseste 32");
            }
            for (int i = nr - 1; i >= 0; i--)
            {
                WriteBit(value >>i);
            }
        }
        public void Dispose()
        {
            outputFileContent.Dispose();
        }
    }
}
