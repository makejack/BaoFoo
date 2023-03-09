using System.Text.Json.Serialization;
using Lin.Pay.BaoFoo.Attributes;
using Lin.Pay.BaoFoo.Responses;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 个人提现
/// </summary>
public class WithdrawRequest :AbstractRequest,IRequest<DefaultResponse>
{
    
    /// <summary>
    /// 商户订单号
    /// <remarks>
    /// 单号唯一，不可重复。生成规则：终端号+流水号，最长32位
    /// </remarks>
    /// </summary>
    [JsonPropertyName("outOrderNo")]
    public string OutOrderNo { get; set; }

    /// <summary>
    /// 提现金额
    /// <remarks>
    /// 单位：分
    /// </remarks>
    /// </summary>
    [JsonPropertyName("amount")]
    public string Amount { get; set; }

    /// <summary>
    /// 银行卡协议号
    /// </summary>
    [Encrypt]
    [JsonPropertyName("agreementNo")]
    public string AgreementNo { get; set; }

    /// <summary>
    /// 通知地址
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
        return "orgNo|merchantNo|terminalNo|loginNo|requestDate|outOrderNo|amount|agreementNo";
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