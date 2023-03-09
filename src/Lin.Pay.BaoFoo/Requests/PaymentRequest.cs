using System.Text.Json.Serialization;
using Lin.Pay.BaoFoo.Attributes;
using Lin.Pay.BaoFoo.Domain;
using Lin.Pay.BaoFoo.Responses;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 聚合支付
/// </summary>
public class PaymentRequest : AbstractRequest, IRequest<DecryptResponse<PaymentResponse>>
{
    /// <summary>
    /// 唤起类型
    /// <remarks>
    /// 类型：PAYMENT_SPLIT
    /// </remarks>
    /// </summary>
    [JsonPropertyName("callType")]
    public string CallType { get; set; } = "PAYMENT_SPLIT";

    /// <summary>
    /// 支付参数
    /// <remarks>
    /// 参考下表dataContent支付参数域
    /// </remarks>
    /// </summary>
    [JsonSerialize]
    [JsonPropertyName("dataContent")]
    public PaymentDataContent DataContent { get; set; }

    /// <summary>
    /// 支付用户id(某条件成立时必须填写的属性)
    /// <remarks>
    /// 1.微信支付(公众号、小程序)需填公众号授权获取微信用户openid
    /// 2.支付宝支付(生活号、小程序)需填生活号授权获取支付宝用户userid
    /// </remarks>
    /// </summary>
    [JsonPropertyName("chanalId")]
    public string ChanalId { get; set; }

    /// <summary>
    /// 商户识别码(某条件成立时必须填写的属性)
    /// <remarks>
    /// 通过宝付报备完成后提供
    /// </remarks>
    /// </summary>
    [JsonPropertyName("simId")]
    public string SimId { get; set; }

    /// <summary>
    /// 应用id(某条件成立时必须填写的属性)
    /// <remarks>
    /// 提前提供给宝付报备完成后才可以使用
    /// </remarks>
    /// </summary>
    [JsonPropertyName("appId")]
    public string AppId { get; set; }

    /// <summary>
    /// 禁止贷记卡支付(选填)
    /// <remarks>
    /// 1：禁止; 0：不禁止,不传默认为0
    /// </remarks>
    /// </summary>
    [JsonPropertyName("forbidCredit")]
    public string ForbidCredit { get; set; }

    #region Methods

    /// <summary>
    /// 获取地址
    /// </summary>
    /// <returns></returns>
    public string GetUrl(string param = null)
    {
        return $"{HostUrl}trade/v3.0.0/profitShareRefundApply";
    }

    /// <summary>
    /// 获取签名数据
    /// </summary>
    /// <returns></returns>
    public override string GetSignFieldString()
    {
        return "orgNo|merchantNo|terminalNo|callType|loginNo|requestDate|dataContent";
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