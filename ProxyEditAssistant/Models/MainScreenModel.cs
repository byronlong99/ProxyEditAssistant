using System.Threading.Tasks;
using ProxyEditAssistant.Common;
using ProxyEditAssistant.Logic;

namespace ProxyEditAssistant.Models
{
    public class MainScreenModel : ModelBase
    {
        public string SourceDirectory { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        public string Output { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        private readonly ProxyBuilder _proxyBuilder;
        
        public delegate void Del(string message);

        public MainScreenModel()
        {
            _proxyBuilder = new ProxyBuilder();
            _proxyBuilder.CallBack += UpdateStats;
        }
        
        public void GenerateProxies()
        {
            var task = new Task(() => _proxyBuilder.BuildProxies());
            task.Start();
            //task.ContinueWith(q => LineItemAddComplete(), TaskScheduler.FromCurrentSynchronizationContext()); 
        }

        private void UpdateStats(string message)
        {
            Output = "Hello";
        }
    }
}