using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WpfApp1
{
    public class FileListBuilder
    {
        private readonly string _sourceDirectory;
        private List<string> _fileNames;
        private readonly Resolution _resolution;
        private const string SourceDirectoryName = "Source";

        public FileListBuilder(string sourceDirectory, Resolution resolution)
        {
            _sourceDirectory = sourceDirectory;
            _resolution = resolution;
        }

        public List<string> BuildListOfFiles()
        {
            _fileNames = new List<string>();
            
            var directories = Directory.GetDirectories(_sourceDirectory);

            var sourceDirectory = directories.SingleOrDefault(e => e.Contains(SourceDirectoryName));

            if (sourceDirectory != null)
            {
                var sourceDirectories = Directory.GetDirectories(sourceDirectory);

                foreach (var directory in sourceDirectories)
                {
                    var newDirectory = directory.Replace(SourceDirectoryName, _resolution.ToString());

                    Directory.CreateDirectory(newDirectory);
                    
                    var files = Directory.GetFiles(directory);
                    _fileNames.AddRange(files);
                }
            }

            _fileNames = _fileNames.Where(e => e.ToLower().EndsWith("mp4")).ToList();

            var resultingList = new List<string>();
            
            foreach (var fileName in _fileNames)
            {
                var destinationFileName = fileName.Replace(SourceDirectoryName, _resolution.ToString());
                
                if (!File.Exists(destinationFileName))
                {
                    resultingList.Add(fileName);
                }
            }
            
            
            return resultingList;
        }
    }
}