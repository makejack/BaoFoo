using System.Text.Json.Serialization;

namespace Lin.Pay.BaoFoo.Responses;

/// <summary>
/// 获取已绑定卡信息响应
/// </summary>
public class FindBindBankCardsResponse
{
    /// <summary>
    /// 签约协议号
    /// </summary>
    [JsonPropertyName("agreementNo")]
    public string AgreementNo { get; set; }

    /// <summary>
    /// 持卡人姓名
    /// </summary>
    [JsonPropertyName("cardUserName")]
    public string CardUserName { get; set; }

    /// <summary>
    /// 卡号后4位
    /// </summary>
    [JsonPropertyName("lastCardNo")]
    public string LastCardNo { get; set; }

    /// <summary>
    /// 银行预留手机号
    /// </summary>
    [JsonPropertyName("bankMobile")]
    public string BankMobile { get; set; }

    /// <summary>
    /// 银行编号
    /// </summary>
    [JsonPropertyName("bankCode")]
    public string BankCode { get; set; }

    /// <summary>
    /// 银行名称
    /// </summary>
    [JsonPropertyName("bankName")]
    public string BankName { get; set; }

    /// <summary>
    /// 银行卡类型
    /// </summary>
    [JsonPropertyName("cardType	")]
    public string CardType { get; set; }

    /// <summary>
    /// 银行联行号
    /// </summary>
    [JsonPropertyName("cnapsCode")]
    public string CnapsCode { get; set; }

    /// <summary>
    /// 是否对公
    /// </summary>
    [JsonPropertyName("publicFlag")]
    public string PublicFlag { get; set; }

    /// <summary>
    /// 还款日期
    /// </summary>
    [JsonPropertyName("repaymentDate")]
    public string RepaymentDate { get; set; }

    /// <summary>
    /// 主卡标识（默认的
    /// </summary>
    [JsonPropertyName("mainFlag")]
    public string MainFlag { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary>
    /// 可用标识
    /// </summary>
    [JsonPropertyName("avaFlag")]
    public string AvaFlag { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [JsonPropertyName("remark")]
    public string Remark { get; set; }
}