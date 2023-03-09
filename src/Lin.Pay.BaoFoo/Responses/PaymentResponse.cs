using System.Text.Json.Serialization;

namespace Lin.Pay.BaoFoo.Responses;

/// <summary>
/// 支付结果
/// </summary>
public class PaymentResponse
{
    
    /// <summary>
    /// 支付唤醒参数
    /// </summary>
    [JsonPropertyName("body")]
    public string Body { get; set; }

    /// <summary>
    /// 渠道交易号
    /// </summary>
    [JsonPropertyName("transactionId")]
    public string TransactionId { get; set; }

}