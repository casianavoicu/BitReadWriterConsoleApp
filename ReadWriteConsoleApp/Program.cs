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
            string filePathOutput = @"E:\FACULTATE\an 4\Sem1_Mine\output3.txt";
            var fileSize = new FileInfo(filePathInput).Length;
            NBR = 8 * fileSize;
            BitReader bitReader = new BitReader(filePathInput);
            BitWriter bitWriter = new BitWriter(filePathOutput);
            var random = new Random();

            do
            {
                int nb;

                nb = 8;
                if (nb > NBR)
                {
                    nb = (int)NBR;
                }
                int value = bitReader.ReadNBits(nb);

                bitWriter.WriteNBits(nb, value);
                NBR -= nb;
                Console.WriteLine(value);
            } while (NBR > 0);

        }
            
        
    }
}
