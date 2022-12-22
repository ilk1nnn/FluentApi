using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FluentApi.Domain.Services
{
    public static class ImageService
    {
        private static HttpClient _httpClient=new HttpClient();
        public static async Task<string> GetImagePath(string name)
        {
            // We can specify the region we want for the Bing Image of the Day.
            string strRegion = "en-US";
            string strBingImageURL = string.Format("http://www.bing.com/HPImageArchive.aspx?format=js&idx=0&n={0}&mkt={1}", strRegion);
            string strJSONString = "";

            HttpClient client = new HttpClient();

            // Using an Async call makes sure the app is responsive during the time the response is fetched.
            // GetAsync sends an Async GET request to the Specified URI.
            HttpResponseMessage response = await client.GetAsync(new Uri(strBingImageURL));

            // Content property get or sets the content of a HTTP response message. 
            // ReadAsStringAsync is a method of the HttpContent which asynchronously 
            // reads the content of the HTTP Response and returns as a string.
            strJSONString = await response.Content.ReadAsStringAsync();

            return strJSONString;

        }
    }
}
