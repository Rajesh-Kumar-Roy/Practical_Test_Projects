using AspNetCore.Reporting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticalTest.Manager.Contract;
using System.Net.Mime;

namespace PracticalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IReportService _reportService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ReportController(IReportService reportService, IWebHostEnvironment webHostEnvironment)
        {
            _reportService = reportService;
            _webHostEnvironment = webHostEnvironment;

        }

        [HttpGet("{reportName}/{reportType}/{userId}")]
        public async Task<ActionResult> Get(string reportName, string reportType, int userId)
        {
            string rdlcPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "Report4.rdlc");

            var reportFileByteString = await _reportService.GenereateReprotAsync(reportName, reportType, rdlcPath,userId);

            return File(reportFileByteString, "application/pdf", FileName(reportName, reportType));
            //return File(reportFileByteString, MediaTypeNames.Application.Octet, FileName(reportName,reportType));
        }

        private string FileName(string reportName, string reportType)
        {
            var outputReportName = reportName+".Pdf";
            switch (reportType.ToUpper())
            {
                default:
                case "PDF":
                    outputReportName = reportName + ".Pdf";
                    break;
                case "XLS":
                    outputReportName = reportName + ".xls";
                    break;
                case "WORD":
                    outputReportName = reportName + ".doc";
                    break;
            }
            return outputReportName;
        }
    }
}
