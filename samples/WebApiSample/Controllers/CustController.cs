namespace WebApiSample.Controllers;

/// <summary>
/// 个人注册
/// </summary>
[Route("api/cust")]
public class CustController : ControllerBase
{
    private const string LoginNo = "18312460310";

    private readonly IBaoFooClient _baoFooClient;
    private readonly BaoFooOptions _baoFooOptions;

    public CustController(IBaoFooClient baoFooClient, BaoFooOptions baoFooOptions)
    {
        _baoFooClient = baoFooClient;
        _baoFooOptions = baoFooOptions;
    }

    /// <summary>
    /// 个人实名开户
    /// </summary>
    /// <returns></returns>
    [HttpPost("openaccount")]
    public async Task<IActionResult> OpenAccount()
    {
        var requestNo = DateTime.Now.ToString("yyyyMMddHHmmss");

        var openAccount = new OpenAccountRequest()
        {
            RequestNo = requestNo,
            LoginNo = LoginNo,
            CustomerName = "林成功",
            CertificateNo = "352203199001010000",
            Base64ImageFront = "",
            Base64ImageBack = "",
            FileNo = "",
        };
        var res = await _baoFooClient.SendAsync(openAccount, _baoFooOptions);
        //登录号 18312460310 客户账户号 3179000000463829
        return Ok(res);
    }

    /// <summary>
    /// 绑定银行卡 获取短信验证码
    /// </summary>
    /// <returns></returns>
    [HttpPost("bindcard")]
    public async Task<IActionResult> BindCard()
    {
        var bindcard = new BindCardRequest
        {
            LoginNo = LoginNo,
            CardName = "林成功",
            IdCard = "352203199001010000",
            CardNo = "9559983968085648017",
            BankMobile = LoginNo,
            AccountValidDate = "209901",
            Cvv2 = "",
            PageUrl = "",
            NotifyUrl = "",
        };
        var res = await _baoFooClient.SendAsync(bindcard, _baoFooOptions);

        return Ok(res);
    }

    /// <summary>
    /// 确认绑卡
    /// </summary>
    /// <param name="requestNo"></param>
    /// <param name="verifyCode"></param>
    /// <returns></returns>
    [HttpPost("bindcardcheck")]
    public async Task<IActionResult> BindCardCheck(string requestNo, string verifyCode)
    {
        var bindcardcheck = new BindCardCheckRequest()
        {
            LoginNo = LoginNo,
            RequestNo = requestNo,
            VerifyCode = verifyCode
        };
        var res = await _baoFooClient.SendAsync(bindcardcheck, _baoFooOptions);

        return Ok(res);
    }

    /// <summary>
    /// 解绑卡
    /// </summary>
    /// <param name="loginNo"></param>
    /// <param name="agreementNo"></param>
    /// <returns></returns>
    [HttpPost("unbindcard")]
    public async Task<IActionResult> UnbindCard(string loginNo, string agreementNo)
    {
        var requestNo = DateTime.Now.ToString("yyyyMMddHHmmss");
        var unbindCard = new UnbindCardRequest()
        {
            LoginNo = loginNo,
            RequestNo = requestNo,
            AgreementNo = agreementNo
        };
        var res = await _baoFooClient.SendAsync(unbindCard, _baoFooOptions);

        return Ok(res);
    }

    /// <summary>
    /// 客户登录号变更
    /// </summary>
    /// <returns></returns>
    [HttpPost("modifyLoginNo")]
    public async Task<IActionResult> ModifyLoginNo(string origLoginNo, string loginNo)
    {
        var modifyLoginNo = new ModifyLoginNoRequest()
        {
            LoginNo = loginNo,
            OrigLoginNo = origLoginNo,
        };
        var res = await _baoFooClient.SendAsync(modifyLoginNo, _baoFooOptions);

        return Ok(res);
    }
    
    /// <summary>
    /// 客户信息查询
    /// </summary>
    /// <param name="loginNo"></param>
    /// <param name="customerType"></param>
    /// <returns></returns>
    [HttpPost("querycustomerinfo")]
    public async Task<IActionResult> QueryCustomerInfo(string loginNo, string customerType)
    {
        var requestNo = DateTime.Now.ToString("yyyyMMddHHmmss");
        var queryCustomerInfo = new QueryCustomerInfoRequest()
        {
            LoginNo = loginNo,
            CustomerType = customerType,
            RequestNo = requestNo
        };
        var res = await _baoFooClient.SendAsync(queryCustomerInfo, _baoFooOptions);
        if (res.Success)
        {
            // Console.WriteLine(res.ResultObj.CustomerName);
        }
        return Ok(res);
    }

    /// <summary>
    /// 获取已绑定卡信息
    /// </summary>
    /// <param name="loginNo"></param>
    /// <param name="contractNo"></param>
    /// <returns></returns>
    [HttpPost("findbindbankcards")]
    public async Task<IActionResult> FindBindBankCards(string loginNo, string contractNo)
    {
        var findBindBankCards = new FindBindBankCardsRequest()
        {
            LoginNo = loginNo,
            ContractNo = contractNo
        };
        var res = await _baoFooClient.SendAsync(findBindBankCards, _baoFooOptions);
        
        return Ok(res);
    }
}