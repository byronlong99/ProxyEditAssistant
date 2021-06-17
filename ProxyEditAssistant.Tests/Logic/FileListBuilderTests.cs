using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProxyEditAssistant.Common;
using ProxyEditAssistant.Logic;

namespace ProxyEditAssistant.Tests.Logic
{
    [TestClass]
    public class FileListBuilderTests
    {
        [TestMethod]
        public void BuildListOfFiles_NoFilesExist_AllFilesAreReturned()
        {
            var resolution = new Resolution {Height = 360, Width = 240};

            var fileListBuilder = new FileListBuilder();

            var files = fileListBuilder.BuildListOfFiles(resolution, "TestVideos");

            Assert.AreEqual(4, files.Count);

            Assert.AreEqual(@"TestVideos\Source\Folder 1\DJI_0215.MP4", files[0]);
            Assert.AreEqual(@"TestVideos\Source\Folder 1\DJI_0216.MP4", files[1]);
            Assert.AreEqual(@"TestVideos\Source\Folder 2\DJI_0218.MP4", files[2]);
            Assert.AreEqual(@"TestVideos\Source\Folder 2\DJI_0225.MP4", files[3]);
        }
    }
}