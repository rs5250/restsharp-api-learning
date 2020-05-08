using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;
using TestProject1.Utilities;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TestProject1
{
    [TestFixture]
    public class TestsWithData
    {
        private RestClient _restClient;
        private RestRequest _restRequest;
        [SetUp]

        public void Setup()
        {
             _restClient = new RestClient(baseUrl: "http://api.zippopotam.us/");
        }
        
       
        [TestCase("IN", "110001", HttpStatusCode.OK , TestName = "Check status code for IN with 110001")]
        [TestCase("CA", "A0A", HttpStatusCode.OK , TestName =  "Check status code for CA with A0A")]
        public void TestPostCallWithData(string countryCode,string pinCode , HttpStatusCode  expectedHTTPStatusCode)
          
        {
            
            //Arrange
           
             _restRequest = new RestRequest(resource: $"{countryCode}/{pinCode}", Method.GET);
            
            

            //Act
            var result = _restClient.Execute(_restRequest);
            
            //Assert
            Console.WriteLine("This is the response " + result.Content);
            
            Assert.That(result.StatusCode , Is.EqualTo(expectedHTTPStatusCode));


        }



       

        [TearDown]
        public void Close()
        {
            Console.WriteLine("Test Execution is done!!");
        }
    }
}
