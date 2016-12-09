// Copyright (c) 2009, Hiroshi Tsujimura
// Some rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
// 
//  * Redistributions of source code must retain the above copyright notice,
//    this list of conditions and the following disclaimer.
//  * Redistributions in binary form must reproduce the above copyright
//    notice, this list of conditions and the following disclaimer in the
//    documentation and/or other materials provided with the distribution.
//  * Neither the name of Oki Software Co., Ltd. nor the names of its
//    contributors may be used to endorse or promote products derived from
//    this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
// POSSIBILITY OF SUCH DAMAGE. 

/* original code from: http://www.voiceoftech.com/swhitley/?p=681 */

using System;
using System.Web;
using System.Collections.Specialized;
using System.Text;

namespace OAuth
{
    public class OAuthTwitter : OAuthBase
    {
        public enum Method { GET, POST };
        public const string REQUEST_TOKEN = "http://twitter.com/oauth/request_token";
        public const string AUTHORIZE = "http://twitter.com/oauth/authorize";
        public const string ACCESS_TOKEN = "http://twitter.com/oauth/access_token";
        public const string ACCESS_TOKEN_VIA_XAUTH = "https://api.twitter.com/oauth/access_token";

        private string _consumerKey = "";
        private string _consumerSecret = "";
        private string _token = "";
        private string _tokenSecret = "";

        #region Properties
        public string ConsumerKey
        {
            get
            {
                if (_consumerKey.Length == 0)
                {
                    _consumerKey = Tumblen3.Utility.Setting.consumerKeyForTwitter;
                }
                return _consumerKey;
            }
            set { _consumerKey = value; }
        }

        public string ConsumerSecret
        {
            get
            {
                if (_consumerSecret.Length == 0)
                {
                    _consumerSecret = Tumblen3.Utility.Setting.consumerSecretForTwitter;
                }
                return _consumerSecret;
            }
            set { _tokenSecret = value; }
        }

        public string Token { get { return _token; } set { _token = value; } }
        public string TokenSecret { get { return _tokenSecret; } set { _tokenSecret = value; } }
        #endregion

        /// <summary>
        /// Get the link to Twitter's authorization page for this application.
        /// </summary>
        /// <returns>The url with a valid request token, or a null string.</returns>
        public string AuthorizationLinkGet()
        {
            string ret = null;

            string response = oAuthWebRequest(Method.GET, REQUEST_TOKEN, String.Empty);
            if (response.Length > 0)
            {
                //response contains token and token secret.  We only need the token.
                NameValueCollection qs = HttpUtility.ParseQueryString(response);
                if (qs["oauth_token"] != null)
                {
                    ret = AUTHORIZE + "?oauth_token=" + qs["oauth_token"];
                    this.Token = qs["oauth_token"];                 /* {@@} */
                }

                if (qs["oauth_token_secret"] != null)               /* {@@} */
                {                                                   /* {@@} */
                    this.TokenSecret = qs["oauth_token_secret"];    /* {@@} */
                }                                                   /* {@@} */
            }
            return ret;
        }

        public void AccessTokenGet(string username, string password)
        {
            string param = "x_auth_mode=client_auth&" +
                "x_auth_username=" + username + "&" +
                "x_auth_password=" + password;
            string response = oAuthWebRequest(Method.POST, ACCESS_TOKEN_VIA_XAUTH, param);
            TokenGet(response);
        }

        /// <summary>
        /// Exchange the request token for an access token.
        /// </summary>
        public void AccessTokenGet(string verifier)
        {
            string response = oAuthWebRequest(Method.GET, ACCESS_TOKEN, verifier, String.Empty);
            TokenGet(response);
        }

        public void TokenGet(string response)
        {
            if (response.Length > 0)
            {
                //Store the Token and Token Secret
                NameValueCollection qs = HttpUtility.ParseQueryString(response);
                if (qs["oauth_token"] != null)
                {
                    this.Token = qs["oauth_token"];
                }
                if (qs["oauth_token_secret"] != null)
                {
                    this.TokenSecret = qs["oauth_token_secret"];
                }
            }
        }

        /// <summary>
        /// Submit a web request using oAuth.
        /// </summary>
        /// <param name="method">GET or POST</param>
        /// <param name="url">The full url, including the querystring.</param>
        /// <param name="postData">Data to post (querystring format)</param>
        /// <returns>The web server response.</returns>
        public string oAuthWebRequest(Method method, string url, string postData)
        {
            return oAuthWebRequest(method, url, null, postData);
        }
        
        public string oAuthWebRequest(Method method, string url, string verifier, string postData)
        {
            string outUrl = "";
            string querystring = "";
            string ret = "";

            //Setup postData for signing.
            //Add the postData to the querystring.
            if (method == Method.POST)
            {
                if (postData.Length > 0)
                {
                    //Decode the parameters and re-encode using the oAuth UrlEncode method.
                    NameValueCollection qs = HttpUtility.ParseQueryString(postData);
                    postData = "";
                    foreach (string key in qs.AllKeys)
                    {
                        if (postData.Length > 0)
                        {
                            postData += "&";
                        }
                        qs[key] = HttpUtility.UrlDecode(qs[key]);
                     // qs[key] = this.UrlEncode(qs[key]); // <- not working in multibyte characters
                        qs[key] = this.UrlEncode(qs[key], Encoding.GetEncoding("utf-8"));   /* {@@} */

                        postData += key + "=" + qs[key];
                    }
                    if (url.IndexOf("?") > 0)
                    {
                        url += "&";
                    }
                    else
                    {
                        url += "?";
                    }
                    url += postData;
                }
            }

            Uri uri = new Uri(url);

            string nonce = this.GenerateNonce();
            string timeStamp = this.GenerateTimeStamp();

            //Generate Signature
            string sig;
            if (url.StartsWith(ACCESS_TOKEN_VIA_XAUTH))
                sig = this.GenerateSignature(uri,
                        this.ConsumerKey,
                        this.ConsumerSecret,
                        null,
                        null,
                        method.ToString(),
                        timeStamp,
                        nonce,
                        null,
                        out outUrl,
                        out querystring);
            else
                sig = this.GenerateSignature(uri,
                        this.ConsumerKey,
                        this.ConsumerSecret,
                        this.Token,
                        this.TokenSecret,
                        method.ToString(),
                        timeStamp,
                        nonce,
                        verifier,
                        out outUrl,
                        out querystring);

            querystring += "&oauth_signature=" + HttpUtility.UrlEncode(sig);

            //Convert the querystring to postData
            /*
            if (method == Method.POST)
            {
                postData = querystring;
                querystring = "";
            }
            */

            if (querystring.Length > 0)
            {
                outUrl += "?";
            }

            if (method == Method.POST)                                      /* {@@} */
                ret = Tumblen3.Utility.PostWebPage(                         /* {@@} */
                            outUrl + querystring, null,                     /* {@@} */
                            "application/x-www-form-urlencoded",            /* {@@} */
                            Encoding.GetEncoding("utf-8"));                 /* {@@} */
            else                                                            /* {@@} */
                ret = Tumblen3.Utility.GetWebPage(outUrl + querystring);    /* {@@} */

            return ret;
        }
    }
}
