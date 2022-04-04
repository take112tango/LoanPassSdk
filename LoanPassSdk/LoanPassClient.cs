using System;
using System.Net.Http;
using System.Threading.Tasks;
using Take112Tango.Libs.LoanPassSdk.DTO;
using Take112Tango.Libs.LoanPassSdk.Utils;

namespace Take112Tango.Libs.LoanPassSdk
{
    /// <summary>
    /// https://api.loanpass.io/v1/swagger#/
    /// TODO https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
    /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-5.0
    /// </summary>
    public class LoanPassClient : ILoanPassClient
    {
        private readonly HttpClient _httpClient = new();


        private readonly Settings _settings;

        public LoanPassClient(Settings settings)
        {
            _settings = settings;

            _httpClient.BaseAddress = new Uri(_settings.UrlBase);

            var defaultHeaders = _httpClient.DefaultRequestHeaders;
            defaultHeaders.Add("Authorization", _settings.ApiKey);
        }

        public string ApiConfig => Settings.ApiConfig;
        public string ApiExecSummary => Settings.ApiExecSummary;
        public string ApiExecProduct => Settings.ApiExecProduct;

        public async Task<ConfigResponse> GetConfigurationAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ApiConfig);
            var stJson = await response.SafeReadAsStringAsync();

            var result = await Task.Run(() => stJson.FromJson<ConfigResponse>());
            return result;
        }

        public async Task<ExecSummaryResponse> ExecSummaryAsync(ExecSummaryRequest request)
        {
            using HttpContent content = HttpUtil.CreateHttpJsonContent(request);

            HttpResponseMessage response = await _httpClient.PostAsync(ApiExecSummary, content);

            var stJson = await response.SafeReadAsStringAsync();

            var result = await Task.Run(() => stJson.FromJson<ExecSummaryResponse>());
            return result;
        }

        public async Task<ExecProductResponse> ExecProductAsync(ExecProductRequest request)
        {
            using HttpContent content = HttpUtil.CreateHttpJsonContent(request);

            HttpResponseMessage response = await _httpClient.PostAsync(ApiExecProduct, content);

            var stJson = await response.SafeReadAsStringAsync();

            var result = await Task.Run(() => stJson.FromJson<ExecProductResponse>());
            return result;
        }


    }
}
