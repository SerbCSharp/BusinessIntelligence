using DataFrom1C.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataFrom1C.Presentation.Controllers
{

    [ApiController]
    public class UpdateDataController(UpdateDataService updateDataService) : ControllerBase
    {
        private readonly UpdateDataService _updateDataService = updateDataService;

        [HttpGet("Update")]
        public async Task<IActionResult> UpdateAsync()
        {
            await _updateDataService.PurchasePaymentAsync();
            await _updateDataService.PurchaseInvoiceAsync();
            await _updateDataService.SalesInvoiceAsync();
            await _updateDataService.SalesPaymentAsync();
            await _updateDataService.PurchaseGoodAndServiceAsync();
            await _updateDataService.SalesGoodAndServiceAsync();
            await _updateDataService.ContractAsync();
            await _updateDataService.ContractorAsync();
            return NoContent();
        }
    }
}
