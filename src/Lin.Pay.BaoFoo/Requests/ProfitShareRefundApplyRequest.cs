using System.Text.Json;
using System.Text.Json.Serialization;
using Lin.Pay.BaoFoo.Attributes;
using Lin.Pay.BaoFoo.Domain;
using Lin.Pay.BaoFoo.Responses;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 退款申请
/// </summary>
public class ProfitShareRefundApplyRequest : AbstractRequest,IRequest<DefaultResponse>
{
    
    /// <summary>
    /// 退款请求订单号
    /// <remarks>
    /// 单号唯一，不可重复。生成规则：终端号+流水号，最长32位
    /// </remarks>
    /// </summary>
    [JsonPropertyName("refundTradeId")]
    public string RefundTradeId { get; set; }

    /// <summary>
    /// 退款交易类型
    /// <remarks>
    /// REFUND_APPLY
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
    /// 单位：分
    /// </remarks>
    /// </summary>
    [JsonPropertyName("refundAmount")]
    public string RefundAmount { get; set; }

    /// <summary>
    /// 退款原因
    /// <remarks>
    /// 需填写退款原因
    /// </remarks>
    /// </summary>
    [JsonPropertyName("refundReason")]
    public string RefundReason { get; set; }

    /// <summary>
    /// 分账退款详情
    /// </summary>
    [JsonSerialize]
    [JsonPropertyName("refundSplitInfoList")]
    public RefundSplitInfoList RefundSplitInfoList { get; set; }
    
    /// <summary>
    /// 备注(选填)
    /// </summary>
    [JsonPropertyName("remark")]
    public string Remark { get; set; }

    #region Methods

    /// <summary>
    /// 获取地址
    /// </summary>
    /// <returns></returns>
    public string GetUrl(bool debug, string param = null)
    {
        return $"{GetHost(debug)}wallet/v3.0.0/payment";
    }

    /// <summary>
    /// 获取签名数据
    /// </summary>
    /// <returns></returns>
    public override string GetSignFieldString()
    {
        return "orgNo|merchantNo|terminalNo|loginNo|requestDate|refundTradeId|orgTradeId|refundAmount|refundSplitInfoList";
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