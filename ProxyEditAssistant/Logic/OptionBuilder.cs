using System.Collections.Generic;
using ProxyEditAssistant.Common;
using ProxyEditAssistant.Models;

namespace ProxyEditAssistant.Logic
{
    public class OptionBuilder
    {
        private List<OptionModel> _options;
        private readonly List<Resolution> _resolutions;

        public OptionBuilder(List<Resolution> resolutions)
        {
            _resolutions = resolutions;
        }

        public List<OptionModel> BuildOptions()
        {
            _options = new List<OptionModel>();

            foreach (var resolution in _resolutions)
            {
                var optionModel = new OptionModel();
                optionModel.ResolutionColor = "#b6ffff";
                optionModel.ResolutionText = $"{resolution.Width.ToString()}p";
                optionModel.Color = "#90caf9";
                optionModel.BuildButtonText = "true";
                optionModel.Resolution = resolution;
                _options.Add(optionModel);
            }
            
            return _options;
        }
    }
}