using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProxyEditAssistant.Common;

namespace ProxyEditAssistant.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sourceDirectory = "test";
            
            var fileListBuilder = new FileListBuilder(sourceDirectory, new Resolution() { Height = 360, Width = 240});
            
        }
    }
}