using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteConsoleApp
{
    public class BitReader
    {
        private byte BufferReader;
        private BinaryReader fileContent;
        private int NumberOfBitsRead;
        

        public BitReader(string filePath)
        {
            BufferReader = 0;
            NumberOfBitsRead = 0;
            fileContent = new BinaryReader(File.Open(filePath, FileMode.Open), Encoding.UTF8);


        }

        public bool IsEmptyBuffer()
        {
            if (NumberOfBitsRead == 0)
                return true;
            return false;

        }
        private UInt32 ReadBit()
        {
            uint result;
            if (IsEmptyBuffer())
            {
                BufferReader = Convert.ToByte((fileContent.ReadByte()));
                NumberOfBitsRead = 8;

            }
  
            result = Convert.ToUInt32(BufferReader % 2);
            BufferReader <<= 1;
            NumberOfBitsRead--;

            return result;
        }
        public UInt32 ReadNBits(int no)
        {
            UInt32 result = 0;
  

            for (var i = no - 1; i >= 0; i++)
            {

                result = result | ReadBit();
                  
                   
            }
            return result;

        }
        public void Dispose()
        {
            fileContent.Dispose();
        }

    }
}
