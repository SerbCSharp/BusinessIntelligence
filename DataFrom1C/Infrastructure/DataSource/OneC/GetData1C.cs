using DataFrom1C.Application.Interfaces;
using DataFrom1C.Domain;
using DataFrom1C.Infrastructure.DataSource.Models.ContractCounterparties;
using DataFrom1C.Infrastructure.DataSource.Models.Counterparty;
using DataFrom1C.Infrastructure.DataSource.Models.CreditToCurrentAccount;
using DataFrom1C.Infrastructure.DataSource.Models.DebitToCurrentAccount;
using DataFrom1C.Infrastructure.DataSource.Models.ImplementationConstructionWorks;
using DataFrom1C.Infrastructure.DataSource.Models.ReceiptGoodsServices;
using DataFrom1C.Infrastructure.DataSource.Models.ReceiptProcessing;
using DataFrom1C.Infrastructure.DataSource.Models.SaleGoodsServices;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;

namespace DataFrom1C.Infrastructure.DataSource.OneC
{
    public class GetData1C : IGetData
    {
        private readonly HttpClient httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Base1CConfiguration _base1CConfiguration;
        private readonly string ApiUrl;

        public GetData1C(IOptions<Base1CConfiguration> base1CConfiguration, IHttpClientFactory httpClientFactory)
        {
            _base1CConfiguration = base1CConfiguration.Value;
            var username = _base1CConfiguration.Username;
            var password = _base1CConfiguration.Password;
            ApiUrl = _base1CConfiguration.ApiUrl;
            var credentials = $"{username}:{password}";
            var byteArray = Encoding.ASCII.GetBytes(credentials);
            var base64Credentials = Convert.ToBase64String(byteArray);
            _httpClientFactory = httpClientFactory;
            httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Credentials);
        }

        public async Task<IEnumerable<PurchasePayment>> PurchasePaymentAsync() // Списание с расчетного счета
        {
            var debitToCurrentAccountUrl = ApiUrl + "Document_СписаниеСРасчетногоСчета?$format=json"
                + "&$select=Ref_Key,Date,СуммаДокумента,ДоговорКонтрагента_Key,НазначениеПлатежа"
                + "&$filter=(DeletionMark eq false) and (Posted eq true)";
            using HttpResponseMessage debitToCurrentAccountResponse = await httpClient.GetAsync(debitToCurrentAccountUrl);
            var debitToCurrentAccount = await debitToCurrentAccountResponse.Content.ReadFromJsonAsync<DebitToCurrentAccount>();
            return debitToCurrentAccount.Value.Select(x => new PurchasePayment
            {
                DocumentId = x.DocumentId,
                Date = x.Date,
                Amount = x.Amount,
                ContractId = x.ContractId,
                PaymentPurpose = x.PaymentPurpose
            });
        }

        public async Task<IEnumerable<SalesPayment>> SalesPaymentAsync() // Поступление на расчетный счет
        {
            var creditToCurrentAccountUrl = ApiUrl + "Document_ПоступлениеНаРасчетныйСчет?$format=json"
                + "&$select=Ref_Key,Date,СуммаДокумента,ДоговорКонтрагента_Key,НазначениеПлатежа"
                + "&$filter=DeletionMark eq false and Posted eq true";
            using HttpResponseMessage creditToCurrentAccountResponse = await httpClient.GetAsync(creditToCurrentAccountUrl);
            var creditToCurrentAccount = await creditToCurrentAccountResponse.Content.ReadFromJsonAsync<CreditToCurrentAccount>();
            return creditToCurrentAccount.Value.Select(x => new SalesPayment
            {
                DocumentId = x.DocumentId,
                Date = x.Date,
                Amount = x.Amount,
                ContractId = x.ContractId,
                PaymentPurpose = x.PaymentPurpose
            });
        }

        public async Task<IEnumerable<PurchaseInvoice>> PurchaseInvoiceAsync()
        {
            var receiptGoodsServicesUrl = ApiUrl + "Document_ПоступлениеТоваровУслуг?$format=json"
                + "&$select=Ref_Key,Date,СуммаДокумента,ДоговорКонтрагента_Key,Склад_Key"
                + "&$filter=DeletionMark eq false and Posted eq true";
            using HttpResponseMessage receiptGoodsServicesResponse = await httpClient.GetAsync(receiptGoodsServicesUrl);
            var receiptGoodsServices = await receiptGoodsServicesResponse.Content.ReadFromJsonAsync<ReceiptGoodsServices>();
            var purchaseGoodsServices = receiptGoodsServices.Value.Select(x => new PurchaseInvoice
            {
                DocumentId = x.DocumentId,
                Date = x.Date,
                Amount = x.Amount,
                ContractId = x.ContractId,
                WarehouseId = x.WarehouseId
            });

            var receiptProcessingUrl = ApiUrl + "Document_ПоступлениеИзПереработки?$format=json"
                + "&$select=Ref_Key,Date,СуммаДокумента,ДоговорКонтрагента_Key"
                + "&$filter=DeletionMark eq false and Posted eq true";
            using HttpResponseMessage receiptProcessingResponse = await httpClient.GetAsync(receiptProcessingUrl);
            var receiptProcessing = await receiptProcessingResponse.Content.ReadFromJsonAsync<ReceiptProcessing>();
            var purchaseProcessing = receiptProcessing.Value.Select(x => new PurchaseInvoice
            {
                DocumentId = x.DocumentId,
                Date = x.Date,
                Amount = x.Amount,
                ContractId = x.ContractId
            });

            return purchaseGoodsServices.Concat(purchaseProcessing);
        }

        public async Task<IEnumerable<SalesInvoice>> SalesInvoiceAsync()
        {
            var saleGoodsServicesUrl = ApiUrl + "Document_РеализацияТоваровУслуг?$format=json"
                + "&$select=Ref_Key,Date,СуммаДокумента,ДоговорКонтрагента_Key,Склад_Key"
                + "&$filter=DeletionMark eq false and Posted eq true";
            using HttpResponseMessage saleGoodsServicesResponse = await httpClient.GetAsync(saleGoodsServicesUrl);
            var saleGoodsServices = await saleGoodsServicesResponse.Content.ReadFromJsonAsync<SaleGoodsServices>();
            var SalesGoodsServices = saleGoodsServices.Value.Select(x => new SalesInvoice
            {
                DocumentId = x.DocumentId,
                Date = x.Date,
                Amount = x.Amount,
                ContractId = x.ContractId,
                WarehouseId = x.WarehouseId
            });

            var implementationConstructionWorksUrl = ApiUrl + "Document_ИмпРеализацияСтроительныхРаботУслуг?$format=json"
                + "&$select=Ref_Key,Date,СуммаДокумента,ДоговорКонтрагента_Key"
                + "&$filter=DeletionMark eq false and Posted eq true";
            using HttpResponseMessage implementationConstructionWorksResponse = await httpClient.GetAsync(implementationConstructionWorksUrl);
            var implementationConstructionWorks = await implementationConstructionWorksResponse.Content.ReadFromJsonAsync<ImplementationConstructionWorks>();
            var SalesImplementationConstructionWorks = implementationConstructionWorks.Value.Select(x => new SalesInvoice
            {
                DocumentId = x.DocumentId,
                Date = x.Date,
                Amount = x.Amount,
                ContractId = x.ContractId
            });

            return SalesGoodsServices.Concat(SalesImplementationConstructionWorks);
        }

        public async Task<IEnumerable<PurchaseGoodAndService>> PurchaseGoodAndServiceAsync()
        {
            var receiptGoodsServicesUrl = ApiUrl + "Document_ПоступлениеТоваровУслуг?$format=json"
                + "&$select=Товары,Услуги"
                + "&$filter=DeletionMark eq false and Posted eq true";
            using HttpResponseMessage receiptGoodsServicesResponse = await httpClient.GetAsync(receiptGoodsServicesUrl);
            var receiptGoodsServices = await receiptGoodsServicesResponse.Content.ReadFromJsonAsync<ReceiptGoodsServices>();

            var purchaseGood = receiptGoodsServices.Value.Where(x => x.Goods.Length > 0).SelectMany(y => y.Goods)
                .Select(z => new PurchaseGoodAndService
                {
                    DocumentId = z.DocumentId,
                    NomenclatureId = z.NomenclatureId,
                    UnitsOfMeasurementId = z.UnitsOfMeasurementId,
                    Quantity = z.Quantity,
                    Price = z.Price,
                    Amount = z.Amount,
                });

            var purchaseServices = receiptGoodsServices.Value.Where(x => x.Services.Length > 0).SelectMany(y => y.Services)
                .Select(z => new PurchaseGoodAndService
                {
                    DocumentId = z.DocumentId,
                    NomenclatureId = z.NomenclatureId,
                    UnitsOfMeasurementId = z.UnitsOfMeasurementId,
                    Quantity = z.Quantity,
                    Price = z.Price,
                    Amount = z.Amount,
                });

            return purchaseGood.Concat(purchaseServices);
        }

        public async Task<IEnumerable<Contract>> ContractAsync() // Договоры контрагентов
        {
            var contractCounterpartiesUrl = ApiUrl + "Catalog_ДоговорыКонтрагентов?$format=json"
                + "&$select=Ref_Key,Номер,Description,Дата,Сумма,Owner_Key"
                + "&$filter=DeletionMark eq false";
            using HttpResponseMessage contractCounterpartiesResponse = await httpClient.GetAsync(contractCounterpartiesUrl);
            var contractCounterparties = await contractCounterpartiesResponse.Content.ReadFromJsonAsync<ContractCounterparties>();
            return contractCounterparties.Value.Select(x => new Contract
            {
                ContractId = x.ContractId,
                Date = x.Date ?? new DateTime(),
                Amount = x.Amount ?? 0,
                Number = x.Number,
                Name = x.Name,
                ContractorId = x.ContractorId
            });
        }

        public async Task<IEnumerable<Contractor>> ContractorAsync() // Контрагенты
        {
            var counterpartyUrl = ApiUrl + "Catalog_Контрагенты?$format=json"
                + "&$select=Ref_Key,Description";
            using HttpResponseMessage counterpartyResponse = await httpClient.GetAsync(counterpartyUrl);
            var counterparty = await counterpartyResponse.Content.ReadFromJsonAsync<Counterparty>();
            return counterparty.Value.Select(x => new Contractor
            {
                ContractorId = x.Ref_Key,
                Name = x.Description
            });
        }

        public async Task<IEnumerable<SalesGoodAndService>> SalesGoodAndServiceAsync()
        {
            var saleGoodsServicesUrl = ApiUrl + "Document_РеализацияТоваровУслуг?$format=json"
                + "&$select=Товары,Услуги"
                + "&$filter=DeletionMark eq false and Posted eq true";
            using HttpResponseMessage saleGoodsServicesResponse = await httpClient.GetAsync(saleGoodsServicesUrl);
            var saleGoodsServices = await saleGoodsServicesResponse.Content.ReadFromJsonAsync<ReceiptGoodsServices>();

            var salesGood = saleGoodsServices.Value.Where(x => x.Goods.Length > 0).SelectMany(y => y.Goods)
                .Select(z => new SalesGoodAndService
                {
                    DocumentId = z.DocumentId,
                    NomenclatureId = z.NomenclatureId,
                    UnitsOfMeasurementId = z.UnitsOfMeasurementId,
                    Quantity = z.Quantity,
                    Price = z.Price,
                    Amount = z.Amount,
                });

            var salesServices = saleGoodsServices.Value.Where(x => x.Services.Length > 0).SelectMany(y => y.Services)
                .Select(z => new SalesGoodAndService
                {
                    DocumentId = z.DocumentId,
                    NomenclatureId = z.NomenclatureId,
                    UnitsOfMeasurementId = z.UnitsOfMeasurementId,
                    Quantity = z.Quantity,
                    Price = z.Price,
                    Amount = z.Amount,
                });

            return salesGood.Concat(salesServices);
        }
    }
}
