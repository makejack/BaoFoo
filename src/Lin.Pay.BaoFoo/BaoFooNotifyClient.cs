using Lin.Pay.BaoFoo.Requests;
using Lin.Pay.BaoFoo.Utils;

namespace Lin.Pay.BaoFoo;

/// <summary>
/// 通知客户端
/// </summary>
public class BaoFooNotifyClient : IBaoFooNotifyClient
{
    /// <summary>
    /// 验证
    /// </summary>
    /// <param name="data"></param>
    /// <param name="options"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public bool Verify<T>(T data, BaoFooOptions options) where T : NotifyRequest
    {
        if (string.IsNullOrEmpty(data.Signature))
        {
            throw new Exception("signature is Empty");
        }

        var dic = ToolsHepler.PropertyToDictionary(data);
        var signData = ToolsHepler.VerifyString(data.GetSignFieldString(), dic);
        return SignatureHelper.VerifySignature(options.CerCertificate, signData, data.Signature);
        
    }
}