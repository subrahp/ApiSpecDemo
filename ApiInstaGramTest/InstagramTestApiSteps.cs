using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Sockets;
using TechTalk.SpecFlow;

namespace ApiInstaGramTest
{
    [Binding]
    public class InstagramTestApiSteps
    {
        private string PostCodeapiurl;
        private string ApiResponse;

        [Given(@"The API takes the city Name and returns the Pincode")]
        public void GivenTheAPITakesTheCityNameAndReturnsThePincode()
        {
            PostCodeapiurl = " http://www.getpincode.info/api/pincode?q=";
        }
        
        [When(@"I have entered the (.*)")]
        public void WhenIHaveEnteredThe(string CityName)
        {
            HttpClient HC = new HttpClient();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(PostCodeapiurl);
            sb.Append(CityName);
            Uri uri = new Uri(sb.ToString());
            ApiResponse = HC.GetStringAsync(uri).Result;
            var test = ApiResponse;

        }
        
        [Then(@"the respective (.*) returned should be as expected")]
        public void ThenTheRespectiveReturnedShouldBeAsExpected(string ExPinCode)
        {
            var root = JsonConvert.DeserializeObject<RootObject>(ApiResponse);
            var PC = root.pincode;
            Assert.AreEqual(PC.ToString(), ExPinCode);
            Console.Out.WriteLine("Test Completed");
        }
    }
}
