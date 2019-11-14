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
            string filePath = @"E:\FACULTATE\an 4\Sem1_Mine\indrumarPDS.pdf";
            BitReader bitReader = new BitReader(filePath);
            FileInfo f = new FileInfo(filePath);
            long fileSize = f.Length; ;
            NBR =8 * fileSize ;
                do
                {
                    int nb;

                    nb = 4;
                    if (nb > NBR)
                    {
                        nb = (int)NBR;
                    }
                    uint value = bitReader.ReadNBits(nb);
                    // BitWriter.WriteNBits(nb, value);
                    NBR -= nb;
                } while (NBR > 0);
         
            Console.WriteLine(NBR);
        }
    }
}
