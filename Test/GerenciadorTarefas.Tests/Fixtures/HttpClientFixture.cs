using Moq;
using Moq.Protected;

namespace GerenciadorTarefas.Testes.Fixtures
{
    public class HttpClientFixture
    {
        private readonly Mock<HttpMessageHandler> _httpMock;

        public HttpClient HttpClient { get; private set; }

        public HttpClientFixture()
        {
            _httpMock = new Mock<HttpMessageHandler>();
        }

        public HttpClientFixture ConfigureResponse(HttpResponseMessage response)
        {
            _httpMock.Protected()
                        .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                        .ReturnsAsync(response);

            return this;
        }
        public HttpClientFixture Build()
        {

            HttpClient = new HttpClient(_httpMock.Object)
            {
                BaseAddress = new Uri("https://localhost")
            };

            return this;
        }
    }
}
