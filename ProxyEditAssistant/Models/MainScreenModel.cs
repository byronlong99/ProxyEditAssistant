using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using ProxyEditAssistant.Common;
using ProxyEditAssistant.Logic;

namespace ProxyEditAssistant.Models
{
    public class Option
    {
        public string ResolutionText { get; set; }
        public Resolution Resolution { get; set; }
    }
    
    public class MainScreenModel : ModelBase
    {
        private readonly ProxyBuilder _proxyBuilder;
        
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
        
        public ObservableCollection<Option> Options { get; set; }
    
        
        public MainScreenModel()
        {
            _proxyBuilder = new ProxyBuilder(DisplayProgress);
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
            BuildOptions();
        }

        private void BuildOptions()
        {
            Options = new ObservableCollection<Option>();
            Options.Add(new Option { ResolutionText = "360p", Resolution = new Resolution { Height = 360, Width = 360}});
            Options.Add(new Option { ResolutionText = "480p", Resolution = new Resolution { Height = 480, Width = 480}});
            Options.Add(new Option { ResolutionText = "720p", Resolution = new Resolution { Height = 480, Width = 720}});
            Options.Add(new Option { ResolutionText = "1080p", Resolution = new Resolution { Height = 480, Width = 1080}});
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
            FramesPerSecond = message.FramesPerSecond.ToString(CultureInfo.InvariantCulture);
            Frame = message.Frame.ToString(CultureInfo.InvariantCulture);
            ProcessedDuration = message.ProcessedDuration.ToString();
            SizeKB = message.SizeKB.ToString();
            TotalDuration = message.TotalDuration.ToString();
            PercentComplete = message.PercentComplete.ToString(CultureInfo.InvariantCulture);
        }
    }
}