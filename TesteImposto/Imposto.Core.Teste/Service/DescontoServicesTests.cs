using Imposto.Core.Domain;
using Imposto.Core.Service;
using Imposto.Core.Teste.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imposto.Core.Teste.Service
{
    [TestClass()]
    public class DescontoServicesTests
    {
        [TestMethod()]
        public void CalcularTest()
        {
            var ufService = new UfService("ES|MG|RJ|SP", "AC|AL|AM|AP|BA|CE|DF|ES|GO|MA|MG|MS|MT|PA|PB|PE|PI|PR|RJ|RN|RO|RR|RS|SC|SE|SP|TO");
            var descontoServices = new DescontoServices(ufService);
            var notaFiscal = new NotaFiscal(new NotaFiscalRepositoryMock(), descontoServices) { EstadoDestino = "sp" };
            var notaFiscalItem = new NotaFiscalItem { BaseIcms = 1000 };
           
            descontoServices.Calcular(notaFiscal, notaFiscalItem);

            Assert.AreEqual(notaFiscalItem.Desconto, 0.10);
            Assert.AreEqual(notaFiscalItem.BaseIcms, 1000 * (1 - notaFiscalItem.Desconto));
            
        }
    }
}