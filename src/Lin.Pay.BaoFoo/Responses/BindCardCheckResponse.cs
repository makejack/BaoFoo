using System.Text.Json.Serialization;

namespace Lin.Pay.BaoFoo.Responses;

/// <summary>
/// 确认绑卡响应
/// </summary>
public class BindCardCheckResponse
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("requestNo")]
    public string RequestNo { get; set; }
    /// <summary>
    /// 设置密码URL
    /// <remarks>
    /// 确认绑卡成功且未设置密码，则返回设置支付密码URL（有效期10min）,已设置密码则返回null
    /// </remarks>
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }
}