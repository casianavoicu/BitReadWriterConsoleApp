using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReadWriteConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Random rand = new Random();
            long NBR = 0;
            string filePathInput = @"E:\FACULTATE\an 4\Sem1_Mine\input.txt";
            string filePathOutput = @"E:\FACULTATE\an 4\Sem1_Mine\output1.txt";
            var fileSize = new FileInfo(filePathInput).Length * 8;
            NBR =8 * fileSize ;
            var random = new Random();
            using (var bitReader = new BitReader(filePathInput))
            {
                using (var bitWriter = new BitWriter(filePathOutput))
                 {
              
                do
                    {
                    int nb;

                    nb = rand.Next(0,32);
                    if (nb > NBR)
                    {
                        nb = (int)NBR;
                    }                   
                    uint value = bitReader.ReadNBits(nb);

                    bitWriter.WriteNBits((int)nb,value);
                    fileSize -= nb;
                    Console.WriteLine(value);
                } while (NBR > 0 );
            }
            }
            
            
        }
    }
}
