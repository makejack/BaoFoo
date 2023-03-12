using System.Text.Json;
using System.Text.Json.Serialization;
using Lin.Pay.BaoFoo.Responses;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 客户信息查询
/// </summary>
public class QueryCustomerInfoRequest : AbstractRequest, IRequest<ObjResponse<QueryCustomerInfoResponse>>
{
    /// <summary>
    /// 客户类型
    /// <remarks>
    /// PERSON-个人
    /// MERCHANT-企业商户
    /// EMPLOYER-个体商户
    /// </remarks>
    /// </summary>
    [JsonPropertyName("customerType")]
    public string CustomerType { get; set; }

    /// <summary>
    /// 请求流水号
    /// </summary>
    [JsonPropertyName("requestNo")]
    public string RequestNo { get; set; }

    #region Methods

    /// <summary>
    /// 获取地址
    /// </summary>
    /// <returns></returns>
    public string GetUrl(bool debug, string param = null)
    {
        return $"{GetHost(debug)}cust/v2.0.0/queryCustomerInfo";
    }

    public override string GetSignFieldString()
    {
        return "orgNo|merchantNo|terminalNo|loginNo|requestNo";
    }

    public string PrimaryHandler(BaoFooOptions options)
    {
        return PrimaryHandler(this, options);
    }

    #endregion
}