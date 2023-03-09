using Lin.Pay.BaoFoo.Requests;

namespace Lin.Pay.BaoFoo;

public interface IBaoFooNotifyClient
{
    /// <summary>
    /// 验证
    /// </summary>
    /// <param name="data"></param>
    /// <param name="options"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    bool Verify<T>(T data, BaoFooOptions options) where T : NotifyRequest;
}