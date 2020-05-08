
using NUnit.Framework;
using RestSharp;
namespace TestProject1.Utilities
{
    public class TestWithPostOperation
    {
        [TestFixture]
        public class Tests
        {
            private RestClient _restClient;
            private RestRequest _restRequest;

            [SetUp]
            public void Setup()
            {
                _restClient = new RestClient("https://reqres.in/");

            }

            [Test]
            public void TestWithPostCall()
            {
                _restRequest = new RestRequest("api/users" , Method.POST);
                _restRequest.AddJsonBody(new {name = "morpheus"});
                _restRequest.AddJsonBody(new {job = "leader" });

                var result = _restClient.Execute(_restRequest);

                var rResult = Helper.DeserializeResponse(result);
                var output = rResult["name"];

                Assert.That(output, Is.EqualTo("morpheus"));
            }
        }
    }
}