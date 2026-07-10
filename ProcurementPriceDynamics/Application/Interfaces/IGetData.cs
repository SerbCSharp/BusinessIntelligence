using ProcurementPriceDynamics.Domain;

namespace ProcurementPriceDynamics.Application.Interfaces
{
    public interface IGetData
    {
        Task<IEnumerable<ProcurementPrice>> ProcurementPriceAsync();
    }
}
