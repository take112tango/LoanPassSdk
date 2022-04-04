using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using CommandLine;
using CommandLine.Text;
using Take112Tango.Libs.LoanPassSdk.TypeGenerator.CodeGen;
using Take112Tango.Libs.LoanPassSdk.Utils;

namespace Take112Tango.Libs.LoanPassSdk.TypeGenerator
{
    /// <summary>
    /// https://github.com/commandlineparser/commandline/wiki
    /// </summary>
    public class CmdOptions
    {
        private const string FileInSample = @"Samples/config_response.json";
        private const LanguageOpt DefaultLanguage = LanguageOpt.Cs;
        private const TypeDefTargets DefaultTargets = TypeDefTargets.All;

        public string Validate()
        {
            var sb = new StringBuilder();
            if (!File.Exists(FileIn))
                sb.AppendLine($"File not found: {FileIn}");

            if (!String.IsNullOrEmpty(FolderOut) && !Directory.Exists(FolderOut))
                sb.AppendLine($"Folder not found: {FolderOut}");

            return sb.ToString();
        }

        [Option('i', "in", Required = true, HelpText = "Input json filename")]
        public string FileIn { get; set; }

        public LanguageOpt Language { get; private set; }
        private string _languageAsText;
        [Option('l', "language", Required = true, HelpText = "Set language of generated types")]
        public string LanguageAsText
        {
            get => _languageAsText;
            set
            {
                if (String.IsNullOrEmpty(value))
                    Language = DefaultLanguage;
                else
                    Language = Enum.Parse<LanguageOpt>(value, true);
                
                _languageAsText = value;
            }
        }

        public TypeDefTargets Targets { get; private set; }
        private IList<string> _targetsAsTexts;

        [Option('t', "targets", Required = false, HelpText = "Set type definition target(s) of generated types")]
        public IList<string> TargetAsTexts
        {
            get => _targetsAsTexts;
            set
            {
                if (!value.Any())
                    Targets = DefaultTargets;
                else
                    Targets = (TypeDefTargets) EnumUtil.TextsToEnumFlags(typeof(TypeDefTargets), value,
                        (int) TypeDefTargets.None);

                _targetsAsTexts = value;
            }
        }
        

        [Option('o', "out", Required = false, HelpText = "Output folder")]
        public string FolderOut { get; set; }


        [Usage(ApplicationAlias = "./Take112Tango.Libs.LoanPassSdk.TypeGenerator.exe")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                yield return new Example("Generate types for all in C#", new CmdOptions
                {
                    LanguageAsText = DefaultLanguage.ToString(),
                    FileIn = FileInSample
                });

                yield return new Example("Generate types for Enum only in C#", new CmdOptions
                {
                    LanguageAsText = DefaultLanguage.ToString(),
                    FileIn = FileInSample,
                    TargetAsTexts = new List<string>{"Enum"}
                });

                yield return new Example("Generate types for Field only in Java", new CmdOptions
                {
                    LanguageAsText = LanguageOpt.Java.ToString(),
                    FileIn = FileInSample,
                    TargetAsTexts = new List<string> { "Field" }
                });

                yield return new Example("Generate types for Enum and Field in Java", new CmdOptions
                {
                    LanguageAsText = LanguageOpt.Java.ToString(),
                    FileIn = FileInSample,
                    TargetAsTexts = new List<string> { "Enum", "Field" }
                });

                yield return new Example("Generate types for Enum only in GraphQL", new CmdOptions
                {
                    LanguageAsText = LanguageOpt.Gql.ToString(),
                    FileIn = FileInSample,
                    TargetAsTexts = new List<string> { "Enum" }
                });

            }
        }

    }
}
