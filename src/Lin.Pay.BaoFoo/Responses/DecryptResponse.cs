
using System.Text;
using System.Text.Json;
using Org.BouncyCastle.Utilities.Encoders;

namespace Lin.Pay.BaoFoo.Responses;

/// <summary>
/// 解密响应
/// </summary>
/// <typeparam name="TObj"></typeparam>
public class DecryptResponse<TObj> : BaseResponse<string> where TObj : class
{
    /// <summary>
    /// 结果对象
    /// </summary>
    public TObj ResultObj { get; private set; }

    /// <summary>
    /// 解密内容转成对象
    /// </summary>
    public void DecryptToObj()
    {
        if (!Success) return;
        ResultObj = JsonSerializer.Deserialize<TObj>(
            Encoding.UTF8.GetString(Base64.Decode(Encoding.UTF8.GetBytes(Result))));
    }
}