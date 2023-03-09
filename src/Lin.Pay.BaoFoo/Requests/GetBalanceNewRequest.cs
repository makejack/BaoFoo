using System.Text.Json.Serialization;
using Lin.Pay.BaoFoo.Responses;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 账户余额查询
/// </summary>
public class GetBalanceNewRequest : AbstractRequest, IRequest<DefaultResponse>
{
    /// <summary>
    /// 账户类型
    /// </summary>
    [JsonPropertyName("accountType")]
    public string AccountType { get; set; } = "BALANCE";

    #region Methods

    /// <summary>
    /// 获取地址
    /// </summary>
    /// <returns></returns>
    public  string GetUrl(string param = null)
    {
        return $"{HostUrl}wallet/v3.0.0/getBalanceNew";
    }

    /// <summary>
    /// 获取签名数据
    /// </summary>
    /// <returns></returns>
    public override string GetSignFieldString()
    {
        return "orgNo|merchantNo|terminalNo|loginNo|requestDate|accountType";
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