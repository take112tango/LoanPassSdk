using System.Collections.Generic;
using Take112Tango.Libs.LoanPassSdk.Models;
using Take112Tango.Libs.LoanPassSdk.Utils;

namespace Take112Tango.Libs.LoanPassSdk.DTO
{
    public class ConfigResponse : ReqResBase
    {
        public List<FieldDefinition> CreditApplicationFields { get; set; }
        public List<ProductFieldDefinition> ProductFields { get; set; }
        public List<EnumType> Enumerations { get; set; }
        
        public static ConfigResponse FromJsonFile(string filename) => JsonUtil.FromJsonFile<ConfigResponse>(filename);
    }
}
