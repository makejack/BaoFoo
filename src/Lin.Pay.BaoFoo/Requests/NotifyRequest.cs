using System.Text.Json.Serialization;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 通知结果
/// </summary>
public abstract class NotifyRequest :ISignature
{
    /// <summary>
    /// 机构号/平台号
    /// <remarks>
    /// 宝付提供（同商户号）
    /// </remarks>
    /// </summary>
    [JsonPropertyName("orgNo")]
    public string OrgNo { get; set; }

    /// <summary>
    /// 商户号
    /// <remarks>
    /// 宝付提供
    /// </remarks>
    /// </summary>
    [JsonPropertyName("merchantNo")]
    public string MerchantNo { get; set; }

    /// <summary>
    /// 终端号
    /// <remarks>
    /// 宝付提供
    /// </remarks>
    /// </summary>
    [JsonPropertyName("terminalNo")]
    public string TerminalNo { get; set; }

    /// <summary>
    /// 登录号
    /// <remarks>
    /// 用户登录注册号，为用户在商户下唯一编号，商户自定义
    /// </remarks>
    /// </summary>
    [JsonPropertyName("loginNo")]
    public string LoginNo { get; set; }
    
    /// <summary>
    /// 签名数据
    /// <remarks>
    /// 请求签名数据，
    /// </remarks>
    /// </summary>
    [JsonPropertyName("signature")]
    public string Signature { get; set; }

    #region MyRegion
    
    public abstract string GetSignFieldString();

    #endregion
}