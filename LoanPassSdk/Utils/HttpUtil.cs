

using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Take112Tango.Libs.LoanPassSdk.DTO;
using Take112Tango.Libs.LoanPassSdk.Exceptions;

namespace Take112Tango.Libs.LoanPassSdk.Utils
{
    public static class HttpUtil
    {
        public static async Task<string> SafeReadAsStringAsync(this HttpResponseMessage response)
        {
            var stJson = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                ErrorResponse errorResponse = null;
                try
                {
                    errorResponse = stJson.FromJson<ErrorResponse>();
                }
                catch
                {
                    //ltang: Swallow
                }

                if (errorResponse == null)
                    response.EnsureSuccessStatusCode();
                else
                    throw new ResponseException(errorResponse);
            }
            return stJson;
        }

        public static HttpContent CreateHttpJsonContent(object content)
        {
            HttpContent httpContent = null;

            if (content != null)
            {
                MemoryStream ms = new MemoryStream();
                content.ToJsonStream(ms);
                ms.Seek(0, SeekOrigin.Begin);
                httpContent = new StreamContent(ms);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return httpContent;
        }

    }
}
