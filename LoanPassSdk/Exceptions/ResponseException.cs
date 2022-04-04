using System;
using Take112Tango.Libs.LoanPassSdk.DTO;

namespace Take112Tango.Libs.LoanPassSdk.Exceptions
{
    public class ResponseException : ApplicationException
    {
        public int HttpStatus { get; set; }
        public string Uri { get; set; }
        public string Request { get; set; }

        public string RequestId { get; }
        public string ErrorCode { get; }

        public ResponseException(ErrorResponse response) : base(response.Message)
        {
            RequestId = response.RequestId;
            ErrorCode = response.ErrorCode;
        }
    }
}
