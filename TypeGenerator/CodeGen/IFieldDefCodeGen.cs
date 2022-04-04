using System.Collections.Generic;
using System.Threading.Tasks;
using Take112Tango.Libs.LoanPassSdk.Models;

namespace Take112Tango.Libs.LoanPassSdk.TypeGenerator.CodeGen
{
    public interface IFieldDefCodeGen
    {
        Task<string> ExecuteAsync(IEnumerable<FieldDefinition> fields);
    }
}
