using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using ProxyEditAssistant.Common;
using ProxyEditAssistant.Logic;

namespace ProxyEditAssistant.Models
{
    public class Test
    {
        public string Resolution { get; set; }
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
        
        public ObservableCollection<Test> Options { get; set; }
    
        
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

            Options = new ObservableCollection<Test>();
            Options.Add(new Test() { Resolution = "360p"});
            Options.Add(new Test() { Resolution = "480p"});
            Options.Add(new Test() { Resolution = "720p"});
            Options.Add(new Test() { Resolution = "1080p"});
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