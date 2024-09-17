using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NsisoLauncherX.Core.Net
{
    public class NetRequester
    {

        /// <summary>
        /// NsisoLauncher目前名称.
        /// </summary>
        private string ClientName { get; set; } = "NsisoLauncherX";

        /// <summary>
        /// NsisoLauncher目前版本号.
        /// </summary>
        private string? ClientVersion { get; set; } = Assembly.GetExecutingAssembly().GetName().Version?.ToString(2);
        
        /// <summary>
        /// 表示Web请求中使用的http客户端.
        /// </summary>
        public HttpClient Client { get; private set; }
        
        /// <summary>
        /// 表示http客户端handler
        /// </summary>
        public HttpClientHandler ClientHandler { get; private set; }
        
        /// <summary>
        /// 使用的代理服务
        /// </summary>
        public IWebProxy? NetProxy
        {
            get => this.ClientHandler.Proxy;
            set => this.ClientHandler.Proxy = value;
        }

        public NetRequester()
        {
            this.ClientHandler = new HttpClientHandler();
            this.Client = new HttpClient(this.ClientHandler) {/* Timeout = NetRequester.Timeout */};
            this.Client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(ClientName, ClientVersion));
            this.Client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue(CultureInfo.CurrentCulture.Name));
        }

        public  async Task<string> HttpGetStringAsync(string uri)
        {
            return await Client.GetStringAsync(uri);
        }

        public  async Task<HttpResponseMessage> HttpGetAsync(Uri uri, HttpCompletionOption option, CancellationToken cancellation)
        {
            return await Client.GetAsync(uri, option, cancellation);
        }

        public  async Task<HttpResponseMessage> HttpGetAsync(Uri uri)
        {
            return await Client.GetAsync(uri);
        }

        public  async Task<HttpResponseMessage> HttpGetAsync(Uri uri, CancellationToken cancellation)
        {
            return await Client.GetAsync(uri, cancellation);
        }

        public  async Task<HttpResponseMessage> HttpGetAsync(string uri)
        {
            return await Client.GetAsync(uri);
        }

        public  async Task<HttpResponseMessage> HttpGetAsync(string uri, CancellationToken cancellation)
        {
            return await Client.GetAsync(uri, cancellation);
        }

        public  async Task<HttpResponseMessage> HttpPostAsync(Uri uri, HttpContent arg)
        {
            return await Client.PostAsync(uri, arg);
        }

        public  async Task<HttpResponseMessage> HttpPostAsync(Uri uri, Dictionary<string, string> arg)
        {
            return await Client.PostAsync(uri, new FormUrlEncodedContent(arg));
        }

        public  async Task<HttpResponseMessage> HttpPostAsync(string uri, Dictionary<string, string> arg)
        {
            return await Client.PostAsync(uri, new FormUrlEncodedContent(arg));
        }

        public  async Task<HttpResponseMessage> HttpPostAsync(Uri uri, HttpContent arg, CancellationToken cancellation)
        {
            return await Client.PostAsync(uri, arg, cancellation);
        }

        public  async Task<HttpResponseMessage> HttpPostAsync(Uri uri, Dictionary<string, string> arg, CancellationToken cancellation)
        {
            return await Client.PostAsync(uri, new FormUrlEncodedContent(arg), cancellation);
        }

        public  async Task<HttpResponseMessage> HttpPostAsync(string uri, Dictionary<string, string> arg, CancellationToken cancellation)
        {
            return await Client.PostAsync(uri, new FormUrlEncodedContent(arg), cancellation);
        }

        public  async Task<HttpResponseMessage> HttpSendAsync(HttpRequestMessage httpRequest)
        {
            return await Client.SendAsync(httpRequest);
        }

        public  async Task<HttpResponseMessage> HttpSendAsync(HttpRequestMessage httpRequest, CancellationToken cancellation)
        {
            return await Client.SendAsync(httpRequest, cancellation);
        }
    }
}