using System;
using CommandLine;
using Microsoft.Extensions.Configuration;
using Take112Tango.Libs.LoanPassSdk.TypeGenerator.Utils;


namespace Take112Tango.Libs.LoanPassSdk.TypeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Parser.Default.ParseArguments<CmdOptions>(args)
                .WithParsed(o =>
                {
                    string stError = o.Validate();
                    if (!String.IsNullOrEmpty(stError))
                    {
                        Console.WriteLine(stError);
                        Environment.Exit(1);
                    }

                    //Console.WriteLine(o.ToJson());

                    var config = InitOptions<AppConfig>();
                    //Console.WriteLine(config.ToJson());

                    Executor executor = null;
                    try
                    {
                        var settings = config.Generators.GetSettings(o.Language);

                        executor = new Executor(o, settings);
                        executor.ProgressEvent += Executor_ProgressEvent;
                        executor.Exec();
                    }
                    finally
                    {
                        if (executor != null) 
                            executor.ProgressEvent -= Executor_ProgressEvent;
                    }
                    
                })
                .WithNotParsed(o =>
                {
                    Console.WriteLine("\nFailed to parse!");
                }); ;

            Console.WriteLine("\n\nBye!");
        }

        private static void Executor_ProgressEvent(object sender, ExecProgressEventArgs e)
        {
            if (String.IsNullOrEmpty(e.Msg))
                return;

            Console.Write(e.Msg);
        }

        private static T InitOptions<T>()
            where T : new()
        {
            var config = InitConfig();
            return config.Get<T>();
        }

        /// <summary>
        /// https://blog.hildenco.com/2020/05/configuration-in-net-core-console.html
        /// </summary>
        /// <returns></returns>
        private static IConfigurationRoot InitConfig()
        {
            //var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                //.AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
