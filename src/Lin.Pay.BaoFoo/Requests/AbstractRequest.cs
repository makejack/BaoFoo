using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Lin.Pay.BaoFoo.Utils;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 基础请求
/// </summary>
public abstract class AbstractRequest : BaseRequest, ISignature
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
    /// 请求日期
    /// <remarks>
    /// 发起请求时的服务器时间yyyyMMddHHmmss
    /// </remarks>
    /// </summary>
    [JsonPropertyName("requestDate")]
    public string RequestDate { get; set; }

#if DEBUG
    /// <summary>
    /// 请求地址
    /// </summary>
    internal const string HostUrl = "https://account.baofoo.com/api/";
#else
    /// <summary>
    /// 请求地址
    /// </summary>
    internal const string HostUrl = "https://bht.mandao.com/api/";
#endif

    /// <summary>
    /// 获取httpContent
    /// </summary>
    /// <returns></returns>
    public virtual HttpContent GetHttpContent(string content)
    {
        var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
        return httpContent;
    }

    /// <summary>
    /// 获取签名数据
    /// </summary>
    /// <returns></returns>
    public abstract string GetSignFieldString();

    /// <summary>
    /// 初始值
    /// </summary>
    /// <param name="options"></param>
    private void Initial(BaoFooOptions options)
    {
        OrgNo = options.OrgNo;
        MerchantNo = options.MerchantNo;
        TerminalNo = options.TerminalNo;
        RequestDate = DateTime.Now.ToString("yyyyMMddHHmmss");
    }

    protected string PrimaryHandler<T>(T data, BaoFooOptions options)
    {
        Initial(options);

        var dic = ToolsHepler.PropertyToDictionary(data, options.CerCertificate);
        var oldSignData = ToolsHepler.VerifyString(GetSignFieldString(), dic);
        // 1.商户对字符串进行Base64编码。
        // 2.商户使用宝付公钥对Base64编码后的字符串进行RSA加密。
        var sign = SignatureHelper.EncryptByRSA(oldSignData, options.PfxCertificate, options.Password);
        dic.Add("signData", sign);

        return JsonSerializer.Serialize(dic);
    }
}