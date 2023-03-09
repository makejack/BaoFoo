namespace Lin.Pay.BaoFoo;

public interface IBaoFooClient
{
    /// <summary>
    /// 发送
    /// </summary>
    /// <param name="request"></param>
    /// <param name="options"></param>
    /// <typeparam name="TResponse"></typeparam>
    Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, BaoFooOptions options)
        where TResponse : BaseResponse;
}