using System.Collections.Generic;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using ProxyEditAssistant.Common;
using ProxyEditAssistant.Models;

namespace ProxyEditAssistant.Logic
{
    public class ProxyBuilder
    {
        private const string SourceDirectory = @"TestVideos";
        // private const int Height = 360;
        // private const int Width = 640;
        private const int Height = 240;
        private const int Width = 426;
        private Resolution _videoResolution;
        private const string SourceDirectoryName = "Source";
        private int _totalFiles;
        private int _currentFile;
        private readonly IFileListBuilder _fileListBuilder;
        private List<string> _fileNames;

        private readonly DisplayStatistics _callBack;
        
        public delegate void DisplayStatistics(string message);

        public ProxyBuilder(DisplayStatistics callBack)
        {
            _callBack = callBack;
            _fileListBuilder = new FileListBuilder(SourceDirectory);
        }

        public void BuildProxies()
        {
            _videoResolution = new Resolution {Height = Height, Width = Width};
            _fileNames = _fileListBuilder.BuildListOfFiles(_videoResolution);
            ProcessFiles();
        }

        private void ProcessFiles()
        {
            _currentFile = 1;
            _totalFiles = _fileNames.Count;

            using (var engine = new Engine())
            {
                engine.ConvertProgressEvent += ConvertProgressEvent;
                engine.ConversionCompleteEvent += ConversionCompleteEvent;

                foreach (var fileName in _fileNames)
                {
                    Process(fileName, engine);
                    _currentFile++;
                }
            }
        }

        private void Process(string fileName, Engine engine)
        {
            var inputFile = new MediaFile {Filename = fileName};
            var outputFile = new MediaFile {Filename = fileName.Replace(SourceDirectoryName, _videoResolution.ToString())};

            var conversionOptions = new ConversionOptions
            {
                VideoAspectRatio = VideoAspectRatio.R16_9,
                VideoSize = VideoSize.Custom,
                AudioSampleRate = AudioSampleRate.Hz44100,
                CustomHeight = _videoResolution.Height,
                CustomWidth = _videoResolution.Width,
                VideoBitRate = 5000,
                //MaxVideoDuration = TimeSpan.FromSeconds(10)
            };

            engine.Convert(inputFile, outputFile, conversionOptions);
        }

        private void ConvertProgressEvent(object sender, ConvertProgressEventArgs e)
        {
            _callBack(_currentFile.ToString());
            // Console.Clear();
            // Console.WriteLine("\n------------\nConverting...\n------------");
            // Console.WriteLine("File Number: {0}", _currentFile);
            // Console.WriteLine("Total Files: {0}", _totalFiles);
            // Console.WriteLine("Bitrate: {0}", e.Bitrate);
            // Console.WriteLine("Fps: {0}", e.Fps);
            // Console.WriteLine("Frame: {0}", e.Frame);
            // Console.WriteLine("ProcessedDuration: {0}", e.ProcessedDuration);
            // Console.WriteLine("SizeKb: {0}", e.SizeKb);
            // Console.WriteLine("TotalDuration: {0}\n", e.TotalDuration);
            // Console.WriteLine("Percent Complete: {0}\n", e.ProcessedDuration.TotalMilliseconds / e.TotalDuration.TotalMilliseconds * 100.0);
        }

        private void ConversionCompleteEvent(object sender, ConversionCompleteEventArgs e)
        {
            // Console.Clear();
            // Console.WriteLine("\n------------\nConversion complete!\n------------");
            // Console.WriteLine("Bitrate: {0}", e.Bitrate);
            // Console.WriteLine("Fps: {0}", e.Fps);
            // Console.WriteLine("Frame: {0}", e.Frame);
            // Console.WriteLine("ProcessedDuration: {0}", e.ProcessedDuration);
            // Console.WriteLine("SizeKb: {0}", e.SizeKb);
            // Console.WriteLine("TotalDuration: {0}\n", e.TotalDuration);
        }
    }
}