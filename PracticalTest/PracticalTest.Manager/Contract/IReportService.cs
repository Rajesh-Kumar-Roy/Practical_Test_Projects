using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Manager.Contract
{
    public interface IReportService
    {
        Task<byte[]> GenereateReprotAsync(string reportName, string ReportType, string rdlcPath, int userId);
    }
}
