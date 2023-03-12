using System.Text.Json.Serialization;
using Lin.Pay.BaoFoo.Attributes;
using Lin.Pay.BaoFoo.Responses;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 获取短信验证码
/// </summary>
public class BindCardRequest : AbstractRequest, IRequest<BaseResponse<BindCardResponse>>
{
    /// <summary>
    /// 姓名(某条件成立时必须填写的属性)
    /// <remarks>
    /// 当游客身份进行绑卡时(密文传输)，必输
    /// </remarks>
    /// </summary>
    [Encrypt]
    [JsonPropertyName("cardName")]
    public string CardName { get; set; }

    /// <summary>
    /// 身份证(某条件成立时必须填写的属性)
    /// <remarks>
    /// 当游客身份进行绑卡时(密文传输)，必输
    /// </remarks>
    /// </summary>
    [Encrypt]
    [JsonPropertyName("idCard")]
    public string IdCard { get; set; }

    /// <summary>
    /// 银行卡号
    /// <remarks>
    /// 敏感数据请加密
    /// </remarks>
    /// </summary>
    [Encrypt]
    [JsonPropertyName("cardNo")]
    public string CardNo { get; set; }

    /// <summary>
    /// 银行预留手机号
    /// <remarks>
    /// 敏感数据请加密
    /// </remarks>
    /// </summary>
    [Encrypt]
    [JsonPropertyName("bankMobile")]
    public string BankMobile { get; set; }

    /// <summary>
    /// 信用卡有效期
    /// <remarks>YYMM</remarks>
    /// </summary>
    [JsonPropertyName("accountValidDate")]
    public string AccountValidDate { get; set; }

    /// <summary>
    /// 信用卡cvv2
    /// </summary>
    [JsonPropertyName("cvv2")]
    public string Cvv2 { get; set; }

    /// <summary>
    /// 前端回调地址(某条件成立时必须填写的属性)
    /// <remarks>
    /// 前端通知回调-招商银行必填，招商绑卡流程及注意事项
    /// </remarks>
    /// </summary>
    [JsonPropertyName("pageUrl")]
    public string PageUrl { get; set; }

    /// <summary>
    /// 后台通知地址(某条件成立时必须填写的属性)
    /// <remarks>
    /// 通知商户交易结果-招商银行必填通知结果
    /// </remarks>
    /// </summary>
    [JsonPropertyName("notifyUrl")]
    public string NotifyUrl { get; set; }

    #region Methods

    /// <summary>
    /// 获取地址
    /// </summary>
    /// <returns></returns>
    public string GetUrl(bool debug, string param = null)
    {
        return $"{GetHost(debug)}cust/v3.0.0/bindCard";
    }

    /// <summary>
    /// 获取签名数据
    /// </summary>
    /// <returns></returns>
    public override string GetSignFieldString()
    {
        return "orgNo|merchantNo|terminalNo|loginNo|requestDate|cardNo|bankMobile";
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