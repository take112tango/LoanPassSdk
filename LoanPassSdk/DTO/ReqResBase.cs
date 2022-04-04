

using System;
using Newtonsoft.Json;

namespace Take112Tango.Libs.LoanPassSdk.DTO
{
    public abstract class ReqResBase
    {
        [JsonProperty(Order = -100)]
        public DateTime CurrentTime { get; set; } = DateTime.Now;

        [JsonProperty(Order = -99, NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }

        protected ReqResBase() { }

        protected ReqResBase(DateTime time)
        {
            CurrentTime = time;
        }

    }
}
