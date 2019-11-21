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
        private byte bufferReader;
        private FileStream inputFileContent;
        private int numberOfBitsRead;
        

        public BitReader(string filePath)
        {
         
            numberOfBitsRead = 0;
            inputFileContent = new FileStream(filePath,FileMode.Open);
          

        }

        public bool IsEmptyBuffer()
        {

            return numberOfBitsRead == 0;

        }
        private int ReadBit()
        {
            
            if (IsEmptyBuffer())
            {
                
                
                    bufferReader = (byte)(inputFileContent.ReadByte());
                    numberOfBitsRead = 8;
               
            }
            int result = 0;

            int shiftare = 8 - numberOfBitsRead;
            result = bufferReader << shiftare;
            result = (result >> 7) & 0x01;
            numberOfBitsRead--;

            return result;
        }
        public int ReadNBits(int no)
        {
            int result = 0;

           
            for (var i = no - 1; i >= 0; i--)
            {

                    int bit;
                    bit = ReadBit() ;
                    bit = bit <<= i;
                    result = result+bit;
            }
           
            return result;

        }
      

    }
}
