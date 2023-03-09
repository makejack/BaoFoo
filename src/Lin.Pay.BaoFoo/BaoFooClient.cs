using System.Reflection;
using System.Text;
using System.Text.Json;
using Lin.Pay.BaoFoo.Responses;

namespace Lin.Pay.BaoFoo;

/// <summary>
/// 宝付
/// </summary>
public class BaoFooClient : IBaoFooClient
{
    private const string Name = "BaoFooPay.Client";

    private readonly IHttpClientFactory _clientFactory;

    public BaoFooClient(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    /// <summary>
    /// 发送
    /// </summary>
    /// <param name="request"></param>
    /// <param name="options"></param>
    /// <typeparam name="TResponse"></typeparam>
    public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, BaoFooOptions options)
        where TResponse : BaseResponse
    {
        VerifyOptions(options);

        var requestContent = request.PrimaryHandler(options);
        var url = request.GetUrl(requestContent);

        var httpContent = request.GetHttpContent(requestContent);
        
        var client = _clientFactory.CreateClient(Name);
        var res = await client.PostAsync(url, httpContent);
        if (res.IsSuccessStatusCode)
        {
            var responseContent = await res.Content.ReadAsStringAsync();
            var rootResult = JsonSerializer.Deserialize<TResponse>(responseContent);

            ExecObjMethod(rootResult);

            return rootResult;
        }

        var body = await res.Content.ReadAsStringAsync();
        var result = Activator.CreateInstance<TResponse>();
        result.ErrorCode = "SYSTEM_INNER_ERROR";
        result.ErrorMsg = body;

        return result;
    }

    #region Private Methods

    
    private void ExecObjMethod<TResponse>(TResponse rootResult) where TResponse : BaseResponse
    {
        var rootResultType = rootResult.GetType();
        if (!rootResultType.IsGenericType) return;
        
        var methodName = GetMethodName(rootResultType);
        if (string.IsNullOrEmpty(methodName)) return;
        
        var arguments = rootResultType.GetGenericArguments();
        if (arguments.Length <= 0) return;
        
        var method = rootResultType.GetMethod(methodName,
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.Default);
        method?.Invoke(rootResult, null);
    }

    private string GetMethodName(Type rootResultType)
    {
        var genericType = rootResultType.GetGenericTypeDefinition();
        if (genericType == typeof(ObjResponse<>))
        {
            return nameof(ObjResponse<object>.ResultToObj);
        }

        if (genericType == typeof(DecryptResponse<>))
        {
            return nameof(DecryptResponse<object>.DecryptToObj);
        }

        return null;
    }

    private void VerifyOptions(BaoFooOptions options)
    {
        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        if (string.IsNullOrEmpty(options.OrgNo))
        {
            throw new ArgumentNullException($"options.{nameof(BaoFooOptions.OrgNo)} is Empty");
        }

        if (string.IsNullOrEmpty(options.MerchantNo))
        {
            throw new ArgumentNullException($"options.{nameof(BaoFooOptions.MerchantNo)} is Empty");
        }

        if (string.IsNullOrEmpty(options.TerminalNo))
        {
            throw new ArgumentNullException($"options.{nameof(BaoFooOptions.TerminalNo)} is Empty");
        }

        if (string.IsNullOrEmpty(options.CerCertificate))
        {
            throw new ArgumentNullException($"options.{nameof(BaoFooOptions.CerCertificate)} is Empty");
        }

        if (!File.Exists(options.CerCertificate))
        {
            throw new ArgumentNullException($"options.{nameof(BaoFooOptions.CerCertificate)} file not exists");
        }

        if (string.IsNullOrEmpty(options.PfxCertificate))
        {
            throw new ArgumentNullException($"options.{nameof(BaoFooOptions.PfxCertificate)} is Empty");
        }

        if (!File.Exists(options.PfxCertificate))
        {
            throw new ArgumentNullException($"options.{nameof(BaoFooOptions.PfxCertificate)} file not exists");
        }
    }
    

    #endregion
}