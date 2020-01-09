using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelerikReportingInAspNetCoreExample
{
    public class ConfigurationService
    {
        public IConfiguration Configuration { get; private set; }

        public IWebHostEnvironment Environment { get; private set; }
        public ConfigurationService(IWebHostEnvironment environment, IConfiguration config)
        {
            this.Environment = environment;

            this.Configuration = config;
        }
    }
}
