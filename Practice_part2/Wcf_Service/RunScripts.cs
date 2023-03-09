using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using Wcf_Service.Interfaces;

namespace Wcf_Service
{//for_review
    public class RunScripts : IRunScripts
    {

        private readonly IStatisticService _statService;
        private readonly ISettingsService _settingsService;
        private readonly IWcf_Callback _callback;
        private CompilerResults _compResults = null;
        public RunScripts(IStatisticService statService, ISettingsService settingsService, IWcf_Callback callback)
        {
            _statService = statService;
            _settingsService = settingsService;
            _callback = callback;
        }
        public bool Compile()
        {
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateInMemory = true;
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Data.dll");
            parameters.ReferencedAssemblies.Add("System.Core.dll");
            parameters.ReferencedAssemblies.Add("Microsoft.CSharp.dll");

            parameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);

            FileStream stream = new FileStream(_settingsService.FileName, FileMode.Open);
            byte[] buffer;
            try
            {
                int lenght = (int)stream.Length;
                buffer = new byte[lenght];
                int count;
                int sum = 0;
                while((count = stream.Read(buffer,sum,lenght - sum)) > 0)
                {
                    sum += count;
                }
            }
            finally
            {
                stream.Close();
            }

            CSharpCodeProvider provider= new CSharpCodeProvider();
            _compResults = provider.CompileAssemblyFromSource(parameters, System.Text.Encoding.UTF8.GetString(buffer));

            if (_compResults.Errors != null && _compResults.Errors.Count != 0)
            {
                string compileErrors = string.Empty;
                for(int i = 0; i < _compResults.Errors.Count; i++)
                {
                    if(compileErrors != string.Empty)
                    {
                        compileErrors += "\n";
                    }
                    compileErrors += _compResults.Errors[i];
                }

                return false;
            }

            return true;

        }

        public void RunScript(int count)
        {
            if(_compResults ==null || (_compResults != null && _compResults.Errors != null && _compResults.Errors.Count >0))
            {
                if(Compile() == false)
                {
                    return;
                }
            }

            Type t = _compResults.CompiledAssembly.GetType("Script_number1.NumberOne");
            if (t == null)
            {
                return;
            }

            MethodInfo entryPoint = t.GetMethod("HeavensDoor");
            if (entryPoint == null)
            {
                return;
            }

            Task.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    if ((bool)entryPoint.Invoke(Activator.CreateInstance(t), null))
                    {
                        _statService.SuccessTasks++;
                    }
                    else
                    {
                        _statService.ErrorTasks++;
                    }

                    _statService.AllTasks++;

                    _callback.UpdateStatistics((StatisticService)_statService);
                    Thread.Sleep(500);
                }
            });
            
        }
    }
}