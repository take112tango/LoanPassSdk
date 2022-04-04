
namespace Take112Tango.Libs.LoanPassSdk
{
    public class Settings
    {
        public const string ApiConfig = "configuration";
        public const string ApiExecSummary = "execute-summary";
        public const string ApiExecProduct = "execute-product";

        public Settings(string apiKey, string urlBase = "https://api.loanpass.io/v1/")
        {
            this.UrlBase = urlBase;
            this.ApiKey = apiKey;
        }


        
        public string UrlBase { get; init; }
            
        public string ApiKey { get; init; }

    }
}
