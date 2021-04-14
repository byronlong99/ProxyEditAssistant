using System.Globalization;
using System.Threading.Tasks;
using ProxyEditAssistant.Common;
using ProxyEditAssistant.Logic;

namespace ProxyEditAssistant.Models
{
    public class MainScreenModel : ModelBase
    {
        public string SourceDirectory { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        public string FileCount { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        public string TotalFiles { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        public string BitRate { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        public string FPS { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        private readonly ProxyBuilder _proxyBuilder;
        
        public MainScreenModel()
        {
            _proxyBuilder = new ProxyBuilder(DisplayProgress);
        }
        
        public void GenerateProxies()
        {
            var task = new Task(() => _proxyBuilder.BuildProxies());
            task.Start();
        }

        private void DisplayProgress(ProgressDetails message)
        {
            FileCount = message.CurrentFileNumber;
            TotalFiles = message.TotalFileCount;
            BitRate = message.BitRate.ToString();
            FPS = message.FPS.ToString(CultureInfo.InvariantCulture);
        }
        

    }
}