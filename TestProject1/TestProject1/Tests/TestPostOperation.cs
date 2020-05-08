using System;
using NUnit.Framework;
using RestSharp;
using TestProject1.Model;
using TestProject1.Utilities;

namespace TestProject1
{
    public class TestWithPostOperation
    {
        [TestFixture]
        public class Tests
        {
            private RestClient _restClient;
            private RestRequest _restRequest;
            private const string BASE_URL = "https://reqres.in/";

            [SetUp]
            public void Setup()
            {
                _restClient = new RestClient(BASE_URL);

            }

            [Test]
            public void TestWithPostCall()
            {
                _restRequest = new RestRequest("api/users" , Method.POST);
                _restRequest.AddJsonBody(new {name = "morpheus"});
                _restRequest.AddJsonBody(new {job = "leader" });

                var result = _restClient.Execute(_restRequest);

                var rResult = result.DeserializeResponse();
                var output = rResult["name"];

                Assert.That(output, Is.EqualTo("morpheus"));
            }
            
            //TEst Post with Type class

            [Test]
            public void TestPostWithTypeClass()

            {
                _restRequest = new RestRequest("api/register" , Method.POST);
                _restRequest.AddJsonBody(new Users(){email="eve.holt@reqres.in", password= "pistol"});
                
                var response = _restClient.Execute<Users>(_restRequest);
                var rResult = response.DeserializeResponse();
                Console.WriteLine("token is " + response.Data.token);
                
               Assert.That(response.Data.token,Is.EqualTo("QpwL5tke4Pnpja7X4"));
                
                
            }
            
        }
    }
}