using Imposto.Core.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imposto.Core.Teste.Domain
{
    [TestClass()]
    public class CfopTeste
    {
        [TestMethod()]
        public void ObterValorTest()
        {
            var cfop = new Cfop();
            Assert.AreEqual(cfop.ObterValor("SP", "RJ"), "6.000");
            Assert.AreEqual(cfop.ObterValor("SP", "PE"), "6.001");
            Assert.AreEqual(cfop.ObterValor("SP", "MG"), "6.002");
            Assert.AreEqual(cfop.ObterValor("SP", "PB"), "6.003");
            Assert.AreEqual(cfop.ObterValor("SP", "PR"), "6.004");
            Assert.AreEqual(cfop.ObterValor("SP", "PI"), "6.005");
            Assert.AreEqual(cfop.ObterValor("SP", "RO"), "6.006");
            Assert.AreEqual(cfop.ObterValor("SP", "SE"), "6.007");
            Assert.AreEqual(cfop.ObterValor("SP", "TO"), "6.008");
            Assert.AreEqual(cfop.ObterValor("SP", "SP"), "6.009");
            Assert.AreEqual(cfop.ObterValor("SP", "PA"), "6.010");

            Assert.AreEqual(cfop.ObterValor("MG", "RJ"), "6.000");
            Assert.AreEqual(cfop.ObterValor("MG", "PE"), "6.001");
            Assert.AreEqual(cfop.ObterValor("MG", "MG"), "6.002");
            Assert.AreEqual(cfop.ObterValor("MG", "PB"), "6.003");
            Assert.AreEqual(cfop.ObterValor("MG", "PR"), "6.004");
            Assert.AreEqual(cfop.ObterValor("MG", "PI"), "6.005");
            Assert.AreEqual(cfop.ObterValor("MG", "RO"), "6.006");
            Assert.AreEqual(cfop.ObterValor("MG", "SE"), "6.007");
            Assert.AreEqual(cfop.ObterValor("MG", "TO"), "6.008");
            Assert.AreEqual(cfop.ObterValor("MG", "SP"), "6.009");
            Assert.AreEqual(cfop.ObterValor("MG", "PA"), "6.010");


            Assert.AreEqual(cfop.ObterValor("sp", "rj"), "6.000");
            Assert.AreEqual(cfop.ObterValor("sp", "RJ"), "6.000");
            Assert.AreEqual(cfop.ObterValor("SP", "rj"), "6.000");
            Assert.AreEqual(cfop.ObterValor("Sp", "Rj"), "6.000");
            Assert.AreEqual(cfop.ObterValor("sP", "rJ"), "6.000");

            Assert.AreEqual(cfop.ObterValor("xx", "xx"), "");
            Assert.AreEqual(cfop.ObterValor("", ""), "");
        }
    }
}


