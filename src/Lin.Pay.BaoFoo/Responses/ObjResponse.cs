using System.Text.Json;

namespace Lin.Pay.BaoFoo.Responses;

/// <summary>
/// 对象响应
/// </summary>
public class ObjResponse<TObj> : BaseResponse<string> where TObj : class
{
    /// <summary>
    /// 结果对象
    /// </summary>
    public TObj ResultObj { get; private set; }
    
    /// <summary>
    /// 结果字符串转成对象
    /// </summary>
    public void ResultToObj()
    {
        if (!Success) return;
        ResultObj = JsonSerializer.Deserialize<TObj>(Result);
    }

}