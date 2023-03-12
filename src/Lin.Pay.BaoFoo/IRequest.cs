namespace Lin.Pay.BaoFoo;

public interface IRequest<TResponse> where TResponse : BaseResponse
{
    /// <summary>
    /// 获取请求地址
    /// </summary>
    /// <returns></returns>
    string GetUrl(bool debug, string param = null);

    /// <summary>
    /// 获取httpContent
    /// </summary>
    /// <returns></returns>
    HttpContent GetHttpContent(string content);

    /// <summary>
    /// 处理
    /// </summary>
    string PrimaryHandler(BaoFooOptions options);
}