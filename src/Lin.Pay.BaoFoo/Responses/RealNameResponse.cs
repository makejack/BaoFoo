using System.Text.Json.Serialization;

namespace Lin.Pay.BaoFoo.Responses;

/// <summary>
/// 个人身份证上传响应
/// </summary>
public class RealNameResponse
{
    /// <summary>
    /// 认证成功标识
    /// </summary>
    [JsonPropertyName("sucFlag")]
    public string SucFlag { get; set; }

    /// <summary>
    /// 设置支付密码URL
    /// </summary>
    [JsonPropertyName("initPwdUrl")]
    public string InitPwdUrl { get; set; }
}