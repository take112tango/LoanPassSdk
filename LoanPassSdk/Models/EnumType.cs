using System.Collections.Generic;

namespace Take112Tango.Libs.LoanPassSdk.Models
{
    public class EnumType
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<EnumVariant> Variants { get; set; }
    }
}
