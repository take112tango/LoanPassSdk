using System.Threading.Tasks;
using Take112Tango.Libs.LoanPassSdk.DTO;

namespace Take112Tango.Libs.LoanPassSdk
{
    public interface ILoanPassClient
    {
        Task<ConfigResponse> GetConfigurationAsync();

        Task<ExecSummaryResponse> ExecSummaryAsync(ExecSummaryRequest request);
        Task<ExecProductResponse> ExecProductAsync(ExecProductRequest request);
    }
}
