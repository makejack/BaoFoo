using System.Text.Json.Serialization;
using Lin.Pay.BaoFoo.Responses;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 退款撤销
/// </summary>
public class ProfitShareRefundCancelRequest : AbstractRequest, IRequest<BooleanResponse>
{
    /// <summary>
    /// 退款请求订单号
    /// <remarks>
    /// 与退款申请中的退款请求订单号一致
    /// </remarks>
    /// </summary>
    [JsonPropertyName("refundTradeId")]
    public string RefundTradeId { get; set; }

    /// <summary>
    /// 退款交易类型
    /// <remarks>
    /// REFUND_CANCEL
    /// </remarks>
    /// </summary>
    [JsonPropertyName("refundTradeType")]
    public string RefundTradeType { get; set; }

    #region Methods

    /// <summary>
    /// 获取地址
    /// </summary>
    /// <returns></returns>
    public string GetUrl(string param = null)
    {
        return $"{HostUrl}trade/v3.0.0/profitShareRefundCancel";
    }

    /// <summary>
    /// 获取签名数据
    /// </summary>
    /// <returns></returns>
    public override string GetSignFieldString()
    {
        return "orgNo|merchantNo|terminalNo|loginNo|requestDate|refundTradeId";
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