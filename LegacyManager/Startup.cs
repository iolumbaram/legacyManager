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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void Configure()
        {
            //interfaces for connection builders
            var pathBase = Configuration; // Configuration["PATH_BASE"];

        }
    }
}
