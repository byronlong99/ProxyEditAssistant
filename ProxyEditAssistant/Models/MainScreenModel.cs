using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using ProxyEditAssistant.Common;
using ProxyEditAssistant.Logic;

namespace ProxyEditAssistant.Models
{
    public class MainScreenModel : ModelBase
    {
        private readonly ProxyBuilder _proxyBuilder;
        private readonly IFileListBuilder _fileListBuilder;
        private List<Resolution> _resolutions;
        
        public string SourceDirectory { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        public string FileCount { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        public string TotalFiles { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        public string BitRate { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        public string FramesPerSecond { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        public string Frame { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        public string ProcessedDuration { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        public string SizeKB { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        public string TotalDuration { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        public string PercentComplete { get => GetPropertyValue<string>(); set => SetPropertyValue(value); }
        public ObservableCollection<OptionModel> Options { get; set; }

        public MainScreenModel()
        {
            CreateResolutions();
            BuildResolutionOptions();
            
            _fileListBuilder = new FileListBuilder();
            _proxyBuilder = new ProxyBuilder(DisplayProgress, _fileListBuilder);
            _proxyBuilder.SourceDirectory = @"TestVideos";
            FileCount = "N/A";
            TotalFiles = "N/A";
            BitRate = "N/A";
            FramesPerSecond = "N/A";
            Frame = "N/A";
            ProcessedDuration = "N/A";
            SizeKB = "N/A";
            TotalDuration = "N/A";
            PercentComplete = "N/A";
        }

        private void CreateResolutions()
        {
            _resolutions = new List<Resolution>();
            _resolutions.Add(new Resolution { Height = 100, Width = 360});
            _resolutions.Add(new Resolution { Height = 100, Width = 480});
            _resolutions.Add(new Resolution { Height = 100, Width = 720});
            _resolutions.Add(new Resolution { Height = 100, Width = 1080});
        }

        private void BuildResolutionOptions()
        {
            var optionBuilder = new OptionBuilder(_resolutions);
            var options = optionBuilder.BuildOptions();
            Options = new ObservableCollection<OptionModel>(options); }
        
        public void GenerateProxies()
        {
            var task = new Task(() => _proxyBuilder.BuildProxies());
            task.Start();
        }

        private void DisplayProgress(ProgressDetailsEvent message)
        {
            FileCount = message.CurrentFileNumber;
            TotalFiles = message.TotalFileCount;
            BitRate = message.BitRate.ToString();
            FramesPerSecond = message.FramesPerSecond.ToString(CultureInfo.InvariantCulture);
            Frame = message.Frame.ToString(CultureInfo.InvariantCulture);
            ProcessedDuration = message.ProcessedDuration.ToString();
            SizeKB = message.SizeKB.ToString();
            TotalDuration = message.TotalDuration.ToString();
            PercentComplete = message.PercentComplete.ToString(CultureInfo.InvariantCulture);
        }
    }
}