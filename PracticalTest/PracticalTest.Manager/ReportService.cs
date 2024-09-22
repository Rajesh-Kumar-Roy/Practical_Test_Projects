using AspNetCore.Reporting;
using PracticalTest.Manager.Contract;
using PracticalTest.Manager.EntityDtos;
using PracticalTest.Repository.Contract;
using System.Reflection;
using System.Text;

namespace PracticalTest.Manager
{
    public class ReportService : IReportService
    {
        private ICustomerRepository _customerRepository;
        public ReportService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<byte[]> GenereateReprotAsync(string reportName, string reportType, string rdlcPath, int userId)
        {
            //string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("", string.Empty);
            //string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, reportName);

            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("PracticalTest.dll", string.Empty);
            string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, reportName);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");

            LocalReport report = new LocalReport(rdlcPath);

          
            var invoiceData = await _customerRepository.GetInvoiceDateByUserId(userId);

            var objValue = invoiceData.FirstOrDefault();
            var sumOfTotalPrice = invoiceData.Sum(c => c.TotalPrice);

            report.AddDataSource("DataSet1", invoiceData);



            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (objValue != null)
            {
                parameters.Add("PhoneParam", objValue.Phone.ToString());
                parameters.Add("DateParam", objValue.SaleDate.ToString("dd-MM-yyyy"));
                parameters.Add("EmailParam", objValue.Email.ToString());
                parameters.Add("AddressParam", objValue.Address.ToString());
                parameters.Add("customerNamePram", objValue.CustomerName.ToString());
                parameters.Add("SaleIdParam", objValue.Id.ToString());
                parameters.Add("SumTotalPriceParam", sumOfTotalPrice.ToString());
            }
            var result = report.Execute(GetRenderType(reportType), 1, parameters,"");

            return result.MainStream;
        }

        private RenderType GetRenderType(string reportType)
        {
            var renderType = RenderType.Pdf;
            switch (reportType.ToUpper())
            {
                default:
                case "PDF":
                    renderType = RenderType.Pdf;
                    break;
                case "XLS":
                    renderType = RenderType.Excel;
                    break;
                case "WORD":
                    renderType = RenderType.Word;
                    break;
            }
            return renderType;
        }
    }
}
