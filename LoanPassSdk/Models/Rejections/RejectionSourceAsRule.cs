

namespace Take112Tango.Libs.LoanPassSdk.Models.Rejections
{
    public class RejectionSourceAsRule : AnyOfRejectionSource
    {
        public RejectionSourceOpt Type { get; } = RejectionSourceOpt.Rule;

        public string RuleId { get; set; }
    }
}
