using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomation
{
    public class GetPetshopAPITest
    {
        //path parameter
        [Test]
        public void FindValidPetByIdTest()
        {

            RestClient client = new RestClient("https://petstore.swagger.io/v2");
            RestRequest request = new RestRequest("pet/5", Method.Get);

            var response=client.Execute(request);

            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.True(response.Content.Contains("\"id\":5"));

            dynamic json = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(json["id"]);
            Console.WriteLine(json["status"]);

            Console.WriteLine(json["category"]);
            Console.WriteLine(json["category"]["id"]);

            Console.WriteLine(json["tags"]);
            Console.WriteLine(json["tags"][0]);
            Console.WriteLine(json["tags"][0]["id"]);
        }

        [Test]
        public void FindInvalidPetByIdTest()
        {

            RestClient client = new RestClient("https://petstore.swagger.io/v2");
            RestRequest request = new RestRequest("pet/590", Method.Get);

            var response = client.Execute(request);

            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }


        //query
        [Test]
        [TestCase("sold")]
        public void FindValidPetStatusIdTest(string status)
        {

            RestClient client = new RestClient("https://petstore.swagger.io/v2");
            RestRequest request = new RestRequest("pet/findByStatus?status="+status, Method.Get);

            var response = client.Execute(request);

            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);

            dynamic json = JsonConvert.DeserializeObject(response.Content);

            //Console.WriteLine(json);
            Console.WriteLine(json.Count);
            //Console.WriteLine(json[0]);
            Console.WriteLine(json[0]["status"]);
            Console.WriteLine(json[1]["status"]);

            //verify all status are as expected
            for (int i = 0; i < json.Count; i++)
            {
                Console.WriteLine(json[i]["status"]);

                string actualStatus = json[i]["status"];
                Assert.That(actualStatus, Is.EqualTo(status));
            }

            //verify all status is sold.

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
           
        }

    }
}
