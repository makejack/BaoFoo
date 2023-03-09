using System.Text.Json.Serialization;

namespace Lin.Pay.BaoFoo.Domain;

/// <summary>
/// 分账申请退款结果列表集合
/// </summary>
public class RefundSplitResultList
{
    
    /// <summary>
    /// 原分账子订单号	
    /// </summary>
    [JsonPropertyName("orgSubOutOrderNo")]
    public string OrgSubOutOrderNo { get; set; }

    /// <summary>
    /// 处理结果
    /// <remarks>
    /// P-受理成功
    /// F-失败
    /// </remarks>
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }

}