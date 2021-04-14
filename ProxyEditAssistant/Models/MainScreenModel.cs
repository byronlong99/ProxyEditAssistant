using ProxyEditAssistant.Common;
using ProxyEditAssistant.Logic;

namespace ProxyEditAssistant.Models
{
    public class MainScreenModel : ModelBase
    {
        public string SourceDirectory { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        public string Test { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        
        public MainScreenModel()
        {
        }
        
        public void GenerateProxies()
        {
            Test = "Hello";
            
            var program = new ProxyBuilder();
            
            program.BuildProxies();
        }
    }
}