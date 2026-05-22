using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FarmaciaDevOps.Tests
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void TestSuma()
        {
            int a = 2;
            int b = 3;

            int resultado = a + b;

            Assert.AreEqual(5, resultado);
        }
    }
}