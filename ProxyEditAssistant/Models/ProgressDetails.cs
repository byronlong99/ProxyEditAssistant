namespace ProxyEditAssistant.Models
{
    public class ProgressDetails
    {
        public string CurrentFileNumber { get; set; }
        public string TotalFileCount { get; set; }
        public double? BitRate { get; set; }
        public double FramesPerSecond { get; set; }
    }
}