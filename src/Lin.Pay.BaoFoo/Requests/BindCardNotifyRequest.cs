using System.Text.Json.Serialization;

namespace Lin.Pay.BaoFoo.Requests;

/// <summary>
/// 绑卡结果通知
/// </summary>
public class BindCardNotifyRequest : NotifyRequest 
{
    
    /// <summary>
    /// 客户账户号
    /// </summary>
    [JsonPropertyName("contractNo")]
    public string ContractNo { get; set; }
    
    /// <summary>
    /// 绑卡结果标识
    /// </summary>
    [JsonPropertyName("bindCardFlag")]
    public bool BindCardFlag { get; set; }

    #region Methods

    
    public override string GetSignFieldString()
    {
        return "orgNo|merchantNo|terminalNo|contractNo|loginNo|bindCardFlag";
    }

    #endregion
}