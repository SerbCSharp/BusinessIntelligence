using DataManagement.Application.Services;
using DataManagement.Presentation.ReportsToExcel;
using Microsoft.AspNetCore.Mvc;

namespace DataManagement.Presentation.Controllers
{
    [ApiController]
    public class DataManagementControllers(DataManagementService dataManagementService,
        ExportingReportsToExcel exportingReportsToExcel) : Controller
    {
        private readonly DataManagementService _dataManagementService = dataManagementService;
        private readonly ExportingReportsToExcel _exportingReportsToExcel = exportingReportsToExcel;

        [HttpGet("AddObjectOfSaleInPurchasePaymentAsync")]
        public async Task<IActionResult> AddObjectOfSaleInPurchasePaymentAsync()
        {
            var procurementPrice = await _dataManagementService.AddObjectOfSaleInPurchasePaymentAsync();
            var fileBytes = _exportingReportsToExcel.Browse(procurementPrice);
            string fileName = "Browse.xlsx";
            string contentType = "application/octet-stream";

            return File(fileBytes, contentType, fileName);
        }
    }
}
