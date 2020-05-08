using System;
using System.Collections.Generic;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using TestProject1.Model;

namespace TestProject1.Tests
{
    public class TestWithDataExercise
    {
        [TestFixture]
        public class Tests
        {
            private IRestClient _restClient;
            private IRestRequest _restRequest;
            private IRestResponse _restResponse;
            private const string BaseUrl = "https://reqres.in";
            //https://reqres.in/
            // /api/users?page=

            [SetUp]
            public void Setup()
            {
                _restClient = new RestClient(BaseUrl);
            }
            
            [Test, TestCaseSource(nameof(PagesTestData))]
            public void TestWithDataExercise(string pagenum)
            {
               _restRequest = new RestRequest("/api/users?page=" +$"{pagenum}", Method.GET);
             
                var response = _restClient.Execute<PagesData>(_restRequest);
                var output = new  JsonDeserializer().Deserialize<PagesData>(response);
              
                // for page=3
              // Console.WriteLine("*****" +output.Page.ToString());
               Assert.That(output.Data[0].Email ,Is.EqualTo("michael.lawson@reqres.in"));
                Assert.That(output.Data[0].Id ,Is.EqualTo("7"));
                
                
               
              
                //Console.WriteLine("*******" + output.Data[0].Da);
            }

            private static IEnumerable<TestCaseData> PagesTestData()
            {
                yield return  new TestCaseData("2").SetName("Verify the details of  page number 2");
                //for page num 3
                //yield return  new TestCaseData("3").SetName("Verify the details of  page number 3");
            }
        }
    }
}