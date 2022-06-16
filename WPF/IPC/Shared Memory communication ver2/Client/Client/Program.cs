using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Memory mapped file reader started");
            using (var file = MemoryMappedFile.OpenExisting("myFile"))
            {
                using (var reader = file.CreateViewAccessor(0, 1024))
                {
                    var StrByte = new byte[1024]; 
                    reader.ReadArray<byte>(0, StrByte, 0, StrByte.Length);
                    Console.WriteLine("Reading bytes");
                    //string str = Encoding.Default.GetString(StrByte);
                    string str = System.Text.Encoding.UTF8.GetString(StrByte);
                    Console.WriteLine(str);
                    /*for (var i = 0; i < bytes.Length; i++)
                        Console.Write((char)bytes[i] + " ");*/
                    Console.WriteLine(string.Empty);
                }
            }
            Console.WriteLine("Press any key to exit ...");
            Console.ReadLine();
        }
    }
}
