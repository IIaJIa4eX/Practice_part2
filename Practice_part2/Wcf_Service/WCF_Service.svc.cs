using System.ServiceModel;
using Wcf_Service.Interfaces;

namespace Wcf_Service
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class WCF_Service : IWcf_Servise
    {
        private readonly IStatisticService _statService;
        private readonly ISettingsService _settingsService;
        private readonly IRunScripts _runScript;

        public WCF_Service()
        {
            _statService = new StatisticService();
            _settingsService = new SettingsService();
            _runScript = new RunScripts(_statService, _settingsService, Callback);
        }

        public void RunScript()
        {
            _runScript.RunScript(10);

        }

        public void UpdateAndCompile(string path)
        {
            _settingsService.FileName = path;
            _runScript.Compile();
        }

        IWcf_Callback Callback
        {
            get
            {
                if (OperationContext.Current != null)
                    return OperationContext.Current.GetCallbackChannel<IWcf_Callback>();
                else
                    return null;
            }
        }
    }
}
