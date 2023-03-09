using System.Net;
using System.Text;
using System.Text.Json;
using Lin.Pay.BaoFoo;
using Lin.Pay.BaoFoo.Requests;
using Lin.Pay.BaoFoo.Responses;
using Moq.Protected;

namespace test;

public class BaoFooTest
{
    [Fact]
    public async Task Test1()
    {
        var jsonContent = JsonSerializer.Serialize(new DefaultResponse()
        {
            Result = null,
            Success = false,
            ErrorCode = null,
            ErrorMsg = null
        });

        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync((HttpRequestMessage request, CancellationToken token) =>
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
                };

                // configure your response here

                return response;
            });

        var httpClient = new HttpClient(mockHttpMessageHandler.Object);

        var mockHttpClientFactory = new Mock<IHttpClientFactory>();
        mockHttpClientFactory.Setup(e => e.CreateClient("BaoFooPay.Client")).Returns(httpClient);

        var baoFooOptions = new BaoFooOptions()
        {
            OrgNo = "100026136",
            TerminalNo = "200001259",
            MerchantNo = "100026136",
            CerCertificate = @"D:\Projects\Pay\test\Certificates\bfkey_100026136@@200001259.cer",
            PfxCertificate = @"D:\Projects\Pay\test\Certificates\bfkey_100026136@@200001259.pfx",
            Password = "100026136_259652"
        };

        var requestNo = DateTime.Now.ToString("yyyyMMddHHmmss");
        var loginNo = "18312460310";
        var openAccount = new OpenAccountRequest()
        {
            RequestNo = requestNo,
            LoginNo = loginNo,
            CustomerName = "林成功",
            CertificateNo = "352203199001010000",
            Base64ImageFront = "",
            Base64ImageBack = "",
            FileNo = "",
        };

        IBaoFooClient baoFooClient = new BaoFooClient(mockHttpClientFactory.Object);
        var res = await baoFooClient.SendAsync(openAccount, baoFooOptions);

        Assert.Null(res.Result);
    }
}