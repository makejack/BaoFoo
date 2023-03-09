using System.Text.Json.Serialization;

namespace Lin.Pay.BaoFoo.Domain;

/// <summary>
/// 聚合支付 分账参数域
/// </summary>
public class PaymentSplitInfoList
{
    
    /// <summary>
    /// 分账订单号
    /// <remarks>
    /// 单号唯一。生成规则：终端号+流水号，最长32位
    /// </remarks>
    /// </summary>
    [JsonPropertyName("subOutOrderNo")]
    public string SubOutOrderNo { get; set; }

    /// <summary>
    /// 客户账户号
    /// <remarks>
    /// 客户类型为ORG时传机构/平台号
    /// </remarks>
    /// </summary>
    [JsonPropertyName("contractNo")]
    public string ContractNo { get; set; }

    /// <summary>
    /// 客户类型
    /// <remarks>
    /// ORG - 机构/平台
    /// PERSON - 个人账户
    /// B_ACCOUNT - B端账户
    /// </remarks>
    /// </summary>
    [JsonPropertyName("customerType")]
    public string CustomerType { get; set; }

    /// <summary>
    /// 分账金额
    /// <remarks>
    /// 单位：分 分账金额总和不能超过订单金额
    /// </remarks>
    /// </summary>
    [JsonPropertyName("splitAmount")]
    public string SplitAmount { get; set; }

    /// <summary>
    /// 卖家标识
    /// <remarks>
    /// 0-不是卖家(如参与分账的平台) 1-是卖家(一笔担保交易只能有一个卖家)
    /// </remarks>
    /// </summary>
    [JsonPropertyName("sellerFlag")]
    public string SellerFlag { get; set; }

}