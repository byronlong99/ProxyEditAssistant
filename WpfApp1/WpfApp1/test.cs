using System;
using System.Collections.Generic;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using WpfApp1;

public class Program
{
    private const string SourceDirectory = @"C:\Users\Byron\Desktop\Guatape\Videos";

    // private const int Height = 360;
    // private const int Width = 640;
    private const int Height = 240;
    private const int Width = 426;
    private static Resolution _videoResolution;
    private const string SourceDirectoryName = "Source";
    private static int _totalFiles;
    private static int _currentFile;

    public void BuildProxies()
    {
        _videoResolution = new Resolution {Height = Height, Width = Width};

        var fileListBuilder = new FileListBuilder(SourceDirectory, _videoResolution);

        var fileNames = fileListBuilder.BuildListOfFiles();

        ProcessFiles(fileNames);
    }

    private static void ProcessFiles(List<string> fileNames)
    {
        _currentFile = 1;
        _totalFiles = fileNames.Count;

        using (var engine = new Engine())
        {
            engine.ConvertProgressEvent += ConvertProgressEvent;
            engine.ConversionCompleteEvent += engine_ConversionCompleteEvent;

            foreach (var fileName in fileNames)
            {
                Process(fileName, engine);
                _currentFile++;
            }
        }
    }

    private static void Process(string fileName, Engine engine)
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
            VideoBitRate = 15000,
            //MaxVideoDuration = TimeSpan.FromSeconds(10)
        };

        engine.Convert(inputFile, outputFile, conversionOptions);
    }

    private static void ConvertProgressEvent(object sender, ConvertProgressEventArgs e)
    {
        Console.Clear();
        Console.WriteLine("\n------------\nConverting...\n------------");
        Console.WriteLine("File Number: {0}", _currentFile);
        Console.WriteLine("Total Files: {0}", _totalFiles);
        Console.WriteLine("Bitrate: {0}", e.Bitrate);
        Console.WriteLine("Fps: {0}", e.Fps);
        Console.WriteLine("Frame: {0}", e.Frame);
        Console.WriteLine("ProcessedDuration: {0}", e.ProcessedDuration);
        Console.WriteLine("SizeKb: {0}", e.SizeKb);
        Console.WriteLine("TotalDuration: {0}\n", e.TotalDuration);
        Console.WriteLine("Percent Complete: {0}\n", e.ProcessedDuration.TotalMilliseconds / e.TotalDuration.TotalMilliseconds * 100.0);
    }

    private static void engine_ConversionCompleteEvent(object sender, ConversionCompleteEventArgs e)
    {
        Console.Clear();
        Console.WriteLine("\n------------\nConversion complete!\n------------");
        Console.WriteLine("Bitrate: {0}", e.Bitrate);
        Console.WriteLine("Fps: {0}", e.Fps);
        Console.WriteLine("Frame: {0}", e.Frame);
        Console.WriteLine("ProcessedDuration: {0}", e.ProcessedDuration);
        Console.WriteLine("SizeKb: {0}", e.SizeKb);
        Console.WriteLine("TotalDuration: {0}\n", e.TotalDuration);
    }
}