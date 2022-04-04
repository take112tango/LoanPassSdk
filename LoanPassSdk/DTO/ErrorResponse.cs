

using Newtonsoft.Json;

namespace Take112Tango.Libs.LoanPassSdk.DTO
{
    public class ErrorResponse : ReqResBase
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        public string Message { get; set; }
    }
}
