宝付支付文档
===

API接口文档
---
|宝户通文档|	说明|
| ---- | ---- |
|文档地址|	https://doc.mandao.com/|
|登陆账号|	baofu|
|登陆密码|	baofu@64|

测试联调信息
---
| 测试环境联调信息 | 内容               |
| ---- |------------------|
| 机构号/平台号 | 100026136        |
| 商户号 | 100026136        |
| 终端号 | 200001259        |
| 证书密码 | 100026136_259652 |
| 证书下载 | [测试证书(点击下载)](https://doc.mandao.com/attach_files/kljhgfdsa/176)   |

第一步 在appsettings.json添加宝付支付的选项
````json
"BaoFooOptions": {
    "OrgNo": "100026136", //机构号/平台号
    "MerchantNo": "100026136", //商户号
    "TerminalNo": "200001259", //终端号
    "CerCertificate": "D:\\Projects\\Pay\\test\\Certificates\\bfkey_100026136@@200001259.cer", // 公钥证书
    "PfxCertificate": "D:\\Projects\\Pay\\test\\Certificates\\bfkey_100026136@@200001259.pfx", //私钥证书
    "Password": "100026136_259652" //证书密码
  }
````

第二步 引入BaoFoo到项目中
````c#

builder.Services.AddBaoFoo(configuration);

````

第三步 构造函数中引入IBaoFooClient和BaoFooOptions
````c#
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
    
````