using System.Collections.Generic;
using ProxyEditAssistant.Common;
using ProxyEditAssistant.Models;

namespace ProxyEditAssistant.Logic
{
    public class OptionBuilder
    {
        private readonly List<OptionModel> _options;
        
        private readonly List<Resolution> _resolutions;

        public OptionBuilder(List<Resolution> resolutions)
        {
            _resolutions = resolutions;
            _options = new List<OptionModel>();
        }
        
        public List<OptionModel> BuildOptions()
        {
            _options.Add(new OptionModel { ResolutionColor = "#b6ffff", ResolutionText = "360p", Color = "#90caf9", BuildButtonText = "true", Resolution = new Resolution { Height = 360, Width = 360}});
            _options.Add(new OptionModel { ResolutionColor = "#b6ffff", ResolutionText = "480p", Color = "#90caf9", BuildButtonText = "true", Resolution = new Resolution { Height = 480, Width = 480}});
            _options.Add(new OptionModel { ResolutionColor = "#b6ffff",  ResolutionText = "720p", Color = "#90caf9", BuildButtonText = "true", Resolution = new Resolution { Height = 480, Width = 720}});
            _options.Add(new OptionModel { ResolutionColor = "#b6ffff",  ResolutionText = "1080p", Color = "#90caf9", BuildButtonText = "true", Resolution = new Resolution { Height = 480, Width = 1080}});

            return _options;
        }
    }
}