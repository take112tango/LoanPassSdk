

using System;

namespace Take112Tango.Libs.LoanPassSdk.TypeGenerator.Utils
{
    public class ExecProgressEventArgs : EventArgs
    {
        public string Msg { get; set; }
        public bool IsRunning { get; set; } = true;

    }
}
