using System.Text.Json.Serialization;
using Lin.Pay.BaoFoo.Attributes;
using Lin.Pay.BaoFoo.Responses;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 个人身份证上传
/// </summary>
public class RealNameRequest : AbstractRequest, IRequest<BaseResponse<RealNameResponse>>
{
    /// <summary>
    /// 请求流水号
    /// </summary>
    [JsonPropertyName("requestNo")]
    public string RequestNo { get; set; }

    /// <summary>
    /// 客户姓名
    /// <remarks>
    /// 加密传输
    /// </remarks>
    /// </summary>
    [Encrypt]
    [JsonPropertyName("customerName")]
    public string CustomerName { get; set; }

    /// <summary>
    /// 身份证号
    /// <remarks>
    /// 加密传输
    /// </remarks>
    /// </summary>
    [Encrypt]
    [JsonPropertyName("certificateNo")]
    public string CertificateNo { get; set; }

    /// <summary>
    /// 身份证头像面
    /// <remarks>
    /// 图片Base64格式(不要带有前缀，如data:image/jpeg;base64,只需要base64后的数据)，最大支持5M
    /// </remarks>
    /// </summary>
    [JsonPropertyName("base64imageFront")]
    public string Base64ImageFront { get; set; }

    /// <summary>
    /// 身份证国徽面
    /// <remarks>
    /// 图片Base64格式(不要带有前缀，如data:image/jpeg;base64,只需要base64后的数据)，最大支持5M
    /// </remarks>
    /// </summary>
    [JsonPropertyName("base64imageBack")]
    public string Base64ImageBack { get; set; }

    #region Methods

    /// <summary>
    /// 获取地址
    /// </summary>
    /// <returns></returns>
    public string GetUrl(string param = null)
    {
        return $"{HostUrl}cust/v3.0.0/realName";
    }

    /// <summary>
    /// 获取签名数据
    /// </summary>
    /// <returns></returns>
    public override string GetSignFieldString()
    {
        return "orgNo|merchantNo|terminalNo|loginNo|requestDate|customerName";
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