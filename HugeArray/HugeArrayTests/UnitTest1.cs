using Microsoft.VisualStudio.TestTools.UnitTesting;
using HugeArray;
using System.Threading;

namespace HugeArrayTests
{
    [TestClass]
    public class UnitTest1
    {
        HugeArray<long> hg;

        [TestInitialize]
        public void Init()
        {
            hg = new HugeArray<long>(40);
        }


        [TestMethod]
        public void TestMethod1()
        {
            Thread t1 = new Thread(() => hg[25] = 25);
            t1.Start();
            t1.Join();
            if (hg[25] == 25)
            hg[25] = 36;

        }
    }
}
