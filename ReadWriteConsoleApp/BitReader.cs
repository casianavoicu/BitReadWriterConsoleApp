using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteConsoleApp
{
    public class BitReader :IDisposable
    {
        private byte bufferReader;
        private readonly BinaryReader inputFileContent;
        
        private int numberOfBitsRead;
        

        public BitReader(string filePath)
        {
            bufferReader = 8;
            numberOfBitsRead =0;
            inputFileContent = new BinaryReader(File.OpenRead(filePath), Encoding.UTF8);
            inputFileContent.BaseStream.Position = 0;

        }

        public bool IsEmptyBuffer()
        {

            return numberOfBitsRead == 0;

        }
        private UInt32 ReadBit()
        {
            uint result=0 ;
            if (IsEmptyBuffer())
            {

                    
                    bufferReader = Convert.ToByte(inputFileContent.ReadByte());
                    numberOfBitsRead = 8;
               
            }
          
                numberOfBitsRead--;
         
            result = Convert.ToUInt32(bufferReader % 2);
            bufferReader >>= 1;
           

            return result;
        }
        public UInt32 ReadNBits(int no)
        {
            uint result = 0;

           
            for (var i = no - 1; i >= 0; i--)
            {

               // result <<= 1;
                result = ReadBit() | result;
               
            }
           
            return result;

        }
        public void Dispose()
        {
            inputFileContent.Dispose();
        }

    }
}
