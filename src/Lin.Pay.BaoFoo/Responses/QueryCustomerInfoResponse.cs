using System.Text.Json.Serialization;

namespace Lin.Pay.BaoFoo.Responses;

/// <summary>
/// 客户信息查询结果响应
/// </summary>
public class QueryCustomerInfoResponse
{
    
    /// <summary>
    /// 机构号/平台号
    /// </summary>
    [JsonPropertyName("orgNo")]
    public string OrgNo { get; set; }

    /// <summary>
    /// 用户登录号
    /// </summary>
    [JsonPropertyName("loginNo")]
    public string LoginNo { get; set; }

    /// <summary>
    /// 客户账户号
    /// <remarks>
    /// PERSON-个人
    /// MERCHANT-企业商户
    /// EMPLOYER-个体商户
    /// </remarks>
    /// </summary>
    [JsonPropertyName("contractNo")]
    public string ContractNo { get; set; }

    /// <summary>
    /// 机构号/平台号
    /// </summary>
    [JsonPropertyName("platformNo")]
    public string PlatformNo { get; set; }

    /// <summary>
    /// 用户登录号
    /// <remarks>
    /// PERSON-个人
    /// MERCHANT-企业商户
    /// EMPLOYER-个体商户
    /// </remarks>
    /// </summary>
    [JsonPropertyName("loginMobile")]
    public string LoginMobile { get; set; }

    /// <summary>
    /// 实名标识
    /// <remarks>
    /// N-未实名;
    /// X-上传身份证开户；
    /// O-身份证开户未上传照片；
    /// S-身份证开户且绑卡，未上传身份证照片；
    /// Y-身份证开户且已绑卡
    /// </remarks>
    /// </summary>
    [JsonPropertyName("realNameFlag")]
    public string RealNameFlag { get; set; }

    /// <summary>
    /// 绑卡标识/客户注册时间
    /// <remarks>
    /// 绑卡标识 Y-已激活 N-未绑卡
    /// 客户注册时间 yyyyMMddHHmmss
    /// </remarks>
    /// </summary>
    [JsonPropertyName("bindCardFlag")]
    public string BindCardFlag { get; set; }

    /// <summary>
    /// 支付密码设置标识
    /// <remarks>
    /// Y-已设置
    /// N-未设置
    /// </remarks>
    /// </summary>
    [JsonPropertyName("setPwdFlag")]
    public string SetPwdFlag { get; set; }

    /// <summary>
    /// 操作员状态
    /// <remarks>
    /// NORMAL-正常
    /// PAUSE-暂停
    /// FREEZE-冻结
    /// CLOSE-销户
    /// LOCK-锁定
    /// INACTIVATED-未激活
    /// TOBEACTIVATED-待激活
    /// FORBID-禁止登陆
    /// </remarks>
    /// </summary>
    [JsonPropertyName("operatorStatus")]
    public string OperatorStatus { get; set; }

    /// <summary>
    /// 开户人姓名/客户账户名
    /// </summary>
    [JsonPropertyName("customerName")]
    public string CustomerName { get; set; }

    /// <summary>
    /// 客户注册邮箱
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// 客户绑定手机
    /// </summary>
    [JsonPropertyName("mobile")]
    public string Mobile { get; set; }

    /// <summary>
    /// 身份证
    /// </summary>
    [JsonPropertyName("certificateNo")]
    public string CertificateNo { get; set; }

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
    /// 申请编号
    /// </summary>
    [JsonPropertyName("applyNo")]
    public string ApplyNo { get; set; }

}