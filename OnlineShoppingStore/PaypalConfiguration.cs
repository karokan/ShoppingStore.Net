using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore
{
    public class PaypalConfiguration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;
        
        static PaypalConfiguration()
        {
            var config = getconfig();
            clientId = "Ad-wq1h-yFxISaZc4yrf2NH6vC5ClUtjCHlINREUyuUHCtci6_q_UGPzq_l_PHDKHco5igVMlMtx20Rm";
            clientSecret = "EHHJlCfU4ai5ct6_kArpO2f2f4Ijl2etJ2nSHsAdTUkr6vBwmFrtmg7t6Gj1Fbf4_iccBd8iR010cLLS";
        }

        private static Dictionary<string, string> getconfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(clientId, clientSecret, getconfig()).GetAccessToken();
            return accessToken;
        }
        public static APIContext GetAPIContext()
        {
            APIContext apicontext = new APIContext(GetAccessToken());
            apicontext.Config = getconfig();
            return apicontext;
        }
    }
}