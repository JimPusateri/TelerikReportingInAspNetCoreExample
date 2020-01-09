using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Telerik.Reporting.Cache.File;
using Telerik.Reporting.Services;
using Telerik.Reporting.Services.AspNetCore;

namespace TelerikReportingInAspNetCoreExample.Controllers
{
    [Route("api/reports")]
    public class ReportsController : ReportsControllerBase
    {
        readonly string reportsPath = string.Empty;

        public ReportsController(ConfigurationService configSvc)
        {
            reportsPath = Path.Combine(configSvc.Environment.WebRootPath, "Reports");

            ReportServiceConfiguration = new ReportServiceConfiguration
            {
                ReportingEngineConfiguration = configSvc.Configuration,
                HostAppId = "AspNetCoreReportDemo",
                Storage = new FileStorage(),
                ReportResolver = new ReportTypeResolver()
                                    .AddFallbackResolver(new ReportFileResolver(this.reportsPath)),
            };
        }

        [HttpGet("reportlist")]
        public IEnumerable<string> GetReports()
        {
            return Directory
                .GetFiles(this.reportsPath)
                .Select(path =>
                    Path.GetFileName(path));
        }
    }
}