using System.Text.Json.Serialization;
using Lin.Pay.BaoFoo.Responses;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 获取已绑定卡信息
/// </summary>
public class FindBindBankCardsRequest : AbstractRequest, IRequest<BaseResponse<List<FindBindBankCardsResponse>>>
{
    /// <summary>
    /// 查询类型
    /// <remarks>
    /// 查询类型：默认填写：BASE_LIST
    /// </remarks>
    /// </summary>
    [JsonPropertyName("tradeType")]
    public string TradeType { get; set; } = "BASE_LIST";

    /// <summary>
    /// 客户账户号(选填)
    /// </summary>
    [JsonPropertyName("contractNo")]
    public string ContractNo { get; set; }

    #region Methods

    /// <summary>
    /// 获取地址
    /// </summary>
    /// <returns></returns>
    public string GetUrl(bool debug, string param = null)
    {
        return $"{GetHost(debug)}cust/v2.0.0/findBindBankCards";
    }

    /// <summary>
    /// 获取签名数据
    /// </summary>
    /// <returns></returns>
    public override string GetSignFieldString()
    {
        return "orgNo|merchantNo|terminalNo|loginNo|contractNo";
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