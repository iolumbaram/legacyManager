using LegacyManager.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyManager
{
    public class Startup
    {
        public Startup()
        {
            //Configuration = configuration;
            Console.WriteLine("hey yo 123");
        }
        public IConfiguration Configuration { get; }

        public void Configure()
        {
            //interfaces for connection builders
            var pathBase = Configuration; // Configuration["PATH_BASE"];
            Console.WriteLine("hey yo");
        }
    }
}
