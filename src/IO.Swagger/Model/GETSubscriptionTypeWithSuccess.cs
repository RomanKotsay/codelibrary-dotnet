/* 
 * Zuora API Reference
 *
 *  # Introduction  Welcome to the reference for the Zuora REST API!  <a href=\"http://en.wikipedia.org/wiki/REST_API\" target=\"_blank\">REST</a> is a web-service protocol that lends itself to rapid development by using everyday HTTP and JSON technology.  The Zuora REST API provides a broad set of operations and resources that:  * Enable Web Storefront integration between your websites. * Support self-service subscriber sign-ups and account management. * Process revenue schedules through custom revenue rule models.  ## Endpoints  The Zuora REST services are provided via the following endpoints.  | Service                 | Base URL for REST Endpoints                                                                                                                                         | |- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | Production REST service | https://rest.zuora.com/v1                                                                                                                                           | | Sandbox REST service    | https://rest.apisandbox.zuora.com/v1                                                                                                                                |  The production service provides access to your live user data. The sandbox environment is a good place to test your code without affecting real-world data. To use it, you must be provisioned with a sandbox tenant - your Zuora representative can help with this if needed.  ## Accessing the API  If you have a Zuora tenant, you already have access the the API.  If you don't have a Zuora tenant, go to <a href=\"https://www.zuora.com/resource/zuora-test-drive\" target=\"_blank\">https://www.zuora.com/resource/zuora-test-drive</a> and sign up for a trial tenant. The tenant comes with seed data, such as a sample product catalog.   We recommend that you <a href=\"https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/Manage_Users/Create_an_API_User\" target=\"_blank\">create an API user</a> specifically for making API calls. Don't log in to the Zuora UI with this account. Logging in to the UI enables a security feature that periodically expires the account's password, which may eventually cause authentication failures with the API. Note that a user role does not have write access to Zuora REST services unless it has the API Write Access permission as described in those instructions.   # Authentication  There are three ways to authenticate:  * Use an authorization cookie. The cookie authorizes the user to make calls to the REST API for the duration specified in  **Administration > Security Policies > Session timeout**. The cookie expiration time is reset with this duration after every call to the REST API. To obtain a cookie, call the REST  `connections` resource with the following API user information:     *   ID     *   password     *   entity Id or entity name (Only for [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity \"Multi-entity\"). See \"Entity Id and Entity Name\" below for more information.)  *   Include the following parameters in the request header, which re-authenticates the user with each request:     *   `apiAccessKeyId`     *   `apiSecretAccessKey`     *   `entityId` or `entityName` (Only for [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity \"Multi-entity\"). See \"Entity Id and Entity Name\" below for more information.) *   For CORS-enabled APIs only: Include a 'single-use' token in the request header, which re-authenticates the user with each request. See below for more details.   ## Entity Id and Entity Name  The `entityId` and `entityName`  parameters are only used for  [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity).  The  `entityId` parameter specifies the Id of the entity that you want to access. The `entityName` parameter specifies the [name of the entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity/B_Introduction_to_Entity_and_Entity_Hierarchy#Name_and_Display_Name \"Introduction to Entity and Entity Hierarchy\") that you want to access. Note that you must have permission to access the entity. You can get the entity Id and entity name through the REST GET Entities call.  You can specify either the  `entityId` or `entityName` parameter in the authentication to access and view an entity.  *   If both `entityId` and `entityName` are specified in the authentication, an error occurs.  *   If neither  `entityId` nor  `entityName` is specified in the authentication, you will log in to the entity in which your user account is created.   See [API User Authentication](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity/A_Overview_of_Multi-entity#API_User_Authentication \"Zuora Multi-entity\") for more information.  ## Token Authentication for CORS-Enabled APIs  The CORS mechanism enables REST API calls to Zuora to be made directly from your customer's browser, with all credit card and security information transmitted directly to Zuora. This minimizes your PCI compliance burden, allows you to implement advanced validation on your payment forms, and makes your payment forms look just like any other part of your website.  For security reasons, instead of using cookies, an API request via CORS uses **tokens** for authentication.  The token method of authentication is only designed for use with requests that must originate from your customer's browser; **it should not be considered a replacement to the existing cookie authentication** mechanism.  See [Zuora CORS REST ](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics/G_CORS_REST \"Zuora CORS REST\")for details on how CORS works and how you can begin to implement customer calls to the Zuora REST APIs. See  [HMAC Signatures](/BC_Developers/REST_API/B_REST_API_reference/HMAC_Signatures \"HMAC Signatures\") for details on the HMAC method that returns the authentication token.    # Requests and Responses   ## Request IDs  As a general rule, when asked to supply a \"key\" for an account or subscription (accountKey, account-key, subscriptionKey, subscription-key), you can provide either the actual ID or the number of the entity.  ## HTTP Request Body  Most of the parameters and data accompanying your requests will be contained in the body of the HTTP request.  The Zuora REST API accepts JSON in the HTTP request body.  No other data format (e.g., XML) is supported.   ## Testing a Request  Use a third party client, such as Postman or Advanced REST Client, to test the Zuora REST API.  You can test the Zuora REST API from the Zuora sandbox or  production service. If connecting to the production service, bear in mind that you are working with your live production data, not sample data or test data.  ## Testing with Credit Cards  Sooner or later it will probably be necessary to test some transactions that involve credit cards. For suggestions on how to handle this, see [Going Live With Your Payment Gateway](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/C_Managing_Payment_Gateways/B_Going_Live_Payment_Gateways#Testing_with_Credit_Cards \"C_Zuora_User_Guides/A_Billing_and_Payments/M_Payment_Gateways/C_Managing_Payment_Gateways/B_Going_Live_Payment_Gateways#Testing_with_Credit_Cards\").       ## Error Handling  Responses and error codes are detailed in [Responses and errors](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics/3_Responses_and_errors \"Responses and errors\").    # Pagination  When retrieving information (using GET methods), the optional `pageSize` query parameter sets the maximum number of rows to return in a response. The maximum is `40`; larger values are treated as `40`. If this value is empty or invalid, `pageSize` typically defaults to `10`.  The default value for the maximum number of rows retrieved can be overridden at the method level.  If more rows are available, the response will include a `nextPage` element, which contains a URL for requesting the next page.  If this value is not provided, no more rows are available. No \"previous page\" element is explicitly provided; to support backward paging, use the previous call.  ## Array Size  For data items that are not paginated, the REST API supports arrays of up to 300 rows.  Thus, for instance, repeated pagination can retrieve thousands of customer accounts, but within any account an array of no more than 300 rate plans is returned.   # API Versions  The Zuora REST API is in version control. Versioning ensures that Zuora REST API changes are backward compatible. Zuora uses a major and minor version nomenclature to manage changes. By specifying a version in a REST request, you can get expected responses regardless of future changes to the API.   ## Major Version  The major version number of the REST API appears in the REST URL. Currently, Zuora only supports the **v1** major version. For example,  `POST https://rest.zuora.com/v1/subscriptions` .   ## Minor Version  Zuora uses minor versions for the REST API to control small changes. For example, a field in a REST method is deprecated and a new field is used to replace it.   Some fields in the REST methods are supported as of minor versions. If a field is not noted with a minor version, this field is available for all minor versions. If a field is noted with a minor version, this field is in version control. You must specify the supported minor version in the request header to process without an error.   If a field is in version control, it is either with a minimum minor version or a maximum minor version, or both of them. You can only use this field with the minor version between the minimum and the maximum minor versions. For example, the  `invoiceCollect` field in the POST Subscription method is in version control and its maximum minor version is 189.0. You can only use this field with the minor version 189.0 or earlier.  The supported minor versions are not serial, see [Zuora REST API Minor Version History](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics/Zuora_REST_API_Minor_Version_History \"Zuora REST API Minor Version History\") for the fields and their supported minor versions. In our REST API documentation, if a field or feature requires a minor version number, we note that in the field description.  You only need to specify the version number when you use the fields require a minor version. To specify the minor version, set the `zuora-version` parameter to the minor version number in the request header for the request call. For example, the `collect` field is in 196.0 minor version. If you want to use this field for the POST Subscription method, set the  `zuora-version` parameter to `196.0` in the request header. The `zuora-version` parameter is case sensitive.   For all the REST API fields, by default, if the minor version is not specified in the request header, Zuora will use the minimum minor version of the REST API to avoid breaking your integration.     # Zuora Object Model The following diagram presents a high-level view of the key Zuora objects. Click the image to open it in a new tab to resize it.  <a href=\"https://www.zuora.com/wp-content/uploads/2016/10/ZuoraERD-compressor-1.jpeg\" target=\"_blank\"><img src=\"https://www.zuora.com/wp-content/uploads/2016/10/ZuoraERD-compressor-1.jpeg\" alt=\"Zuora Object Model Diagram\"></a> 
 *
 * OpenAPI spec version: 0.0.1
 * Contact: docs@zuora.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace IO.Swagger.Model
{
    /// <summary>
    /// GETSubscriptionTypeWithSuccess
    /// </summary>
    [DataContract]
    public partial class GETSubscriptionTypeWithSuccess :  IEquatable<GETSubscriptionTypeWithSuccess>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GETSubscriptionTypeWithSuccess" /> class.
        /// </summary>
        /// <param name="CpqBundleJsonIdQT">.</param>
        /// <param name="OpportunityCloseDateQT">The closing date of the Opportunity. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. .</param>
        /// <param name="OpportunityNameQT">The unique identifier of the Opportunity. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. .</param>
        /// <param name="QuoteBusinessTypeQT">The specific identifier for the type of business transaction the Quote represents such as New, Upsell, Downsell, Renewal, or Churn. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. .</param>
        /// <param name="QuoteNumberQT">The unique identifier of the Quote. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.  See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. .</param>
        /// <param name="QuoteTypeQT">The Quote type that represents the subscription lifecycle stage such as New, Amendment, Renew or Cancel. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. .</param>
        /// <param name="AccountId">.</param>
        /// <param name="AccountName">.</param>
        /// <param name="AccountNumber">.</param>
        /// <param name="AutoRenew">If &#x60;true&#x60;, the subscription automatically renews at the end of the term. Default is &#x60;false&#x60;. .</param>
        /// <param name="ContractEffectiveDate">Effective contract date for this subscription, as yyyy-mm-dd. .</param>
        /// <param name="ContractedMrr">Monthly recurring revenue of the subscription. .</param>
        /// <param name="CurrentTerm">The length of the period for the current subscription term. .</param>
        /// <param name="CurrentTermPeriodType">The period type for the current subscription term.  Values are:  * &#x60;Month&#x60; (default) * &#x60;Year&#x60; * &#x60;Day&#x60; * &#x60;Week&#x60; .</param>
        /// <param name="CustomFieldC">Any custom fields defined for this object. .</param>
        /// <param name="CustomerAcceptanceDate">The date on which the services or products within a subscription have been accepted by the customer, as yyyy-mm-dd. .</param>
        /// <param name="Id">Subscription ID. .</param>
        /// <param name="InitialTerm">The length of the period for the first subscription term. .</param>
        /// <param name="InitialTermPeriodType">The period type for the first subscription term.  Values are:  * &#x60;Month&#x60; (default) * &#x60;Year&#x60; * &#x60;Day&#x60; * &#x60;Week&#x60; .</param>
        /// <param name="InvoiceOwnerAccountId">.</param>
        /// <param name="InvoiceOwnerAccountName">.</param>
        /// <param name="InvoiceOwnerAccountNumber">.</param>
        /// <param name="InvoiceSeparately">Separates a single subscription from other subscriptions and creates an invoice for the subscription.   If the value is &#x60;true&#x60;, the subscription is billed separately from other subscriptions. If the value is &#x60;false&#x60;, the subscription is included with other subscriptions in the account invoice. .</param>
        /// <param name="Notes">A string of up to 65,535 characters. .</param>
        /// <param name="RatePlans">Container for rate plans. .</param>
        /// <param name="RenewalSetting">Specifies whether a termed subscription will remain &#x60;TERMED&#x60; or change to &#x60;EVERGREEN&#x60; when it is renewed.   Values are:  * &#x60;RENEW_WITH_SPECIFIC_TERM&#x60; (default) * &#x60;RENEW_TO_EVERGREEN&#x60; .</param>
        /// <param name="RenewalTerm">The length of the period for the subscription renewal term. .</param>
        /// <param name="RenewalTermPeriodType">The period type for the subscription renewal term.  Values are:  * &#x60;Month&#x60; (default) * &#x60;Year&#x60; * &#x60;Day&#x60; * &#x60;Week&#x60; .</param>
        /// <param name="ServiceActivationDate">The date on which the services or products within a subscription have been activated and access has been provided to the customer, as yyyy-mm-dd .</param>
        /// <param name="Status">Subscription status; possible values are:  * &#x60;Draft&#x60; * &#x60;PendingActivation&#x60; * &#x60;PendingAcceptance&#x60; * &#x60;Active&#x60; * &#x60;Cancelled&#x60; * &#x60;Suspended&#x60; (This value is in Limited Availability.) .</param>
        /// <param name="SubscriptionNumber">.</param>
        /// <param name="SubscriptionStartDate">Date the subscription becomes effective. .</param>
        /// <param name="Success">Returns &#x60;true&#x60; if the request was processed successfully. .</param>
        /// <param name="TermEndDate">Date the subscription term ends. If the subscription is evergreen, this is null or is the cancellation date (if one has been set). .</param>
        /// <param name="TermStartDate">Date the subscription term begins. If this is a renewal subscription, this date is different from the subscription start date. .</param>
        /// <param name="TermType">Possible values are: &#x60;TERMED&#x60;, &#x60;EVERGREEN&#x60;. .</param>
        /// <param name="TotalContractedValue">Total contracted value of the subscription. .</param>
        public GETSubscriptionTypeWithSuccess(string CpqBundleJsonIdQT = null, string OpportunityCloseDateQT = null, string OpportunityNameQT = null, string QuoteBusinessTypeQT = null, string QuoteNumberQT = null, string QuoteTypeQT = null, string AccountId = null, string AccountName = null, string AccountNumber = null, bool? AutoRenew = null, DateTime? ContractEffectiveDate = null, string ContractedMrr = null, long? CurrentTerm = null, string CurrentTermPeriodType = null, string CustomFieldC = null, DateTime? CustomerAcceptanceDate = null, string Id = null, long? InitialTerm = null, string InitialTermPeriodType = null, string InvoiceOwnerAccountId = null, string InvoiceOwnerAccountName = null, string InvoiceOwnerAccountNumber = null, string InvoiceSeparately = null, string Notes = null, List<GETSubscriptionRatePlanType> RatePlans = null, string RenewalSetting = null, long? RenewalTerm = null, string RenewalTermPeriodType = null, DateTime? ServiceActivationDate = null, string Status = null, string SubscriptionNumber = null, DateTime? SubscriptionStartDate = null, bool? Success = null, DateTime? TermEndDate = null, DateTime? TermStartDate = null, string TermType = null, string TotalContractedValue = null)
        {
            this.CpqBundleJsonIdQT = CpqBundleJsonIdQT;
            this.OpportunityCloseDateQT = OpportunityCloseDateQT;
            this.OpportunityNameQT = OpportunityNameQT;
            this.QuoteBusinessTypeQT = QuoteBusinessTypeQT;
            this.QuoteNumberQT = QuoteNumberQT;
            this.QuoteTypeQT = QuoteTypeQT;
            this.AccountId = AccountId;
            this.AccountName = AccountName;
            this.AccountNumber = AccountNumber;
            this.AutoRenew = AutoRenew;
            this.ContractEffectiveDate = ContractEffectiveDate;
            this.ContractedMrr = ContractedMrr;
            this.CurrentTerm = CurrentTerm;
            this.CurrentTermPeriodType = CurrentTermPeriodType;
            this.CustomFieldC = CustomFieldC;
            this.CustomerAcceptanceDate = CustomerAcceptanceDate;
            this.Id = Id;
            this.InitialTerm = InitialTerm;
            this.InitialTermPeriodType = InitialTermPeriodType;
            this.InvoiceOwnerAccountId = InvoiceOwnerAccountId;
            this.InvoiceOwnerAccountName = InvoiceOwnerAccountName;
            this.InvoiceOwnerAccountNumber = InvoiceOwnerAccountNumber;
            this.InvoiceSeparately = InvoiceSeparately;
            this.Notes = Notes;
            this.RatePlans = RatePlans;
            this.RenewalSetting = RenewalSetting;
            this.RenewalTerm = RenewalTerm;
            this.RenewalTermPeriodType = RenewalTermPeriodType;
            this.ServiceActivationDate = ServiceActivationDate;
            this.Status = Status;
            this.SubscriptionNumber = SubscriptionNumber;
            this.SubscriptionStartDate = SubscriptionStartDate;
            this.Success = Success;
            this.TermEndDate = TermEndDate;
            this.TermStartDate = TermStartDate;
            this.TermType = TermType;
            this.TotalContractedValue = TotalContractedValue;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="CpqBundleJsonId__QT", EmitDefaultValue=false)]
        public string CpqBundleJsonIdQT { get; set; }
        /// <summary>
        /// The closing date of the Opportunity. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. 
        /// </summary>
        /// <value>The closing date of the Opportunity. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. </value>
        [DataMember(Name="OpportunityCloseDate__QT", EmitDefaultValue=false)]
        public string OpportunityCloseDateQT { get; set; }
        /// <summary>
        /// The unique identifier of the Opportunity. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. 
        /// </summary>
        /// <value>The unique identifier of the Opportunity. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. </value>
        [DataMember(Name="OpportunityName__QT", EmitDefaultValue=false)]
        public string OpportunityNameQT { get; set; }
        /// <summary>
        /// The specific identifier for the type of business transaction the Quote represents such as New, Upsell, Downsell, Renewal, or Churn. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. 
        /// </summary>
        /// <value>The specific identifier for the type of business transaction the Quote represents such as New, Upsell, Downsell, Renewal, or Churn. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. </value>
        [DataMember(Name="QuoteBusinessType__QT", EmitDefaultValue=false)]
        public string QuoteBusinessTypeQT { get; set; }
        /// <summary>
        /// The unique identifier of the Quote. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.  See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. 
        /// </summary>
        /// <value>The unique identifier of the Quote. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.  See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. </value>
        [DataMember(Name="QuoteNumber__QT", EmitDefaultValue=false)]
        public string QuoteNumberQT { get; set; }
        /// <summary>
        /// The Quote type that represents the subscription lifecycle stage such as New, Amendment, Renew or Cancel. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. 
        /// </summary>
        /// <value>The Quote type that represents the subscription lifecycle stage such as New, Amendment, Renew or Cancel. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. </value>
        [DataMember(Name="QuoteType__QT", EmitDefaultValue=false)]
        public string QuoteTypeQT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="accountId", EmitDefaultValue=false)]
        public string AccountId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="accountName", EmitDefaultValue=false)]
        public string AccountName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="accountNumber", EmitDefaultValue=false)]
        public string AccountNumber { get; set; }
        /// <summary>
        /// If &#x60;true&#x60;, the subscription automatically renews at the end of the term. Default is &#x60;false&#x60;. 
        /// </summary>
        /// <value>If &#x60;true&#x60;, the subscription automatically renews at the end of the term. Default is &#x60;false&#x60;. </value>
        [DataMember(Name="autoRenew", EmitDefaultValue=false)]
        public bool? AutoRenew { get; set; }
        /// <summary>
        /// Effective contract date for this subscription, as yyyy-mm-dd. 
        /// </summary>
        /// <value>Effective contract date for this subscription, as yyyy-mm-dd. </value>
        [DataMember(Name="contractEffectiveDate", EmitDefaultValue=false)]
        public DateTime? ContractEffectiveDate { get; set; }
        /// <summary>
        /// Monthly recurring revenue of the subscription. 
        /// </summary>
        /// <value>Monthly recurring revenue of the subscription. </value>
        [DataMember(Name="contractedMrr", EmitDefaultValue=false)]
        public string ContractedMrr { get; set; }
        /// <summary>
        /// The length of the period for the current subscription term. 
        /// </summary>
        /// <value>The length of the period for the current subscription term. </value>
        [DataMember(Name="currentTerm", EmitDefaultValue=false)]
        public long? CurrentTerm { get; set; }
        /// <summary>
        /// The period type for the current subscription term.  Values are:  * &#x60;Month&#x60; (default) * &#x60;Year&#x60; * &#x60;Day&#x60; * &#x60;Week&#x60; 
        /// </summary>
        /// <value>The period type for the current subscription term.  Values are:  * &#x60;Month&#x60; (default) * &#x60;Year&#x60; * &#x60;Day&#x60; * &#x60;Week&#x60; </value>
        [DataMember(Name="currentTermPeriodType", EmitDefaultValue=false)]
        public string CurrentTermPeriodType { get; set; }
        /// <summary>
        /// Any custom fields defined for this object. 
        /// </summary>
        /// <value>Any custom fields defined for this object. </value>
        [DataMember(Name="customField__c", EmitDefaultValue=false)]
        public string CustomFieldC { get; set; }
        /// <summary>
        /// The date on which the services or products within a subscription have been accepted by the customer, as yyyy-mm-dd. 
        /// </summary>
        /// <value>The date on which the services or products within a subscription have been accepted by the customer, as yyyy-mm-dd. </value>
        [DataMember(Name="customerAcceptanceDate", EmitDefaultValue=false)]
        public DateTime? CustomerAcceptanceDate { get; set; }
        /// <summary>
        /// Subscription ID. 
        /// </summary>
        /// <value>Subscription ID. </value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
        /// <summary>
        /// The length of the period for the first subscription term. 
        /// </summary>
        /// <value>The length of the period for the first subscription term. </value>
        [DataMember(Name="initialTerm", EmitDefaultValue=false)]
        public long? InitialTerm { get; set; }
        /// <summary>
        /// The period type for the first subscription term.  Values are:  * &#x60;Month&#x60; (default) * &#x60;Year&#x60; * &#x60;Day&#x60; * &#x60;Week&#x60; 
        /// </summary>
        /// <value>The period type for the first subscription term.  Values are:  * &#x60;Month&#x60; (default) * &#x60;Year&#x60; * &#x60;Day&#x60; * &#x60;Week&#x60; </value>
        [DataMember(Name="initialTermPeriodType", EmitDefaultValue=false)]
        public string InitialTermPeriodType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="invoiceOwnerAccountId", EmitDefaultValue=false)]
        public string InvoiceOwnerAccountId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="invoiceOwnerAccountName", EmitDefaultValue=false)]
        public string InvoiceOwnerAccountName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="invoiceOwnerAccountNumber", EmitDefaultValue=false)]
        public string InvoiceOwnerAccountNumber { get; set; }
        /// <summary>
        /// Separates a single subscription from other subscriptions and creates an invoice for the subscription.   If the value is &#x60;true&#x60;, the subscription is billed separately from other subscriptions. If the value is &#x60;false&#x60;, the subscription is included with other subscriptions in the account invoice. 
        /// </summary>
        /// <value>Separates a single subscription from other subscriptions and creates an invoice for the subscription.   If the value is &#x60;true&#x60;, the subscription is billed separately from other subscriptions. If the value is &#x60;false&#x60;, the subscription is included with other subscriptions in the account invoice. </value>
        [DataMember(Name="invoiceSeparately", EmitDefaultValue=false)]
        public string InvoiceSeparately { get; set; }
        /// <summary>
        /// A string of up to 65,535 characters. 
        /// </summary>
        /// <value>A string of up to 65,535 characters. </value>
        [DataMember(Name="notes", EmitDefaultValue=false)]
        public string Notes { get; set; }
        /// <summary>
        /// Container for rate plans. 
        /// </summary>
        /// <value>Container for rate plans. </value>
        [DataMember(Name="ratePlans", EmitDefaultValue=false)]
        public List<GETSubscriptionRatePlanType> RatePlans { get; set; }
        /// <summary>
        /// Specifies whether a termed subscription will remain &#x60;TERMED&#x60; or change to &#x60;EVERGREEN&#x60; when it is renewed.   Values are:  * &#x60;RENEW_WITH_SPECIFIC_TERM&#x60; (default) * &#x60;RENEW_TO_EVERGREEN&#x60; 
        /// </summary>
        /// <value>Specifies whether a termed subscription will remain &#x60;TERMED&#x60; or change to &#x60;EVERGREEN&#x60; when it is renewed.   Values are:  * &#x60;RENEW_WITH_SPECIFIC_TERM&#x60; (default) * &#x60;RENEW_TO_EVERGREEN&#x60; </value>
        [DataMember(Name="renewalSetting", EmitDefaultValue=false)]
        public string RenewalSetting { get; set; }
        /// <summary>
        /// The length of the period for the subscription renewal term. 
        /// </summary>
        /// <value>The length of the period for the subscription renewal term. </value>
        [DataMember(Name="renewalTerm", EmitDefaultValue=false)]
        public long? RenewalTerm { get; set; }
        /// <summary>
        /// The period type for the subscription renewal term.  Values are:  * &#x60;Month&#x60; (default) * &#x60;Year&#x60; * &#x60;Day&#x60; * &#x60;Week&#x60; 
        /// </summary>
        /// <value>The period type for the subscription renewal term.  Values are:  * &#x60;Month&#x60; (default) * &#x60;Year&#x60; * &#x60;Day&#x60; * &#x60;Week&#x60; </value>
        [DataMember(Name="renewalTermPeriodType", EmitDefaultValue=false)]
        public string RenewalTermPeriodType { get; set; }
        /// <summary>
        /// The date on which the services or products within a subscription have been activated and access has been provided to the customer, as yyyy-mm-dd 
        /// </summary>
        /// <value>The date on which the services or products within a subscription have been activated and access has been provided to the customer, as yyyy-mm-dd </value>
        [DataMember(Name="serviceActivationDate", EmitDefaultValue=false)]
        public DateTime? ServiceActivationDate { get; set; }
        /// <summary>
        /// Subscription status; possible values are:  * &#x60;Draft&#x60; * &#x60;PendingActivation&#x60; * &#x60;PendingAcceptance&#x60; * &#x60;Active&#x60; * &#x60;Cancelled&#x60; * &#x60;Suspended&#x60; (This value is in Limited Availability.) 
        /// </summary>
        /// <value>Subscription status; possible values are:  * &#x60;Draft&#x60; * &#x60;PendingActivation&#x60; * &#x60;PendingAcceptance&#x60; * &#x60;Active&#x60; * &#x60;Cancelled&#x60; * &#x60;Suspended&#x60; (This value is in Limited Availability.) </value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="subscriptionNumber", EmitDefaultValue=false)]
        public string SubscriptionNumber { get; set; }
        /// <summary>
        /// Date the subscription becomes effective. 
        /// </summary>
        /// <value>Date the subscription becomes effective. </value>
        [DataMember(Name="subscriptionStartDate", EmitDefaultValue=false)]
        public DateTime? SubscriptionStartDate { get; set; }
        /// <summary>
        /// Returns &#x60;true&#x60; if the request was processed successfully. 
        /// </summary>
        /// <value>Returns &#x60;true&#x60; if the request was processed successfully. </value>
        [DataMember(Name="success", EmitDefaultValue=false)]
        public bool? Success { get; set; }
        /// <summary>
        /// Date the subscription term ends. If the subscription is evergreen, this is null or is the cancellation date (if one has been set). 
        /// </summary>
        /// <value>Date the subscription term ends. If the subscription is evergreen, this is null or is the cancellation date (if one has been set). </value>
        [DataMember(Name="termEndDate", EmitDefaultValue=false)]
        public DateTime? TermEndDate { get; set; }
        /// <summary>
        /// Date the subscription term begins. If this is a renewal subscription, this date is different from the subscription start date. 
        /// </summary>
        /// <value>Date the subscription term begins. If this is a renewal subscription, this date is different from the subscription start date. </value>
        [DataMember(Name="termStartDate", EmitDefaultValue=false)]
        public DateTime? TermStartDate { get; set; }
        /// <summary>
        /// Possible values are: &#x60;TERMED&#x60;, &#x60;EVERGREEN&#x60;. 
        /// </summary>
        /// <value>Possible values are: &#x60;TERMED&#x60;, &#x60;EVERGREEN&#x60;. </value>
        [DataMember(Name="termType", EmitDefaultValue=false)]
        public string TermType { get; set; }
        /// <summary>
        /// Total contracted value of the subscription. 
        /// </summary>
        /// <value>Total contracted value of the subscription. </value>
        [DataMember(Name="totalContractedValue", EmitDefaultValue=false)]
        public string TotalContractedValue { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GETSubscriptionTypeWithSuccess {\n");
            sb.Append("  CpqBundleJsonIdQT: ").Append(CpqBundleJsonIdQT).Append("\n");
            sb.Append("  OpportunityCloseDateQT: ").Append(OpportunityCloseDateQT).Append("\n");
            sb.Append("  OpportunityNameQT: ").Append(OpportunityNameQT).Append("\n");
            sb.Append("  QuoteBusinessTypeQT: ").Append(QuoteBusinessTypeQT).Append("\n");
            sb.Append("  QuoteNumberQT: ").Append(QuoteNumberQT).Append("\n");
            sb.Append("  QuoteTypeQT: ").Append(QuoteTypeQT).Append("\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  AccountName: ").Append(AccountName).Append("\n");
            sb.Append("  AccountNumber: ").Append(AccountNumber).Append("\n");
            sb.Append("  AutoRenew: ").Append(AutoRenew).Append("\n");
            sb.Append("  ContractEffectiveDate: ").Append(ContractEffectiveDate).Append("\n");
            sb.Append("  ContractedMrr: ").Append(ContractedMrr).Append("\n");
            sb.Append("  CurrentTerm: ").Append(CurrentTerm).Append("\n");
            sb.Append("  CurrentTermPeriodType: ").Append(CurrentTermPeriodType).Append("\n");
            sb.Append("  CustomFieldC: ").Append(CustomFieldC).Append("\n");
            sb.Append("  CustomerAcceptanceDate: ").Append(CustomerAcceptanceDate).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  InitialTerm: ").Append(InitialTerm).Append("\n");
            sb.Append("  InitialTermPeriodType: ").Append(InitialTermPeriodType).Append("\n");
            sb.Append("  InvoiceOwnerAccountId: ").Append(InvoiceOwnerAccountId).Append("\n");
            sb.Append("  InvoiceOwnerAccountName: ").Append(InvoiceOwnerAccountName).Append("\n");
            sb.Append("  InvoiceOwnerAccountNumber: ").Append(InvoiceOwnerAccountNumber).Append("\n");
            sb.Append("  InvoiceSeparately: ").Append(InvoiceSeparately).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
            sb.Append("  RatePlans: ").Append(RatePlans).Append("\n");
            sb.Append("  RenewalSetting: ").Append(RenewalSetting).Append("\n");
            sb.Append("  RenewalTerm: ").Append(RenewalTerm).Append("\n");
            sb.Append("  RenewalTermPeriodType: ").Append(RenewalTermPeriodType).Append("\n");
            sb.Append("  ServiceActivationDate: ").Append(ServiceActivationDate).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  SubscriptionNumber: ").Append(SubscriptionNumber).Append("\n");
            sb.Append("  SubscriptionStartDate: ").Append(SubscriptionStartDate).Append("\n");
            sb.Append("  Success: ").Append(Success).Append("\n");
            sb.Append("  TermEndDate: ").Append(TermEndDate).Append("\n");
            sb.Append("  TermStartDate: ").Append(TermStartDate).Append("\n");
            sb.Append("  TermType: ").Append(TermType).Append("\n");
            sb.Append("  TotalContractedValue: ").Append(TotalContractedValue).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as GETSubscriptionTypeWithSuccess);
        }

        /// <summary>
        /// Returns true if GETSubscriptionTypeWithSuccess instances are equal
        /// </summary>
        /// <param name="other">Instance of GETSubscriptionTypeWithSuccess to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GETSubscriptionTypeWithSuccess other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.CpqBundleJsonIdQT == other.CpqBundleJsonIdQT ||
                    this.CpqBundleJsonIdQT != null &&
                    this.CpqBundleJsonIdQT.Equals(other.CpqBundleJsonIdQT)
                ) && 
                (
                    this.OpportunityCloseDateQT == other.OpportunityCloseDateQT ||
                    this.OpportunityCloseDateQT != null &&
                    this.OpportunityCloseDateQT.Equals(other.OpportunityCloseDateQT)
                ) && 
                (
                    this.OpportunityNameQT == other.OpportunityNameQT ||
                    this.OpportunityNameQT != null &&
                    this.OpportunityNameQT.Equals(other.OpportunityNameQT)
                ) && 
                (
                    this.QuoteBusinessTypeQT == other.QuoteBusinessTypeQT ||
                    this.QuoteBusinessTypeQT != null &&
                    this.QuoteBusinessTypeQT.Equals(other.QuoteBusinessTypeQT)
                ) && 
                (
                    this.QuoteNumberQT == other.QuoteNumberQT ||
                    this.QuoteNumberQT != null &&
                    this.QuoteNumberQT.Equals(other.QuoteNumberQT)
                ) && 
                (
                    this.QuoteTypeQT == other.QuoteTypeQT ||
                    this.QuoteTypeQT != null &&
                    this.QuoteTypeQT.Equals(other.QuoteTypeQT)
                ) && 
                (
                    this.AccountId == other.AccountId ||
                    this.AccountId != null &&
                    this.AccountId.Equals(other.AccountId)
                ) && 
                (
                    this.AccountName == other.AccountName ||
                    this.AccountName != null &&
                    this.AccountName.Equals(other.AccountName)
                ) && 
                (
                    this.AccountNumber == other.AccountNumber ||
                    this.AccountNumber != null &&
                    this.AccountNumber.Equals(other.AccountNumber)
                ) && 
                (
                    this.AutoRenew == other.AutoRenew ||
                    this.AutoRenew != null &&
                    this.AutoRenew.Equals(other.AutoRenew)
                ) && 
                (
                    this.ContractEffectiveDate == other.ContractEffectiveDate ||
                    this.ContractEffectiveDate != null &&
                    this.ContractEffectiveDate.Equals(other.ContractEffectiveDate)
                ) && 
                (
                    this.ContractedMrr == other.ContractedMrr ||
                    this.ContractedMrr != null &&
                    this.ContractedMrr.Equals(other.ContractedMrr)
                ) && 
                (
                    this.CurrentTerm == other.CurrentTerm ||
                    this.CurrentTerm != null &&
                    this.CurrentTerm.Equals(other.CurrentTerm)
                ) && 
                (
                    this.CurrentTermPeriodType == other.CurrentTermPeriodType ||
                    this.CurrentTermPeriodType != null &&
                    this.CurrentTermPeriodType.Equals(other.CurrentTermPeriodType)
                ) && 
                (
                    this.CustomFieldC == other.CustomFieldC ||
                    this.CustomFieldC != null &&
                    this.CustomFieldC.Equals(other.CustomFieldC)
                ) && 
                (
                    this.CustomerAcceptanceDate == other.CustomerAcceptanceDate ||
                    this.CustomerAcceptanceDate != null &&
                    this.CustomerAcceptanceDate.Equals(other.CustomerAcceptanceDate)
                ) && 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.InitialTerm == other.InitialTerm ||
                    this.InitialTerm != null &&
                    this.InitialTerm.Equals(other.InitialTerm)
                ) && 
                (
                    this.InitialTermPeriodType == other.InitialTermPeriodType ||
                    this.InitialTermPeriodType != null &&
                    this.InitialTermPeriodType.Equals(other.InitialTermPeriodType)
                ) && 
                (
                    this.InvoiceOwnerAccountId == other.InvoiceOwnerAccountId ||
                    this.InvoiceOwnerAccountId != null &&
                    this.InvoiceOwnerAccountId.Equals(other.InvoiceOwnerAccountId)
                ) && 
                (
                    this.InvoiceOwnerAccountName == other.InvoiceOwnerAccountName ||
                    this.InvoiceOwnerAccountName != null &&
                    this.InvoiceOwnerAccountName.Equals(other.InvoiceOwnerAccountName)
                ) && 
                (
                    this.InvoiceOwnerAccountNumber == other.InvoiceOwnerAccountNumber ||
                    this.InvoiceOwnerAccountNumber != null &&
                    this.InvoiceOwnerAccountNumber.Equals(other.InvoiceOwnerAccountNumber)
                ) && 
                (
                    this.InvoiceSeparately == other.InvoiceSeparately ||
                    this.InvoiceSeparately != null &&
                    this.InvoiceSeparately.Equals(other.InvoiceSeparately)
                ) && 
                (
                    this.Notes == other.Notes ||
                    this.Notes != null &&
                    this.Notes.Equals(other.Notes)
                ) && 
                (
                    this.RatePlans == other.RatePlans ||
                    this.RatePlans != null &&
                    this.RatePlans.SequenceEqual(other.RatePlans)
                ) && 
                (
                    this.RenewalSetting == other.RenewalSetting ||
                    this.RenewalSetting != null &&
                    this.RenewalSetting.Equals(other.RenewalSetting)
                ) && 
                (
                    this.RenewalTerm == other.RenewalTerm ||
                    this.RenewalTerm != null &&
                    this.RenewalTerm.Equals(other.RenewalTerm)
                ) && 
                (
                    this.RenewalTermPeriodType == other.RenewalTermPeriodType ||
                    this.RenewalTermPeriodType != null &&
                    this.RenewalTermPeriodType.Equals(other.RenewalTermPeriodType)
                ) && 
                (
                    this.ServiceActivationDate == other.ServiceActivationDate ||
                    this.ServiceActivationDate != null &&
                    this.ServiceActivationDate.Equals(other.ServiceActivationDate)
                ) && 
                (
                    this.Status == other.Status ||
                    this.Status != null &&
                    this.Status.Equals(other.Status)
                ) && 
                (
                    this.SubscriptionNumber == other.SubscriptionNumber ||
                    this.SubscriptionNumber != null &&
                    this.SubscriptionNumber.Equals(other.SubscriptionNumber)
                ) && 
                (
                    this.SubscriptionStartDate == other.SubscriptionStartDate ||
                    this.SubscriptionStartDate != null &&
                    this.SubscriptionStartDate.Equals(other.SubscriptionStartDate)
                ) && 
                (
                    this.Success == other.Success ||
                    this.Success != null &&
                    this.Success.Equals(other.Success)
                ) && 
                (
                    this.TermEndDate == other.TermEndDate ||
                    this.TermEndDate != null &&
                    this.TermEndDate.Equals(other.TermEndDate)
                ) && 
                (
                    this.TermStartDate == other.TermStartDate ||
                    this.TermStartDate != null &&
                    this.TermStartDate.Equals(other.TermStartDate)
                ) && 
                (
                    this.TermType == other.TermType ||
                    this.TermType != null &&
                    this.TermType.Equals(other.TermType)
                ) && 
                (
                    this.TotalContractedValue == other.TotalContractedValue ||
                    this.TotalContractedValue != null &&
                    this.TotalContractedValue.Equals(other.TotalContractedValue)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.CpqBundleJsonIdQT != null)
                    hash = hash * 59 + this.CpqBundleJsonIdQT.GetHashCode();
                if (this.OpportunityCloseDateQT != null)
                    hash = hash * 59 + this.OpportunityCloseDateQT.GetHashCode();
                if (this.OpportunityNameQT != null)
                    hash = hash * 59 + this.OpportunityNameQT.GetHashCode();
                if (this.QuoteBusinessTypeQT != null)
                    hash = hash * 59 + this.QuoteBusinessTypeQT.GetHashCode();
                if (this.QuoteNumberQT != null)
                    hash = hash * 59 + this.QuoteNumberQT.GetHashCode();
                if (this.QuoteTypeQT != null)
                    hash = hash * 59 + this.QuoteTypeQT.GetHashCode();
                if (this.AccountId != null)
                    hash = hash * 59 + this.AccountId.GetHashCode();
                if (this.AccountName != null)
                    hash = hash * 59 + this.AccountName.GetHashCode();
                if (this.AccountNumber != null)
                    hash = hash * 59 + this.AccountNumber.GetHashCode();
                if (this.AutoRenew != null)
                    hash = hash * 59 + this.AutoRenew.GetHashCode();
                if (this.ContractEffectiveDate != null)
                    hash = hash * 59 + this.ContractEffectiveDate.GetHashCode();
                if (this.ContractedMrr != null)
                    hash = hash * 59 + this.ContractedMrr.GetHashCode();
                if (this.CurrentTerm != null)
                    hash = hash * 59 + this.CurrentTerm.GetHashCode();
                if (this.CurrentTermPeriodType != null)
                    hash = hash * 59 + this.CurrentTermPeriodType.GetHashCode();
                if (this.CustomFieldC != null)
                    hash = hash * 59 + this.CustomFieldC.GetHashCode();
                if (this.CustomerAcceptanceDate != null)
                    hash = hash * 59 + this.CustomerAcceptanceDate.GetHashCode();
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.InitialTerm != null)
                    hash = hash * 59 + this.InitialTerm.GetHashCode();
                if (this.InitialTermPeriodType != null)
                    hash = hash * 59 + this.InitialTermPeriodType.GetHashCode();
                if (this.InvoiceOwnerAccountId != null)
                    hash = hash * 59 + this.InvoiceOwnerAccountId.GetHashCode();
                if (this.InvoiceOwnerAccountName != null)
                    hash = hash * 59 + this.InvoiceOwnerAccountName.GetHashCode();
                if (this.InvoiceOwnerAccountNumber != null)
                    hash = hash * 59 + this.InvoiceOwnerAccountNumber.GetHashCode();
                if (this.InvoiceSeparately != null)
                    hash = hash * 59 + this.InvoiceSeparately.GetHashCode();
                if (this.Notes != null)
                    hash = hash * 59 + this.Notes.GetHashCode();
                if (this.RatePlans != null)
                    hash = hash * 59 + this.RatePlans.GetHashCode();
                if (this.RenewalSetting != null)
                    hash = hash * 59 + this.RenewalSetting.GetHashCode();
                if (this.RenewalTerm != null)
                    hash = hash * 59 + this.RenewalTerm.GetHashCode();
                if (this.RenewalTermPeriodType != null)
                    hash = hash * 59 + this.RenewalTermPeriodType.GetHashCode();
                if (this.ServiceActivationDate != null)
                    hash = hash * 59 + this.ServiceActivationDate.GetHashCode();
                if (this.Status != null)
                    hash = hash * 59 + this.Status.GetHashCode();
                if (this.SubscriptionNumber != null)
                    hash = hash * 59 + this.SubscriptionNumber.GetHashCode();
                if (this.SubscriptionStartDate != null)
                    hash = hash * 59 + this.SubscriptionStartDate.GetHashCode();
                if (this.Success != null)
                    hash = hash * 59 + this.Success.GetHashCode();
                if (this.TermEndDate != null)
                    hash = hash * 59 + this.TermEndDate.GetHashCode();
                if (this.TermStartDate != null)
                    hash = hash * 59 + this.TermStartDate.GetHashCode();
                if (this.TermType != null)
                    hash = hash * 59 + this.TermType.GetHashCode();
                if (this.TotalContractedValue != null)
                    hash = hash * 59 + this.TotalContractedValue.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
