using System.Text.Json.Serialization;

namespace Lin.Pay.BaoFoo.Responses;

/// <summary>
/// 获取短信验证码响应
/// </summary>
public class BindCardResponse
{
    /// <summary>
    /// 预绑卡关联号
    /// <remarks>
    /// 预绑卡成功，返回关联号，第二步时以此关联号进行操作关联
    /// </remarks>
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