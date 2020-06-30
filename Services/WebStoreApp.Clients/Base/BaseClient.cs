using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace WebStoreApp.Clients.Base
{
    public abstract class BaseClient
    {
        protected readonly string _ServiceAddress;
        protected readonly HttpClient _Client;

        protected BaseClient(IConfiguration Configuration, string ServiceAddress)
        {
            _ServiceAddress = ServiceAddress;

            _Client = new HttpClient
            {
                BaseAddress = new Uri(Configuration["WebApiURL"]),
                DefaultRequestHeaders =
                {
                    Accept = { new MediaTypeWithQualityHeaderValue("application/json") }
                }
            };
        }

        public T Get<T>(string url) => GetAsync<T>(url).Result;
        public async Task<T> GetAsync<T>(string url, CancellationToken Cancel = default)
        {
            var responsee = await _Client.GetAsync(url, Cancel);
            return await responsee.EnsureSuccessStatusCode().Content.ReadAsAsync<T>(Cancel);
        }

        public HttpResponseMessage Post<T>(string url, T item) => PostAsync(url, item).Result;
        public async Task<HttpResponseMessage> PostAsync<T>(string url, T item, CancellationToken cancel = default)
        {
            var response = await _Client.PostAsJsonAsync(url, item, cancel);
            return response.EnsureSuccessStatusCode();
        }

        public HttpResponseMessage Put<T>(string url, T item) => PutAsync(url, item).Result;
        public async Task<HttpResponseMessage> PutAsync<T>(string url, T item, CancellationToken cancel = default)
        {
            var response = await _Client.PutAsJsonAsync(url, item, cancel);
            return response.EnsureSuccessStatusCode();
        }

        public HttpResponseMessage Delete(string url) => DeleteAsync(url).Result;
        public async Task<HttpResponseMessage> DeleteAsync(string url, CancellationToken cancel = default) => await _Client.DeleteAsync(url, cancel);
    }
}
