namespace Lin.Pay.BaoFoo;

/// <summary>
/// 宝付选项
/// </summary>
public class BaoFooOptions
{
    /// <summary>
    /// 机构号/平台号
    /// <remarks>
    /// 宝付提供（同商户号）
    /// </remarks>
    /// </summary>
    public string OrgNo { get; set; }

    /// <summary>
    /// 商户号
    /// <remarks>
    /// 宝付提供
    /// </remarks>
    /// </summary>
    public string MerchantNo { get; set; }

    /// <summary>
    /// 终端号
    /// <remarks>
    /// 宝付提供
    /// </remarks>
    /// </summary>
    public string TerminalNo { get; set; }

    /// <summary>
    /// 公钥证书路径
    /// </summary>
    public string CerCertificate { get; set; }

    /// <summary>
    /// 私钥证书路径
    /// </summary>
    public string PfxCertificate { get; set; }

    /// <summary>
    /// 证书密码
    /// </summary>
    public string Password { get; set; }
}