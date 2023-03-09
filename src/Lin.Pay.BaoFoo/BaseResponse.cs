using System.Text.Json.Serialization;

namespace Lin.Pay.BaoFoo;

/// <summary>
/// 基础响应 字符串结果
/// </summary>
public class BaseResponse
{
    /// <summary>
    /// 错误码
    /// </summary>
    [JsonPropertyName("errorCode")]
    public string ErrorCode { get; set; }

    /// <summary>
    /// 错误描述
    /// </summary>
    [JsonPropertyName("errorMsg")]
    public string ErrorMsg { get; set; }

    /// <summary>
    /// 接口调用成功
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }
}

/// <summary>
/// 基础响应
/// </summary>
/// <typeparam name="TResult"></typeparam>
public class BaseResponse<TResult> : BaseResponse
{
    /// <summary>
    /// 结果域
    /// </summary>
    [JsonPropertyName("result")]
    public TResult Result { get; set; }
}