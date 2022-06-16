using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "다음은 한57855글과 duddjdhk ";
            Console.WriteLine("Memory mapped file server started");
            using (var file = MemoryMappedFile.CreateNew("myFile", int.MaxValue))
            {
                byte[] StrByte = Encoding.UTF8.GetBytes(str);
                /*var bytes = new byte[24];
                for (var i = 0; i < bytes.Length; i++)
                    bytes[i] = (byte)(65 + i);*/
                using (var writer = file.CreateViewAccessor(0, StrByte.Length))
                {
                    writer.WriteArray<byte>(0, StrByte, 0, StrByte.Length);
                }
                Console.WriteLine("Run memory mapped file reader before exit");
                Console.WriteLine("Press any key to exit ...");
                Console.ReadLine();
            }
        }
    }
}
