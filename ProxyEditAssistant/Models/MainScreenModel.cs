using ProxyEditAssistant.Common;
using ProxyEditAssistant.Logic;

namespace ProxyEditAssistant.Models
{
    public class MainScreenModel : ModelBase
    {
        public string SourceDirectory { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        public string Output { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        
        public MainScreenModel()
        {
        }
        
        public void GenerateProxies()
        {
            var program = new ProxyBuilder(Output);
            
            program.BuildProxies();
        }
    }
}