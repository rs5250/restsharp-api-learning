using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using TestProject1.Utilities;

namespace TestProject1
{
    public class TestExerciseWithPost
    {
        [TestFixture]
        public class Tests
        {
            private RestClient _restClient;
            private RestRequest _restRequest;

            [SetUp]
            public void Setup()
            {
                _restClient = new RestClient("http://dummy.restapiexample.com");

            }

            [Test]
            public void TestWithPostCall()
            {
                
                //Act
                _restRequest = new RestRequest("api/v1/create", Method.POST);
                
                /*_restRequest.AddJsonBody(new {name = "test"});
                _restRequest.AddJsonBody(new {salary = "123"});
                _restRequest.AddJsonBody(new {age = "23"}); */
                _restRequest.AddJsonBody(new {name="test", salary= "123", age ="23"});
                
                //Arrange
                var result = _restClient.Execute(_restRequest);
                var jsonObject = Helper.DeserializeResponse(result);
                var finalOutput = jsonObject["data"];
                Console.WriteLine("Content of data is " + finalOutput);
                JObject _dataFields =JObject.Parse(finalOutput);
                String name = _dataFields["name"]?.ToString();
                String sal = _dataFields["salary"]?.ToString();
                String age = _dataFields["age"]?.ToString();
                
                //Assert
                Assert.That(name, Is.EqualTo("test"));
                Assert.That(sal, Is.EqualTo("123"));
                Assert.That(age, Is.EqualTo("23"));
                




                /*var rResult = Helper.DeserializeResponse(result);
                var output = rResult["name"];
 
                Assert.That(output, Is.EqualTo("test"));
 
                 var statuscode = (int) result.StatusCode;
                 Assert.AreEqual(200, "statuscode", "Status code is not matching");*/




            }
        }

    }
}