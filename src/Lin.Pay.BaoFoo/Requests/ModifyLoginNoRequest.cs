using System.Text.Json.Serialization;
using Lin.Pay.BaoFoo.Responses;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 客户登录号变更
/// </summary>
public class ModifyLoginNoRequest :AbstractRequest,IRequest<BooleanResponse>
{
    
    /// <summary>
    /// 原登录号
    /// </summary>
    [JsonPropertyName("origLoginNo")]
    public string OrigLoginNo { get; set; }

    #region Methods

    
    /// <summary>
    /// 获取地址
    /// </summary>
    /// <returns></returns>
    public string GetUrl(bool debug, string param = null)
    {
        return $"{GetHost(debug)}cust/v3.0.0/modifyLoginNo";
    }

    public override string GetSignFieldString()
    {
        return "orgNo|merchantNo|terminalNo|requestDate|loginNo|origLoginNo";
    }

    public string PrimaryHandler(BaoFooOptions options)
    {
        return PrimaryHandler(this, options);
    }
    

    #endregion
}