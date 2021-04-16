using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProxyEditAssistant.Common;

namespace ProxyEditAssistant.Logic
{
    public interface IFileListBuilder
    {
        List<string> BuildListOfFiles(Resolution resolution, string topLevelDirectoryName);
    }

    public class FileListBuilder : IFileListBuilder
    {
        private List<string> _fileNames;
        private const string SourceDirectoryName = "Source";

        public List<string> BuildListOfFiles(Resolution resolution, string topLevelDirectoryName)
        {
            _fileNames = new List<string>();

            var directories = Directory.GetDirectories(topLevelDirectoryName);

            var sourceDirectory = directories.SingleOrDefault(e => e.Contains(SourceDirectoryName));

            if (sourceDirectory != null)
            {
                var sourceDirectories = Directory.GetDirectories(sourceDirectory);

                foreach (var directory in sourceDirectories)
                {
                    var newDirectory = directory.Replace(SourceDirectoryName, resolution.ToString());

                    Directory.CreateDirectory(newDirectory);

                    var files = Directory.GetFiles(directory);
                    _fileNames.AddRange(files);
                }
            }

            _fileNames = _fileNames.Where(e => e.ToLower().EndsWith("mp4")).ToList();

            var resultingList = new List<string>();

            foreach (var fileName in _fileNames)
            {
                var destinationFileName = fileName.Replace(SourceDirectoryName, resolution.ToString());

                if (!File.Exists(destinationFileName))
                    resultingList.Add(fileName);
            }

            return resultingList;
        }
    }
}