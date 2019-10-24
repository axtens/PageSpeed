using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace PageSpeed
{
    public class Speed
    {
        internal static string key;
        internal static string url;
        internal static string strategy;
        internal static string locale;
        internal static string category;
        internal static string utm_campaign;
        internal static string utm_source;

        public Speed() { }

        public void Key(string item) => key = item;

        public void Url(string item) => url = item;

        public void Strategy(string item) => strategy = item;

        public void Locale(string item) => locale = item;

        public void Category(string item) => category = item;

        public void UtmCampaign(string item) => utm_campaign = item;

        public void UtmSource(string item) => utm_source = item;
        public string Get()
        {
            var client = new RestClient("https://www.googleapis.com/pagespeedonline/v5/runPagespeed");
            var request = new RestRequest(Method.GET);

            if (null == key) throw new Exception("Key not defined.");
            if (null == url) throw new Exception("Url not defined.");

            request.AddParameter("url", url);
            request.AddParameter("key", key);

            if (null != locale) 
                request.AddParameter("locale", locale);
            if (null != strategy) 
                request.AddParameter("strategy", strategy);
            if (null != category) 
                request.AddParameter("category", category);
            if (null != utm_campaign) 
                request.AddParameter("utm_campaign", utm_campaign);
            if (null != utm_source) 
                request.AddParameter("utm_source", utm_source);
            var response = client.Execute(request);
            return response.Content;
        }
    }
}
