using System.Text.Json.Serialization;
using Lin.Pay.BaoFoo.Domain;

namespace Lin.Pay.BaoFoo.Responses;

/// <summary>
/// 退款申请响应
/// </summary>
public class ProfitShareRefundApplyResponse
{
        
    /// <summary>
    /// 宝户通退款订单号
    /// <remarks>
    /// 宝户通退款订单号
    /// </remarks>
    /// </summary>
    [JsonPropertyName("refundOrderId")]
    public string RefundOrderId { get; set; }
    
    /// <summary>
    /// 商户退款请求订单号
    /// <remarks>
    /// 单号唯一，不可重复。生成规则：终端号+流水号，最长32位
    /// </remarks>
    /// </summary>
    [JsonPropertyName("refundTradeId")]
    public string RefundTradeId { get; set; }
    
    /// <summary>
    /// 退款金额
    /// <remarks>
    /// 可以退款金额(确认退款以此金额为准)
    /// </remarks>
    /// </summary>
    [JsonPropertyName("refundAmount")]
    public string RefundAmount { get; set; }
    
    /// <summary>
    /// 分账申请退款结果
    /// </summary>
    [JsonPropertyName("refundSplitResultList")]
    public RefundSplitResultList RefundSplitResultList { get; set; }

}