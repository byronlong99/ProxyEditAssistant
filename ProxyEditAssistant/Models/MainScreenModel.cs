using ProxyEditAssistant.Common;

namespace ProxyEditAssistant.Models
{
    public class MainScreenModel : ModelBase
    {
        public string IsOffline { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
    }
}