using Imposto.Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imposto.Core.Teste.Service
{
    [TestClass()]
    public class UfServiceTests
    {
        [TestMethod()]
        public void EhUnidadeFederacaoSudesteTest()
        {
            var ufService = new UfService("ES|MG|RJ|SP","AC|AL|AM|AP|BA|CE|DF|ES|GO|MA|MG|MS|MT|PA|PB|PE|PI|PR|RJ|RN|RO|RR|RS|SC|SE|SP|TO");

            Assert.AreEqual(ufService.EhUnidadeFederacao("AC"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("AL"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("AM"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("AP"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("BA"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("CE"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("DF"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("ES"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("GO"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("MA"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("MG"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("MS"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("MT"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("PA"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("PB"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("PE"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("PI"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("PR"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("RJ"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("RN"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("RO"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("RR"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("RS"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("SC"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("SP"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("TO"), true);

            Assert.AreEqual(ufService.EhUnidadeFederacao("sp"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("Sp"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacao("sP"), true);

            Assert.AreEqual(ufService.EhUnidadeFederacao("xx"), false);

            Assert.AreEqual(ufService.EhUnidadeFederacaoSudeste("ES"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacaoSudeste("MG"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacaoSudeste("RJ"), true);
            Assert.AreEqual(ufService.EhUnidadeFederacaoSudeste("SP"), true);

            Assert.AreEqual(ufService.EhUnidadeFederacaoSudeste("RO"), false);
        }
    }
}