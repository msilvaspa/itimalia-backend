using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Application;
using Domain.ValueObjects;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;

namespace Tests.Integration
{
    public class PasswordControllerTest
    {
        private readonly HttpClient _client;
        
        public PasswordControllerTest()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
            _client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("text/plain"));
        }

        private async Task<string> MakeGetRequest(string password)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/password/is-valid");
            request.Content = new StringContent(password, Encoding.UTF8, "text/plain");
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        
        [Fact]
        public async void ShouldReceiveTrueWhenPwIsValid()
        {
            var isValid = await MakeGetRequest("Abcd1234!");
            Assert.Equal("true", isValid);
        }
        
        [Fact]
        public async void ShouldReceiveFalseWhenPwIsInvalid()
        {
            var isValid = await MakeGetRequest("abc");
            Assert.Equal("false", isValid);
        }
    }
}