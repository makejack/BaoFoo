using System.Text.Json.Serialization;
using Lin.Pay.BaoFoo.Responses;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 确认绑卡
/// </summary>
public class BindCardCheckRequest : AbstractRequest, IRequest<BaseResponse<BindCardCheckResponse>>
{
    /// <summary>
    /// 预绑卡关联号
    /// <remarks>
    /// 由第一步：获取短信验证码接口返回
    /// </remarks>
    /// </summary>
    [JsonPropertyName("requestNo")]
    public string RequestNo { get; set; }

    /// <summary>
    /// 短信验证码
    /// </summary>
    [JsonPropertyName("verifyCode")]
    public string VerifyCode { get; set; }

    #region Methods

    
    /// <summary>
    /// 获取地址
    /// </summary>
    /// <returns></returns>
    public string GetUrl(string param = null)
    {
        return $"{HostUrl}cust/v3.0.0/bindCardCheck";
    }

    public override string GetSignFieldString()
    {
        return "orgNo|merchantNo|terminalNo|loginNo|requestDate|requestNo|verifyCode";
    }

    public string PrimaryHandler(BaoFooOptions options)
    {
       return PrimaryHandler(this, options);
    }
    

    #endregion
}