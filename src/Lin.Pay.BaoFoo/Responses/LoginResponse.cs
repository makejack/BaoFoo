using System.Text.Json.Serialization;

namespace Lin.Pay.BaoFoo.Responses;

/// <summary>
/// 登录响应
/// </summary>
public class LoginResponse : BaseResponse
{
    /// <summary>
    /// 接口返回错误码
    /// <remarks>
    /// 成功时为：SUCCESS
    /// </remarks>
    /// </summary>
    [JsonPropertyName("retCode")]
    public string RetCode { get; set; }
    /// <summary>
    /// 返回描述
    /// <remarks>
    /// 当success为false时不为空
    /// </remarks>
    /// </summary>
    [JsonPropertyName("retMsg")]
    public string RetMsg { get; set; }
    /// <summary>
    /// H5跳转地址
    /// <remarks>
    /// 详细地址，有效期10min
    /// </remarks>
    /// </summary>
    [JsonPropertyName("redirectUrl")]
    public string RedirectUrl { get; set; }

}