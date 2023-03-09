using System.Text.Json.Serialization;

namespace Lin.Pay.BaoFoo.Domain;

/// <summary>
/// 聚合支付 支付参数域
/// </summary>
public class PaymentDataContent
{
    
    /// <summary>
    /// 商品名称
    /// </summary>
    [JsonPropertyName("goodsName")]
    public string GoodsName { get; set; }

    /// <summary>
    /// 订单金额
    /// <remarks>
    /// 单位：分
    /// </remarks>
    /// </summary>
    [JsonPropertyName("amount")]
    public string Amount { get; set; }

    /// <summary>
    /// 商户订单号
    /// <remarks>
    /// 单号唯一。生成规则：终端号+流水号，最长32位
    /// </remarks>
    /// </summary>
    [JsonPropertyName("outOrderNo")]
    public string OutOrderNo { get; set; }

    /// <summary>
    /// 回调通知地址(某条件成立时必须填写的属性)
    /// <remarks>
    /// 通知商户交易结果
    /// </remarks>
    /// </summary>
    [JsonPropertyName("notifyUrl")]
    public string NotifyUrl { get; set; }

    /// <summary>
    /// 分账详情
    /// <remarks>
    /// 类型：PAYMENT_SPLIT
    /// </remarks>
    /// </summary>
    [JsonPropertyName("splitInfoList")]
    public PaymentSplitInfoList SplitInfoList { get; set; }

    /// <summary>
    /// 订单支付有效时间(某条件成立时必须填写的属性)
    /// <remarks>
    /// 订单支付有效时间（格式:yyyyMMddHHmmss）
    /// </remarks>
    /// </summary>
    [JsonPropertyName("expireDate")]
    public string ExpireDate { get; set; }

    /// <summary>
    /// 手续费承担方(某条件成立时必须填写的属性)
    /// <remarks>
    /// 1.承担方必须为交易参与方,传空或不传时默认从平台扣除
    /// 2.分账金额必须>=手续费金额
    /// 3.子商户传客户号,平台商户传商户号.如果是平台商户号,手续费从基本户出
    /// </remarks>
    /// </summary>
    [JsonPropertyName("feeMemberId")]
    public string FeeMemberId { get; set; }

    /// <summary>
    /// 支付类型
    /// <remarks>
    /// 参考PaidTypes支付类型
    /// </remarks>
    /// </summary>
    [JsonPropertyName("paidType")]
    public string PaidType { get; set; }

    /// <summary>
    /// 订单担保有效周期
    /// <remarks>
    /// 担保到期日（格式:yyyyMMdd）
    /// </remarks>
    /// </summary>
    [JsonPropertyName("validDate")]
    public string ValidDate { get; set; }

    /// <summary>
    /// 备注(选填)(maxLength:128)
    /// <remarks>
    /// 备注信息，在查询API和支付通知中原样返回，可作为自定义参数使用
    /// </remarks>
    /// </summary>
    [JsonPropertyName("remark")]
    public string Remark { get; set; }

}