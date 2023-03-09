using System.Text.Json.Serialization;
using Lin.Pay.BaoFoo.Attributes;
using Lin.Pay.BaoFoo.Responses;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 个人开户
/// </summary>
public class OpenAccountRequest : AbstractRequest, IRequest<DefaultResponse>
{
    /// <summary>
    /// 请求流水号
    /// </summary>
    [JsonPropertyName("requestNo")]
    public string RequestNo { get; set; }

    /// <summary>
    /// 客户姓名
    /// <remarks>
    /// 敏感数据请加密
    /// </remarks>
    /// </summary>
    [Encrypt]
    [JsonPropertyName("customerName")]
    public string CustomerName { get; set; }

    /// <summary>
    /// 身份证号
    /// <remarks>
    /// 敏感数据请加密
    /// </remarks>
    /// </summary>
    [Encrypt]
    [JsonPropertyName("certificateNo")]
    public string CertificateNo { get; set; }

    /// <summary>
    /// 身份证头像面(选填)
    /// <remarks>
    /// 图片Base64格式(不要带有前缀，如data:image/jpeg;base64,只需要base64后的数据)，要求base64编码后大小不超过4M
    /// </remarks>
    /// </summary>
    [JsonPropertyName("base64imageFront")]
    public string Base64ImageFront { get; set; }

    /// <summary>
    /// 身份证国徽面(选填)
    /// <remarks>
    /// 图片Base64格式(不要带有前缀，如data:image/jpeg;base64,只需要base64后的数据)，要求base64编码后大小不超过4M
    /// </remarks>
    /// </summary>
    [JsonPropertyName("base64imageBack")]
    public string Base64ImageBack { get; set; }

    /// <summary>
    /// 文件编号(某条件成立时必须填写的属性)
    /// <remarks>
    /// 上传文件返回的文件编号
    /// </remarks>
    /// </summary>
    [JsonPropertyName("fileNo")]
    public string FileNo { get; set; }

    #region Methods

    /// <summary>
    /// 获取请求地址
    /// </summary>
    /// <returns></returns>
    public string GetUrl(string param = null)
    {
        return $"{HostUrl}cust/v3.0.0/openAccount";
    }

    /// <summary>
    /// 获取签名数据
    /// </summary>
    /// <returns></returns>
    public override string GetSignFieldString()
    {
        return "orgNo|merchantNo|terminalNo|loginNo|requestDate|customerName|certificateNo";
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