using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sel_CSharp002.Models
{
  public  class BillingData
    {
        public class CaseAndQuoteScreen
        {
            [JsonProperty("Contact Name")]
            public string ContactName { get; set; }
            
            [JsonProperty("Account Name")]
            public string AccountName { get; set; }

            [JsonProperty("CustomerReference1")]
            public string CustRef1 { get; set; }
            [JsonProperty("CustomerReference2")]
            public string CustRef2 { get; set; }
        }
        public class ProductSelectionScreen
        {
            [JsonProperty("Product Name")]
            public string ProductName { get; set; }
        }
        public class ConfigureProductsPage
        {
            [JsonProperty("EntityName")]
            public string EntityName { get; set; }

        }
        public class AccountCreditCenter
        {
            [JsonProperty("CreditAmount")]
            public string CredtAmt { get; set; }

        }
        public class InvoicePaymentScreen
        {
            [JsonProperty("First Name")]
            public string Fname { get; set; }
            [JsonProperty("Last Name")]
            public string Lname { get; set; }
            [JsonProperty("Email")]
            public string EmailID { get; set; }
            [JsonProperty("Street")]
            public string Street1 { get; set; }
            [JsonProperty("City")]
            public string City { get; set; }
            [JsonProperty("State")]
            public string State { get; set; }
            [JsonProperty("Zip")]
            public string Zip { get; set; }
            [JsonProperty("NameOnCard")]
            public string NameOnCard { get; set; }
            [JsonProperty("expMonth")]
            public string ExpMonth { get; set; }
            [JsonProperty("expYear")]
            public string Expyear { get; set; }
            [JsonProperty("CVV")]
            public string CVV { get; set; }
            [JsonProperty("Amount")]
            public string Amt { get; set; }
            [JsonProperty("PartialAmount")]
            public string PartialAmt { get; set; }


        }
        public class PaymentPage
        {
            [JsonProperty("ExistingInvoice")]
            public string ExistingInvoice { get; set; }
        }
        public class CreateCustomerAdjustment
        {
            [JsonProperty("AccountName")]
            public string AccountName { get; set; }
            [JsonProperty("AdjustmentAmount")]
            public string AdjustmentAmount { get; set; }
        }
        public class InvoicePage
        {
            [JsonProperty("BillToContact")]
            public string BillToContact { get; set; }
            [JsonProperty("CustomerReference1")]
            public string CustomerReference1 { get; set; }
            [JsonProperty("CustomerReference2")]
            public string CustomerReference2 { get; set; }

        }
        public class EntityPage
        {
            
            [JsonProperty("EntityReference1")]
            public string EntityReference1 { get; set; }
            [JsonProperty("EntityReference2")]
            public string EntityReference2 { get; set; }

        }
        public class QuoteLineDetailsPage
        {

            [JsonProperty("UnitName")]
            public string UnitName { get; set; }
            [JsonProperty("Entity")]
            public string Entity { get; set; }
            [JsonProperty("Affiliation")]
            public string Affiliation { get; set; }

        }
        public class NewPartnerAndAffiliate
        {

            [JsonProperty("PartnerName")]
            public string PartnerName { get; set; }
            [JsonProperty("NRAINumber")]
            public string NRAINumber { get; set; }
            [JsonProperty("RelatedAffiliateAccount")]
            public string RelatedAffiliateAccount { get; set; }

        }
        public class Engage
        {

            [JsonProperty("InvoiceNumber")]
            public string InvoiceNumber { get; set; }
            [JsonProperty("InvoiceAmount")]
            public string InvoiceAmount { get; set; }
            [JsonProperty("OrderNumber")]
            public string OrderNumber { get; set; }
            [JsonProperty("IncorrectOrderNo")]
            public string IncorrectOrderNo { get; set; }
            [JsonProperty("CustomerNumber")]
            public string CustomerNumber { get; set; }
            [JsonProperty("CardNumber")]
            public string CardNo { get; set; }
            [JsonProperty("NameOnCard")]
            public string NameOnCard { get; set; }
            [JsonProperty("ExpMonth")]
            public string ExpMonth { get; set; }
            [JsonProperty("ExpYear")]
            public string ExpYear { get; set; }
            [JsonProperty("CVV")]
            public string CVV { get; set; }
            [JsonProperty("Fname")]
            public string Fname { get; set; }
            [JsonProperty("Lname")]
            public string Lname { get; set; }
            [JsonProperty("Address1")]
            public string Address1 { get; set; }
            [JsonProperty("City")]
            public string City { get; set; }
            [JsonProperty("State")]
            public string State { get; set; }
            [JsonProperty("Country")]
            public string Country { get; set; }
            [JsonProperty("Zip")]
            public string Zip { get; set; }
            [JsonProperty("Email")]
            public string Email { get; set; }
            [JsonProperty("PhoneNo")]
            public string PhoneNo { get; set; }
            [JsonProperty("ErrorInput")]
            public string ErrorInput { get; set; }
            [JsonProperty("AccountHolderName")]
            public string AccountHolderName { get; set; }
            [JsonProperty("RoutingNo")]
            public string RoutingNo { get; set; }
            [JsonProperty("AccountNo")]
            public string AccountNo { get; set; }
            [JsonProperty("PartialAmt")]
            public string PartialAmt { get; set; }
            
            

        }
    }
}
