using Microsoft.AspNetCore.Mvc;
using ProcurementPriceDynamics.Application.Services;
using ProcurementPriceDynamics.Presentation.ReportsToExcel;

namespace ProcurementPriceDynamics.Presentation.Controllers
{

    [ApiController]
    public class ProcurementPriceController(ProcurementPriceService procurementPriceService, 
        ExportingReportsToExcel exportingReportsToExcel) : ControllerBase
    {
        private readonly ProcurementPriceService _procurementPriceService = procurementPriceService;
        private readonly ExportingReportsToExcel _exportingReportsToExcel = exportingReportsToExcel;

        [HttpGet("ProcurementPriceDynamics")]
        public async Task<IActionResult> ProcurementPriceDynamics()
        {
            var procurementPrice = await _procurementPriceService.ProcurementPriceAsync();
            var fileBytes = _exportingReportsToExcel.Browse(procurementPrice);
            string fileName = "Browse.xlsx";
            string contentType = "application/octet-stream";

            return File(fileBytes, contentType, fileName);
        }
    }
}
