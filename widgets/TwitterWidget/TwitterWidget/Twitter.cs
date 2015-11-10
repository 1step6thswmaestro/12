using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Twitter
{
    public class Twitter
    {
        public string OAuthConsumerSecret { get; set; }        
        public string OAuthConsumerKey { get; set; }

        public async Task<IEnumerable<string>> GetTwitts(string userName,int count, string accessToken = null)
        {
            if (accessToken == null)
            {
                accessToken = await GetAccessToken();   
            }

            var requestUserTimeline = new HttpRequestMessage(HttpMethod.Get, string.Format("https://api.twitter.com/1.1/statuses/user_timeline.json?count={0}&screen_name={1}&trim_user=1&exclude_replies=1", count, userName));
            requestUserTimeline.Headers.Add("Authorization", "Bearer " + accessToken);
            var httpClient = new HttpClient();
            HttpResponseMessage responseUserTimeLine = await httpClient.SendAsync(requestUserTimeline);
            var serializer = new JavaScriptSerializer();
            dynamic json = serializer.Deserialize<object>(await responseUserTimeLine.Content.ReadAsStringAsync());
            var enumerableTwitts = (json as IEnumerable<dynamic>);

            if (enumerableTwitts == null)
            {
                return null;
            }
            return enumerableTwitts.Select(t => (string)(t["text"].ToString()));                        
        }

        public async Task<string> GetAccessToken()
        {
            Console.WriteLine("GetAccessToken() is executed.");
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.twitter.com/oauth2/token");
            var customerInfo = Convert.ToBase64String(new UTF8Encoding().GetBytes(OAuthConsumerKey + ":" + OAuthConsumerSecret));
            request.Headers.Add("Authorization", "Basic " + customerInfo);
            request.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

            Console.WriteLine("GetAccessToken() await response.");
            HttpResponseMessage response = await httpClient.SendAsync(request);
            Console.WriteLine("GetAccessToken() get response.");

            string json = await response.Content.ReadAsStringAsync();
            var serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(json);
            Console.WriteLine("GetAccessToken() is done.");
            return  item["access_token"];            
        }
    }
}