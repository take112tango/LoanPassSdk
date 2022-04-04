
using System;
using System.IO;
using System.Threading.Tasks;
using Take112Tango.Libs.LoanPassSdk.DTO;
using Take112Tango.Libs.LoanPassSdk.TypeGenerator.CodeGen;
using Take112Tango.Libs.LoanPassSdk.TypeGenerator.CodeGen.CS;
using Take112Tango.Libs.LoanPassSdk.TypeGenerator.Services;
using Take112Tango.Libs.LoanPassSdk.TypeGenerator.Settings;
using Take112Tango.Libs.LoanPassSdk.TypeGenerator.Utils;

namespace Take112Tango.Libs.LoanPassSdk.TypeGenerator
{
    public class Executor
    {
        private readonly CmdOptions _cmdOptions;
        private readonly GenSettings _settings;

        private ConfigResponse _configResponse;
        public Executor(CmdOptions cmdOptions, GenSettings settings)
        {
            _cmdOptions = cmdOptions;
            _settings = settings;
        }

        public event EventHandler<ExecProgressEventArgs> ProgressEvent;

        public void Exec()
        {
            var targets = _cmdOptions.Targets;

            var progress = new ExecProgressEventArgs();

            _configResponse = ConfigResponse.FromJsonFile(_cmdOptions.FileIn);

            progress.Msg = $"\nInput: {_cmdOptions.FileIn}\nLanguage: {Language}\nTargets: {targets}\n";
            OnProgressChanged(progress);

            var targetFlags = Enum.GetValues<TypeDefTargets>();

            Parallel.ForEach(targetFlags, target =>
            {
                if (target == TypeDefTargets.None || target == TypeDefTargets.All)
                {
                    //ltang: Ignore
                }
                else if (targets.HasFlag(target))
                {
                    switch (target)
                    {
                        case TypeDefTargets.Enum:
                            HandleEnumDef();
                            break;
                        case TypeDefTargets.Field:
                            HandleFieldDef();
                            break;
                        default:
                            throw new NotImplementedException($"CodeGen for {target} is not supported yet.");
                    }
                }
            });

            progress.Msg = null;
            progress.IsRunning = false;
            OnProgressChanged(progress);
        }


        private LanguageOpt Language => _cmdOptions.Language;
        private string FolderOut => _cmdOptions.FolderOut;

        private void HandleEnumDef()
        {
            var progress = new ExecProgressEventArgs();

            IEnumDefCodeGen codeGen = CodeGenFactory.CreateEnumDef(Language);
            if (codeGen == null)
            {
                Console.WriteLine($"{nameof(EnumDefCodeGen)} for language {Language} is not supported yet!");
                return;
            }

            progress.Msg = $"\nExecuting {nameof(EnumDefCodeGen)}...";
            OnProgressChanged(progress);

            var generator = new EnumDefGenerator(_configResponse.Enumerations, _settings, codeGen);
            string code = generator.ExecuteAsync().Result;

            string savedFilename = Save(code, generator.FileTemplate);

            progress.Msg = $"\n => {savedFilename}";
            OnProgressChanged(progress);
        }

        private void HandleFieldDef()
        {
            var progress = new ExecProgressEventArgs();

            IFieldDefCodeGen codeGen = CodeGenFactory.CreateFieldDef(Language);
            if (codeGen == null)
            {
                Console.WriteLine($"{nameof(FieldDefCodeGen)} for language {Language} is not supported yet!");
                return;
            }

            progress.Msg = $"\nExecuting {nameof(FieldDefCodeGen)}...";
            OnProgressChanged(progress);
            
            var generator = new FieldDefGenerator(_configResponse.CreditApplicationFields, _settings, codeGen);
            string code = generator.ExecuteAsync().Result;

            string savedFilename = Save(code, generator.FileTemplate);
            progress.Msg = $"\n => {savedFilename}";
            OnProgressChanged(progress);
        }

        private string Save(string code, string fileTemplate)
        {
            string filename = Path.GetFileNameWithoutExtension(fileTemplate);
            if (!String.IsNullOrEmpty(FolderOut))
                filename = Path.Combine(FolderOut, filename);

            File.WriteAllText(filename, code);
            return filename;
        }

        private void OnProgressChanged(ExecProgressEventArgs e)
        {
            try
            {
                EventHandler<ExecProgressEventArgs> handler = this.ProgressEvent;
                handler?.Invoke(this, e);
            }
            catch
            {
                //ltang: Ok to swallow
            }
        }
    }
}
