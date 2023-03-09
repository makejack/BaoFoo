using System.Text.Json.Serialization;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 支付结果通知
/// </summary>
public class PaymentNotifyRequest : NotifyRequest
{
    /// <summary>
    /// 订单状态
    /// <remarks>
    /// INIT-初始化
    /// SUCCESS-成功
    /// FAILED-失败
    /// PROCESS-处理中
    /// </remarks>
    /// </summary>
    [JsonPropertyName("orderStatus")]
    public string OrderStatus { get; set; }

    /// <summary>
    /// 商户订单号
    /// </summary>
    [JsonPropertyName("tradeId")]
    public string TradeId { get; set; }

    /// <summary>
    /// 支付方式
    /// <remarks>
    /// CARD-卡
    /// BALANCE-余额
    /// </remarks>
    /// </summary>
    [JsonPropertyName("paidType")]
    public string PaidType { get; set; }

    /// <summary>
    /// 订单金额
    /// <remarks>
    /// 单位: 分
    /// </remarks>
    /// </summary>
    [JsonPropertyName("orderMoney")]
    public string OrderMoney { get; set; }

    /// <summary>
    /// 订单完成时间
    /// <remarks>
    /// 
    /// </remarks>
    /// </summary>
    [JsonPropertyName("finishTime")]
    public string FinishTime { get; set; }

    /// <summary>
    /// 请求流水号
    /// <remarks>
    /// 
    /// </remarks>
    /// </summary>
    [JsonPropertyName("orderId")]
    public string OrderId { get; set; }

    /// <summary>
    /// 错误信息
    /// <remarks>
    /// </remarks>
    /// </summary>
    [JsonPropertyName("errorMsg")]
    public string ErrorMsg { get; set; }

    /// <summary>
    /// 渠道交易号
    /// <remarks>
    /// 
    /// </remarks>
    /// </summary>
    [JsonPropertyName("transactionId")]
    public string TransactionId { get; set; }

    /// <summary>
    /// 第三方交易号
    /// <remarks>
    /// 微信/支付宝交易号
    /// </remarks>
    /// </summary>
    [JsonPropertyName("outTransactionId")]
    public string OutTransactionId { get; set; }

    /// <summary>
    /// 备注
    /// <remarks>
    /// 商户请求数据，原样返回
    /// </remarks>
    /// </summary>
    [JsonPropertyName("remark")]
    public string Remark { get; set; }

    #region Methods

    
    public override string GetSignFieldString()
    {
        return
            "orgNo|merchantNo|terminalNo|orderStatus|tradeId|paidType|orderMoney|loginId|finishTime|orderId|errorMsg";
    }

    #endregion
}