using FBAInventoryServiceMWS;
using FBAInventoryServiceMWS.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace MwsFbaInventory
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get Inventory List Supply
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListInventorySupply_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            FBAInventoryServiceMWSConfig config = new FBAInventoryServiceMWSConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            FBAInventoryServiceMWSClient client = new FBAInventoryServiceMWSClient(
                                                            AccessKeyId,
                                                            SecretKeyId,
                                                            ApplicationName,
                                                            ApplicationVersion,
                                                            config);
            ListInventorySupplyRequest request = new ListInventorySupplyRequest();
            request.SellerId = SellerId;
            request.Marketplace = MarketplaceId;
            request.MWSAuthToken = MWSAuthToken;
            request.QueryStartDateTime = DateTime.Now.AddMonths(1);
            request.ResponseGroup = "Detailed";

            ListInventorySupplyResponse response = client.ListInventorySupply(request);
            if (response.IsSetListInventorySupplyResult())
            {
                ListInventorySupplyResult listInventorySupplyResult = response.ListInventorySupplyResult;
                if (listInventorySupplyResult.IsSetInventorySupplyList())
                {
                    InventorySupplyList inventorySupplyList = listInventorySupplyResult.InventorySupplyList;
                    List<InventorySupply> memberList = inventorySupplyList.member;
                    if (memberList.Count > 0)
                    {
                        foreach (InventorySupply member in memberList)
                        {
                            if (member.IsSetSupplyDetail())
                            {
                                InventorySupplyDetailList supplyDetail = member.SupplyDetail;
                                List<InventorySupplyDetail> member1List = supplyDetail.member;
                                foreach (InventorySupplyDetail member1 in member1List)
                                {
                                    if (member1.IsSetQuantity())
                                    {
                                        strbuff += "Amaount：" + member1.Quantity;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        strbuff = "Not find Stock Information.";
                    }
                }
            }
            txtListInventorySupply.Text = strbuff;
        }

        /// <summary>
        /// Get Next Inventory List Supply
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListInventorySupplyByNextToken_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            FBAInventoryServiceMWSConfig config = new FBAInventoryServiceMWSConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            FBAInventoryServiceMWSClient client = new FBAInventoryServiceMWSClient(
                                                            AccessKeyId,
                                                            SecretKeyId,
                                                            ApplicationName,
                                                            ApplicationVersion,
                                                            config);
            ListInventorySupplyRequest request = new ListInventorySupplyRequest();
            request.SellerId = SellerId;
            request.Marketplace = MarketplaceId;
            request.MWSAuthToken = MWSAuthToken;
            request.QueryStartDateTime = DateTime.Now.AddMonths(1);
            request.ResponseGroup = "Detailed";

            ListInventorySupplyResponse response = client.ListInventorySupply(request);
            if (response.IsSetListInventorySupplyResult())
            {
                ListInventorySupplyResult listInventorySupplyResult = response.ListInventorySupplyResult;
                if (listInventorySupplyResult.IsSetInventorySupplyList())
                {
                    if (listInventorySupplyResult.NextToken != null)
                    {
                        ListInventorySupplyByNextTokenRequest request1 = new ListInventorySupplyByNextTokenRequest();
                        request1.SellerId = SellerId;
                        request1.Marketplace = MarketplaceId;
                        request1.MWSAuthToken = MWSAuthToken;
                        request1.NextToken = listInventorySupplyResult.NextToken;

                        ListInventorySupplyByNextTokenResponse response1 = client.ListInventorySupplyByNextToken(request1);
                        if (response1.IsSetListInventorySupplyByNextTokenResult())
                        {
                            ListInventorySupplyByNextTokenResult listInventorySupplyByNextTokenResult = response1.ListInventorySupplyByNextTokenResult;
                            if (listInventorySupplyByNextTokenResult.IsSetInventorySupplyList())
                            {
                                InventorySupplyList inventorySupplyList = listInventorySupplyByNextTokenResult.InventorySupplyList;
                                List<InventorySupply> memberList = inventorySupplyList.member;
                                if (memberList.Count > 0)
                                {
                                    foreach (InventorySupply member in memberList)
                                    {
                                        if (member.IsSetTotalSupplyQuantity())
                                        {
                                            strbuff += "Amount：" + member.TotalSupplyQuantity;
                                        }
                                    }
                                }
                                else
                                {
                                    strbuff = "Not find next stock information.";
                                }
                            }
                        }
                    }
                }
            }
            txtListInventorySupplyByNextToken.Text = strbuff;
        }

        /// <summary>
        /// Get Service Status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetServiceStatus_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            FBAInventoryServiceMWSConfig config = new FBAInventoryServiceMWSConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            FBAInventoryServiceMWSClient client = new FBAInventoryServiceMWSClient(
                                                            AccessKeyId,
                                                            SecretKeyId,
                                                            ApplicationName,
                                                            ApplicationVersion,
                                                            config);
            GetServiceStatusRequest request = new GetServiceStatusRequest();
            request.SellerId = SellerId;
            request.Marketplace = MarketplaceId;
            request.MWSAuthToken = MWSAuthToken;
            GetServiceStatusResponse response = client.GetServiceStatus(request);
            if (response.IsSetGetServiceStatusResult())
            {
                GetServiceStatusResult getServiceStatusResult = response.GetServiceStatusResult;
                if (getServiceStatusResult.IsSetStatus())
                {
                    strbuff = "Status：" + getServiceStatusResult.Status;
                }
            }
            txtGetServiceStatus.Text = strbuff;
        }
    }
}
