
namespace Take112Tango.Libs.LoanPassSdk.TypeGenerator.Settings
{

    /// <summary>
    /// Generator Settings
    /// </summary>
    public class GenSettings
    {
        public Common Shared { get; set; }

        public FieldDef Field { get; set; }

        public EnumDef Enum { get; set; }

        public class Common
        {
            public string PackageName { get; set; } = "Take112Tango.Libs.LoanPassSdk.Generated";
        }

        public class FieldDef
        {
            public string FileTemplate { get; set; }
            public string ClassName { get; set; } = "KnownFieldId";

        }

        public class EnumDef
        {
            public string FileTemplate { get; set; }
            public string ClassName { get; set; } = "KnownEnumId";
        }
    }
}
