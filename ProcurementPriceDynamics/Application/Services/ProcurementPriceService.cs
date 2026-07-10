using ProcurementPriceDynamics.Application.Interfaces;
using ProcurementPriceDynamics.Domain;

namespace ProcurementPriceDynamics.Application.Services
{
    public class ProcurementPriceService(IGetData getData)
    {
        private readonly IGetData _getData = getData;

        public async Task<IEnumerable<ProcurementPrice>> ProcurementPriceAsync()
        {
            return await _getData.ProcurementPriceAsync();
        }
    }
}
