using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProxyEditAssistant.Common;
using ProxyEditAssistant.Logic;

namespace ProxyEditAssistant.Tests.Logic
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sourceDirectory = @"\\TestVideos";

            var resolution = new Resolution {Height = 360, Width = 240};
            
            var fileListBuilder = new FileListBuilder(sourceDirectory, resolution);

            var files = fileListBuilder.BuildListOfFiles();
        }
    }
}