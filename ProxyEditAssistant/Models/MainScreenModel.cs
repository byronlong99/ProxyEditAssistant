using System.Threading.Tasks;
using ProxyEditAssistant.Common;
using ProxyEditAssistant.Logic;

namespace ProxyEditAssistant.Models
{
    public class MainScreenModel : ModelBase
    {
        public string SourceDirectory { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        public string Output { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        public ProgressDetails Progress { get => GetPropertyValue<ProgressDetails>(); set => SetPropertyValue(value); }
        private readonly ProxyBuilder _proxyBuilder;
        
        public MainScreenModel()
        {
            _proxyBuilder = new ProxyBuilder(DisplayProgress);
        }
        
        public void GenerateProxies()
        {
            var task = new Task(() => _proxyBuilder.BuildProxies());
            task.Start();
            //task.ContinueWith(q => LineItemAddComplete(), TaskScheduler.FromCurrentSynchronizationContext()); 
        }

        private void DisplayProgress(string message)
        {
            Progress.FileCount = message;
        }
        
        public class ProgressDetails
        {
            public string FileCount { get; set; }
        }
    }
}