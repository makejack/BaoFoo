using System.Text;
using System.Text.Json.Serialization;
using Lin.Pay.BaoFoo.Responses;
using Lin.Pay.BaoFoo.Utils;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 个人支付密码修改/设置
/// </summary>
public class LoginRequest : AbstractRequest, IRequest<LoginResponse>
{
    /// <summary>
    /// 唤起类型
    /// <remarks>
    /// 开户/注册类型，默认：PWDFORGET
    /// 密码修改，默认：PWDMODIFY
    /// </remarks>
    /// </summary>
    [JsonPropertyName("callType")]
    public string CallType { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("dataContent")]
    public string DataContent { get; set; } = "";

    #region Methods

    /// <summary>
    /// 获取地址
    /// </summary>
    /// <returns></returns>
    public string GetUrl(bool debug, string param = null)
    {
        var url = $"{GetHost(debug)}wallet/v3.0.0/login?";
        if (!string.IsNullOrEmpty(param))
        {
            url += param;
        }
        return url;
    }

    public override HttpContent GetHttpContent(string content)
    {
        // var mediaType = "application/x-www-form-urlencoded";
        
        var bytes = Encoding.UTF8.GetBytes(content);
        var stream = new MemoryStream(bytes);
        var httpContent = new StreamContent(stream);
        return httpContent;
    }

    public override string GetSignFieldString()
    {
        return "orgNo|merchantNo|terminalNo|callType|loginNo|requestDate|dataContent";
    }

    public string PrimaryHandler(BaoFooOptions options)
    {
        var content = PrimaryHandler(this, options);
        return ToolsHepler.JsonToUrlEncode(content);
    }

    #endregion
}