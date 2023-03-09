using System.Text.Json.Serialization;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 退款通知
/// </summary>
public class ReturnNotifyRequest : NotifyRequest
{
    
    /// <summary>
    /// 宝付退款订单号
    /// </summary>
    [JsonPropertyName("refundOrderId")]
    public string RefundOrderId { get; set; }

    /// <summary>
    /// 退款商户请求订单号	
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
    /// F-失败
    /// S-成功
    /// I-初始
    /// P-处理中
    /// </remarks>
    /// </summary>
    [JsonPropertyName("refundStatus")]
    public string RefundStatus { get; set; }

    /// <summary>
    /// 退款完成时间
    /// <remarks>
    /// 退款状态是S，才有值；
    /// 其他状态是空字符串
    /// </remarks>
    /// </summary>
    [JsonPropertyName("refundSuccTime")]
    public string RefundSuccTime { get; set; }

    /// <summary>
    /// 原始订单支付方式
    /// <remarks>
    /// CARD-卡
    /// BALANCE-余额
    /// </remarks>
    /// </summary>
    [JsonPropertyName("refundType")]
    public string RefundType { get; set; }

    /// <summary>
    /// 失败原因
    /// </summary>
    [JsonPropertyName("errorMsg")]
    public string ErrorMsg { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [JsonPropertyName("remark")]
    public string Remark { get; set; }

    #region Methods
    
    public override string GetSignFieldString()
    {
        return "orgNo|merchantNo|terminalNo|refundOrderId|refundTradeId|refundMoney|refundStatus|refundSuccTime|refundType|errorMsg";
    }

    #endregion
}