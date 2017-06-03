using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new CustomerApp();
            app.Run();
        }
    }
}
