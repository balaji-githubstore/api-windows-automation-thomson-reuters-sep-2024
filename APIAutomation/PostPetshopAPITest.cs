using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIAutomation
{
    public class PostPetshopAPITest
    {
        [Test]
        public void AddValidPetToStoreTest()
        {
            RestClient client = new RestClient("https://petstore.swagger.io/v2");
            RestRequest request = new RestRequest("pet", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddBody("{\r\n  \"id\": 800,\r\n  \"category\": {\r\n    \"id\": 0,\r\n    \"name\": \"string\"\r\n  },\r\n  \"name\": \"doggie800\",\r\n  \"photoUrls\": [\r\n    \"string\"\r\n  ],\r\n  \"tags\": [\r\n    {\r\n      \"id\": 0,\r\n      \"name\": \"string\"\r\n    }\r\n  ],\r\n  \"status\": \"available\"\r\n}");

            var response = client.Execute(request);

            Console.WriteLine(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        //Read json and post request
        [Test]
        public void AddValidPetToStoreTest2()
        {
            StreamReader reader = new StreamReader(@"C:\Users\Balaji_Dinakaran\source\repos\APIAutomationSln\APIAutomation\File\new_pet.json");

            RestClient client = new RestClient("https://petstore.swagger.io/v2");
            RestRequest request = new RestRequest("pet", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(reader.ReadToEnd());

            var response = client.Execute(request);

            Console.WriteLine(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }
        [Test]
        public void ReadJsonArrayAddPetsTest()
        {
            StreamReader reader = new StreamReader(@"C:\Users\Balaji_Dinakaran\source\repos\APIAutomationSln\APIAutomation\File\new_pets.json");

            dynamic json = JsonConvert.DeserializeObject(reader.ReadToEnd());

            Console.WriteLine(json.Count);
            for(int i = 0; i < json.Count; i++)
            {
                RestClient client = new RestClient("https://petstore.swagger.io/v2");
                RestRequest request = new RestRequest("pet", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                string pet = JsonConvert.SerializeObject(json[i]);
                request.AddBody(pet);

                var response = client.Execute(request);

                Console.WriteLine(response.Content);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }
        }

        //Read json and post request
        [Test]
        public void UpdateValidPetToStoreTest2()
        {
            StreamReader reader = new StreamReader(@"C:\Users\Balaji_Dinakaran\source\repos\APIAutomationSln\APIAutomation\File\update_pet.json");

            RestClient client = new RestClient("https://petstore.swagger.io/v2");
            RestRequest request = new RestRequest("pet", Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(reader.ReadToEnd());

            var response = client.Execute(request);

            Console.WriteLine(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

        [Test]
        public void DeleteValidPetTest2()
        {

            RestClient client = new RestClient("https://petstore.swagger.io/v2");
            RestRequest request = new RestRequest("pet/813", Method.Delete);
            request.AddHeader("api_key", "jsdjsdjdsj");


            var response = client.Execute(request);

            Console.WriteLine(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

        [Test]
        public void DeleteInvalidPetTest2()
        {

            RestClient client = new RestClient("https://petstore.swagger.io/v2");
            RestRequest request = new RestRequest("pet/813", Method.Delete);
            request.AddHeader("api_key", "jsdjsdjdsj");


            var response = client.Execute(request);

            Console.WriteLine(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        }
    }
}
