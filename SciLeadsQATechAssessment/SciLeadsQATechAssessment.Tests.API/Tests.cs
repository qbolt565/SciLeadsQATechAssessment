using RestSharp;
using System.Net;

namespace SciLeadsQATechAssessment.Tests.API
{
    public class Tests
    {
        private RestClient _client;
        /** public Competition(string baseUrl) 
        { 
            RestClientOptions clientOptions = new RestClientOptions(baseUrl);
            _client = new RestClient(clientOptions);
        }

        public RestResponse GetAll()
        {
            var request = new RestRequest("Competition");
            return _client.GetAsync(request).Result;
        }*/
        [SetUp]
        public void Setup()
        {
            string baseUrl = "https://blazorapp120240830075204.azurewebsites.net/";
            RestClientOptions clientOptions = new RestClientOptions(baseUrl);
            _client = new RestClient(clientOptions);
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
        }

        [Test]
        public void Dataendpoint_SendPostRequest_ColorJsonReturns()
        {
            string expectedResponseContent = 
                "[{\"color\":\"red\",\"value\":\"#f00\"}," +
                "{\"color\":\"green\",\"value\":\"#0f0\"}," +
                "{\"color\":\"blue\",\"value\":\"#00f\"}," +
                "{\"color\":\"cyan\",\"value\":\"#0ff\"}," +
                "{\"color\":\"magenta\",\"value\":\"#f0f\"}," +
                "{\"color\":\"yellow\",\"value\":\"#ff0\"}," +
                "{\"color\":\"black\",\"value\":\"#000\"}]";

            var request = new RestRequest("api/dataendpoint");
            RestResponse response = _client.PostAsync(request).Result;

            Assert.Multiple(() => {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.Content, Is.EqualTo(expectedResponseContent));
            });
        }

        [Test]
        public void Weatherendpoint_SendPostRequest_TempAndCityJsonReturns()
        {
            string expectedResponseContent =
                "[{\"temp\":\"22\",\"location\":\"Belfast\"}," +
                "{\"temp\":\"45\",\"location\":\"Glasgow\"}," +
                "{\"temp\":\"63\",\"location\":\"Cardiff\"}," +
                "{\"temp\":\"12\",\"location\":\"Madrid\"}," +
                "{\"temp\":\"15\",\"location\":\"Paris\"}]";

            var request = new RestRequest("api/weatherendpoint");
            RestResponse response = _client.PostAsync(request).Result;

            Assert.Multiple(() => {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.Content, Is.EqualTo(expectedResponseContent));
            });
        }

    }
}