using System.Text.Json.Serialization;
using Lin.Pay.BaoFoo.Responses;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 退款确认
/// </summary>
public class ProfitShareRefundConfirmRequest : AbstractRequest, IRequest<BaseResponse<ProfitShareRefundConfirmResponse>>
{
    /// <summary>
    /// 退款请求订单号
    /// <remarks>
    /// 与申请订单号一致
    /// </remarks>
    /// </summary>
    [JsonPropertyName("refundTradeId")]
    public string RefundTradeId { get; set; }

    /// <summary>
    /// 退款交易类型
    /// <remarks>
    /// REFUND_CONFIRM
    /// </remarks>
    /// </summary>
    [JsonPropertyName("refundTradeType")]
    public string RefundTradeType { get; set; }

    /// <summary>
    /// 退款原始支付订单号
    /// <remarks>
    /// 原始支付商户订单号
    /// </remarks>
    /// </summary>
    [JsonPropertyName("orgTradeId")]
    public string OrgTradeId { get; set; }

    /// <summary>
    /// 退款总金额
    /// <remarks>
    /// 单位：分，退款申请返回的可退金额
    /// </remarks>
    /// </summary>
    [JsonPropertyName("refundAmount")]
    public string RefundAmount { get; set; }

    /// <summary>
    /// 退款通知地址
    /// </summary>
    [JsonPropertyName("notifyUrl")]
    public string NotifyUrl { get; set; }

    #region Methods

    /// <summary>
    /// 获取地址
    /// </summary>
    /// <returns></returns>
    public string GetUrl(string param = null)
    {
        return $"{HostUrl}trade/v3.0.0/profitShareRefundConfirm";
    }

    /// <summary>
    /// 获取签名数据
    /// </summary>
    /// <returns></returns>
    public override string GetSignFieldString()
    {
        return "orgNo|merchantNo|terminalNo|loginNo|requestDate|refundTradeId|refundAmount";
    }

    /// <summary>
    /// 处理
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public string PrimaryHandler(BaoFooOptions options)
    {
        return PrimaryHandler(this, options);
    }

    #endregion
}