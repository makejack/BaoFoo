using System.Text.Json.Serialization;

namespace Lin.Pay.BaoFoo.Domain;

/// <summary>
/// 分账退款详情
/// </summary>
public class RefundSplitInfoList
{
    
    /// <summary>
    /// 原分账子订单号	
    /// <remarks>
    /// 原分账子单号
    /// </remarks>
    /// </summary>
    [JsonPropertyName("orgSubOutOrderNo")]
    public string OrgSubOutOrderNo { get; set; }

    /// <summary>
    /// 分账退款金额
    /// <remarks>
    /// 分账退款金额
    /// </remarks>
    /// </summary>
    [JsonPropertyName("refundAmount")]
    public string RefundAmount { get; set; }

}