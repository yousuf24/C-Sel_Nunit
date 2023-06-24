using Sel_CSharp002.DnD;
using System.Collections.Generic;
using static Sel_CSharp002.Models.BillingData;

namespace Sel_CSharp002.TestData.AzureBlob.Billing
{
    public class BillingDataRepository
    {
        static BillingDataRepository instance = null;
        AppSettingsClient applicationSettings;
        private BlobRepository blobRepository;
        public static BillingDataRepository GetInstance
        {
            get
                {
                if (instance == null)
                { instance = new BillingDataRepository(); }
                return instance;
            }
            
    }
        public BillingDataRepository()
        {
            applicationSettings = AppSettingsClientConfig.GetClient;
            string fullProductBlobPath = AppSettingsClientConfig.AppName;
            blobRepository = new BlobRepository(fullProductBlobPath,applicationSettings); 
        }
        public List<CaseAndQuoteScreen> GetCaseAndQuoteDetails => blobRepository.GetData<List<CaseAndQuoteScreen>>(BlobVariables.BillingDataFiles.blobBillingDataFile,BlobVariables.CaseAndQuoteCreationSheet);
        public List<ProductSelectionScreen> GetProducts => blobRepository.GetData<List<ProductSelectionScreen>>(BlobVariables.BillingDataFiles.blobBillingDataFile, BlobVariables.ProductSelectionScreen);
        public List<ConfigureProductsPage> ConfigureProducts => blobRepository.GetData<List<ConfigureProductsPage>>(BlobVariables.BillingDataFiles.blobBillingDataFile, BlobVariables.ConfigureProductsPage);
        public List<AccountCreditCenter> GetCredits => blobRepository.GetData<List<AccountCreditCenter>>(BlobVariables.BillingDataFiles.blobBillingDataFile, BlobVariables.AccountCreditCenter);
        public List<InvoicePaymentScreen> GetInvPaymentDetails => blobRepository.GetData<List<InvoicePaymentScreen>>(BlobVariables.BillingDataFiles.blobBillingDataFile, BlobVariables.InvoicePaymentScreen);
        public List<PaymentPage> GetPayment => blobRepository.GetData<List<PaymentPage>>(BlobVariables.BillingDataFiles.blobBillingDataFile, BlobVariables.PaymentPage);
        public List<CreateCustomerAdjustment> GetCustAdjustments => blobRepository.GetData<List<CreateCustomerAdjustment>>(BlobVariables.BillingDataFiles.blobBillingDataFile, BlobVariables.CreateCustomerAdjustment);
        public List<InvoicePage> GetInvoiceDetails => blobRepository.GetData<List<InvoicePage>>(BlobVariables.BillingDataFiles.blobBillingDataFile, BlobVariables.InvoicePage);
        public List<EntityPage> GetEntityDetails => blobRepository.GetData<List<EntityPage>>(BlobVariables.BillingDataFiles.blobBillingDataFile, BlobVariables.EntityPage);
        public List<QuoteLineDetailsPage> GetQLDetails => blobRepository.GetData<List<QuoteLineDetailsPage>>(BlobVariables.BillingDataFiles.blobBillingDataFile, BlobVariables.QuoteLineDetailsPage);
        public List<Engage> GetEngageDetails => blobRepository.GetData<List<Engage>>(BlobVariables.BillingDataFiles.blobBillingDataFile, BlobVariables.Engage);

        public List<NewPartnerAndAffiliate> GetNewPartnerAndAffiliate => blobRepository.GetData<List<NewPartnerAndAffiliate>>(BlobVariables.BillingDataFiles.blobBillingDataFile, BlobVariables.NewPartnerAndAffiliatte);
    }  
}
