using System.Text.Json.Serialization;

namespace Lin.Pay.BaoFoo.Responses;

/// <summary>
/// 退款确认响应
/// </summary>
public class ProfitShareRefundConfirmResponse
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
    /// </summary>
    [JsonPropertyName("refundTradeId")]
    public string RefundTradeId { get; set; }

    /// <summary>
    /// 退款金额
    /// </summary>
    [JsonPropertyName("refundMoney")]
    public string RefundMoney { get; set; }

    /// <summary>
    /// 退款状态
    /// <remarks>
    /// P-受理中
    /// F-失败
    /// S-成功
    /// </remarks>
    /// </summary>
    [JsonPropertyName("refundStatus")]
    public string RefundStatus { get; set; }

    /// <summary>
    /// 退款方式
    /// <remarks>
    /// 原路返回
    /// </remarks>
    /// </summary>
    [JsonPropertyName("refundType")]
    public string RefundType { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }
}