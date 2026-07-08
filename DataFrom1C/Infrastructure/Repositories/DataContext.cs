using DataFrom1C.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataFrom1C.Infrastructure.Repositories
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<PurchasePayment> PurchasePayments { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<SalesPayment> SalesPayments { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<PurchaseGoodAndService> PurchaseGoodsAndServices { get; set; }
        public DbSet<SalesGoodAndService> SalesGoodsAndServices { get; set; }
    }
}
