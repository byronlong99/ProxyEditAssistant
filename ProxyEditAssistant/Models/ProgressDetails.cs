using System;

namespace ProxyEditAssistant.Models
{
    public class ProgressDetails
    {
        public string CurrentFileNumber { get; set; }
        public string TotalFileCount { get; set; }
        public double? BitRate { get; set; }
        public double FramesPerSecond { get; set; }
        public long Frame { get; set; }
        public TimeSpan ProcessedDuration { get; set; }
        public int SizeKB { get; set; }
        public TimeSpan TotalDuration { get; set; }
        public double PercentComplete { get; set; }
    }
}