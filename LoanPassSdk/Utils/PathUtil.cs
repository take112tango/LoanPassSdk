
using System;
using System.IO;
using System.Reflection;

namespace Take112Tango.Libs.LoanPassSdk.Utils
{
    public static class PathUtil
    {
        private static readonly object _runningDirLock = new();
        private static string _runningDir = null;

        public static string CombineRunningDir(string filepath)
        {
            return Path.Combine(RunningDir(), filepath);
        }

        public static string RunningDir()
        {
            if (!string.IsNullOrEmpty(_runningDir))
                return _runningDir;

            try
            {
                lock (_runningDirLock)
                {
                    var assembly = Assembly.GetEntryAssembly();
                    if (assembly != null)
                        _runningDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                    if (string.IsNullOrEmpty(_runningDir))
                        _runningDir = AppDomain.CurrentDomain.BaseDirectory;
                }
            }
            catch (Exception)
            {
                //ltang: Swallow                    
            }
            return _runningDir;
        }
    }
}
