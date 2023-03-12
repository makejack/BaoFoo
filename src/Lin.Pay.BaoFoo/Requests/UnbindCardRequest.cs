using System.Text.Json.Serialization;
using Lin.Pay.BaoFoo.Responses;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 个人银行卡解约
/// <remarks>
/// true：解绑成功
/// false：解绑失败
/// </remarks>
/// </summary>
public class UnbindCardRequest : AbstractRequest, IRequest<BooleanResponse>
{
    /// <summary>
    /// 请求流水号
    /// <remarks>
    /// 商户唯一 不重复的流水号
    /// </remarks>
    /// </summary>
    [JsonPropertyName("requestNo")]
    public string RequestNo { get; set; }

    /// <summary>
    /// 已绑定卡协议号
    /// <remarks>
    /// 商户查询用户绑定卡时，每张卡对应的唯一协议编号
    /// </remarks>
    /// </summary>
    [JsonPropertyName("agreementNo")]
    public string AgreementNo { get; set; }


    #region Methods

    /// <summary>
    /// 获取地址
    /// </summary>
    /// <returns></returns>
    public string GetUrl(bool debug, string param = null)
    {
        return $"{GetHost(debug)}cust/v3.0.0/unbindCard";
    }

    /// <summary>
    /// 获取签名数据
    /// </summary>
    /// <returns></returns>
    public override string GetSignFieldString()
    {
        return "orgNo|merchantNo|terminalNo|loginNo|requestDate|requestNo|agreementNo";
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