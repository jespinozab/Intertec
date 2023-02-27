using CodeChallengeConsole;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Moq.Protected;
using Moq;
using System.Net;

namespace CodeChallengeTest
{
    [TestClass]
    public class TestConsoleMethods
    {
        [TestMethod]
        public void GetApiUrl_ReturnsCorrectHttpsApiUrl()
        {
            // Arrange
            var expectedApiUrl = "https://localhost:7192/Result?input=hello+world";
            var input = "hello world";
            var service = new CallService();

            // Act
            var actualApiUrl = service.GetHttpsApiUrl(input);

            // Assert
            Assert.AreEqual(expectedApiUrl, actualApiUrl);
        }

        public void GetApiUrl_ReturnsCorrectHttpApiUrl()
        {
            // Arrange
            var expectedApiUrl = "https://localhost:7192/Result?input=hello+world";
            var input = "hello world";
            var service = new CallService();

            // Act
            var actualApiUrl = service.GetHttpApiUrl(input);

            // Assert
            Assert.AreEqual(expectedApiUrl, actualApiUrl);
        }


        [TestMethod]
        public async Task TestExecuteCall()
        {
            // Arrange
            var input = "some input";
            var output = "initial output";
            var apiUrl = "https://localhost:7192/Result?input=hello+world";

            // Create a fake HTTP message handler that returns a successful response
            var handler = new Mock<HttpMessageHandler>();
            handler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("response content")
                });

            var httpClient = new HttpClient(handler.Object)
            {
                Timeout = TimeSpan.FromSeconds(1)
            };

            var service = new CallService();

            // Act
            var result = await service.ExecuteCall(input, output, apiUrl);

            // Assert
            Assert.AreEqual("s2e i3t", result);
        }
  
    }
}

