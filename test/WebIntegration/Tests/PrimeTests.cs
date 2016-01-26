using Microsoft.AspNet.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace WebIntegration.Tests
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class PrimeTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        
        public PrimeTests()
        {
            // Arrange
            _server = new TestServer(TestServer.CreateBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ReturnHelloWorld()
        {
            // Act 
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("Hello World!", responseString);
        }

        private async Task<string> GetCheckPrimeResponseString(string querystring = "")
        {
            string request = "/checkprime";
            if (!string.IsNullOrEmpty(querystring))
            {
                request += "?" + querystring;
            }
            var response = await _client.GetAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        [Fact]
        public async Task ReturnsInstructionsGivenEmptyQueryString()
        {
            // Act
            var responseString = await GetCheckPrimeResponseString();

            // Assert
            Assert.Equal("Pass in a number to check in the form /checkprime?5", responseString);
        }
        
        [Fact]
        public async Task ReturnPrimeGiven5()
        {
            // Act
            var responseString = await GetCheckPrimeResponseString("5");

            // Assert
            Assert.Equal("5 is prime!", responseString);
        }

        [Fact]
        public async Task ReturnPrimeGiven6()
        {
            // Act
            var responseString = await GetCheckPrimeResponseString("6");

            // Assert
            Assert.Equal("6 is NOT prime!", responseString);
        }
    }
}
