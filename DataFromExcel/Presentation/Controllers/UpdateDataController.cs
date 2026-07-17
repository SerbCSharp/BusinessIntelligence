using DataFromExcel.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataFromExcel.Presentation.Controllers
{
    [ApiController]
    public class UpdateDataController(UpdateDataService updateDataService) : ControllerBase
    {
        private readonly UpdateDataService _updateDataService = updateDataService;

        [HttpGet("Update")]
        public async Task<IActionResult> UpdateAsync()
        {
            await _updateDataService.ObjectOfSaleInPurchasePaymentAsync();
            return NoContent();
        }
    }
}
