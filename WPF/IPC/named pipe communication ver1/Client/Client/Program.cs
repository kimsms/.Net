using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            NamedPipeControl.NamedPipeControl Client = new NamedPipeControl.NamedPipeControl("chanos");

            Client.ClientOpen();

            while (true)
            {
                Client.Write(Console.ReadLine());
            }
        }
    }
}
