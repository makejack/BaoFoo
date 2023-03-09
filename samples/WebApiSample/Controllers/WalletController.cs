using Lin.Pay.BaoFoo.Domain;

namespace WebApiSample.Controllers;

[Route("api/wallet")]
public class WalletController : ControllerBase
{
    private readonly IBaoFooClient _baoFooClient;
    private readonly BaoFooOptions _baoFooOptions;

    public WalletController(IBaoFooClient baoFooClient, BaoFooOptions baoFooOptions)
    {
        _baoFooClient = baoFooClient;
        _baoFooOptions = baoFooOptions;
    }

    /// <summary>
    /// 账户余额查询
    /// </summary>
    /// <param name="loginNo"></param>
    /// <returns></returns>
    [HttpPost("getbalancenew")]
    public async Task<IActionResult> GetBalanceNew(string loginNo)
    {
        var getBalanceNew = new GetBalanceNewRequest()
        {
            LoginNo = loginNo
        };
        var res = await _baoFooClient.SendAsync(getBalanceNew, _baoFooOptions);

        return Ok(res);
    }
    
    /// <summary>
    /// 聚合支付
    /// </summary>
    /// <param name="loginNo"></param>
    /// <returns></returns>
    [HttpPost("pay")]
    public async Task<IActionResult> Pay(string loginNo)
    {
        var now = DateTime.Now;
        var outOrderNo = now.ToString("yyyyMMddHHmmss");
        var expireDate = now.AddMinutes(15);
        var payment = new PaymentRequest()
        {
            LoginNo = loginNo,
            DataContent = new PaymentDataContent()
            {
                GoodsName = "test",
                Amount = "1",
                OutOrderNo = outOrderNo,
                NotifyUrl = "",
                SplitInfoList = null,
                ExpireDate = expireDate.ToString("yyyyMMddHHmmss"),
                FeeMemberId = "",
                PaidType = PaidTypes.WECHAT_JSGZH,
                ValidDate = expireDate.ToString("yyyyMMdd"),
                Remark = ""
            },
            ChanalId = "",
            SimId = "",
            AppId = ""
        };
        var res = await _baoFooClient.SendAsync(payment, _baoFooOptions);

        return Ok(res);
    }

    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="loginNo"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login(string loginNo)
    {
        var login = new LoginRequest()
        {
            LoginNo = loginNo,
            CallType = "PWDMODIFY"
        };
        var res = await _baoFooClient.SendAsync(login, _baoFooOptions);

        return Ok(res);
    }
}