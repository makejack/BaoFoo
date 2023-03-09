using System.Text.Json.Serialization;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 开户结果通知
/// </summary>
public class OpenAccountNotifyRequest : NotifyRequest
{
    
    /// <summary>
    /// 签名数据
    /// <remarks>
    /// 请求签名数据，
    /// </remarks>
    /// </summary>
    [JsonPropertyName("contractNo")]
    public string ContractNo { get; set; }

    #region Methods

    
    public override string GetSignFieldString()
    {
        return
            "orgNo|merchantNo|terminalNo|contractNo|loginNo";
    }

    #endregion
}