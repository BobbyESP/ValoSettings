using System;
using System.Text;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace ValoSettings.MainFiles
{
    public class Endpoints
    {

        public static JObject GetWebsocketAPI(string endpoint)
        {
            IRestClient GetClient = new RestClient(new Uri($"https://127.0.0.1:{RiotUser.Instance.lockfileData.port}{endpoint}"));
            GetClient.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            IRestRequest GetRequest = new RestRequest(Method.GET);
            GetRequest.AddHeader("Authorization", $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"riot:{RiotUser.Instance.lockfileData.password}"))}");
            GetRequest.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
            GetRequest.AddHeader("X-Riot-ClientVersion", "release-03.01-shipping-9-579719");
            IRestResponse getResp = GetClient.Get(GetRequest);

            if (getResp.IsSuccessful)
                return JObject.Parse(getResp.Content);
            else
                return null;
        }

        public static JObject POSTWebsocketAPI(string endpoint, Object data)
        {
            IRestClient postClient = new RestClient(new Uri($"https://127.0.0.1:{RiotUser.Instance.lockfileData.port}{endpoint}"));
            postClient.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            IRestRequest postRequest = new RestRequest(Method.POST);
            postRequest.AddHeader("Authorization", $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"riot:{RiotUser.Instance.lockfileData.password}"))}");

            string body = JsonConvert.SerializeObject(data);
            postRequest.AddJsonBody(body);

            IRestResponse postResp = postClient.Post(postRequest);

            

            if (postResp.IsSuccessful)
                return JObject.Parse(postResp.Content);
            else
                return null;
        }

        public static JObject GETCurrentSettings()
        {
            IRestClient GetClient = new RestClient(new Uri($"https://127.0.0.1:{RiotUser.Instance.lockfileData.port}/player-preferences/v1/data-json/Ares.PlayerSettings"));
            GetClient.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            IRestRequest GetRequest = new RestRequest(Method.GET);
            GetRequest.AddHeader("Authorization", $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"riot:{RiotUser.Instance.lockfileData.password}"))}");
            IRestResponse getResp = GetClient.Get(GetRequest);

            if (getResp.IsSuccessful)
                return JObject.Parse(getResp.Content);
            else
                return null;
        }
        
        public static JObject POSTCurrentSettings(Object data)
        {
            IRestClient PostClient = new RestClient(new Uri($"https://127.0.0.1:{RiotUser.Instance.lockfileData.port}/player-preferences/v1/data-json/Ares.PlayerSettings"));
            PostClient.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            IRestRequest PostRequest = new RestRequest(Method.POST);
            PostRequest.AddHeader("Authorization", $"Basic {Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"riot:{RiotUser.Instance.lockfileData.password}"))}");
            string body = JsonConvert.SerializeObject(data);
            PostRequest.AddJsonBody(body);

            IRestResponse postResp = PostClient.Post(PostRequest);

            if (postResp.IsSuccessful)
                return JObject.Parse(postResp.Content);
            else
                return null;
        }
    }
}