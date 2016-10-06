using Imposto.Core.Domain;
using Imposto.Core.Service;
using Imposto.Core.Teste.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imposto.Core.Teste.Service
{
    [TestClass()]
    public class IcmsServiceTests
    {
        [TestMethod()]
        public void TipoIcmsTest()
        {
            var ufService = new UfService("ES|MG|RJ|SP", "AC|AL|AM|AP|BA|CE|DF|ES|GO|MA|MG|MS|MT|PA|PB|PE|PI|PR|RJ|RN|RO|RR|RS|SC|SE|SP|TO");
            var descontoServices = new DescontoServices(ufService);
            var notaFiscal = new NotaFiscal(new NotaFiscalRepositoryMock(), descontoServices);
            var notaFiscalItem = new NotaFiscalItem();

            notaFiscal.EstadoDestino = "SP";
            notaFiscal.EstadoOrigem = "SP";
            IcmsService.TipoIcms(notaFiscal, notaFiscalItem);

            Assert.AreEqual(notaFiscalItem.TipoIcms, "60");
            Assert.AreEqual(notaFiscalItem.AliquotaIcms, 0.18);


            notaFiscal.EstadoDestino = "SP";
            notaFiscal.EstadoOrigem = "";
            IcmsService.TipoIcms(notaFiscal, notaFiscalItem);

            Assert.AreEqual(notaFiscalItem.TipoIcms, "10");
            Assert.AreEqual(notaFiscalItem.AliquotaIcms, 0.17);

        }

        [TestMethod()]
        public void BaseIcmsTest()
        {
            var itemPedido = new PedidoItem(); 
            var notaFiscalItem = new NotaFiscalItem();

            itemPedido.ValorItemPedido = 1000;
            notaFiscalItem.Cfop = "6.009";

            IcmsService.BaseIcms(itemPedido, notaFiscalItem);
            Assert.AreEqual(notaFiscalItem.BaseIcms, itemPedido.ValorItemPedido * 0.90);

            
            notaFiscalItem.Cfop = "6.079";

            IcmsService.BaseIcms(itemPedido, notaFiscalItem);
            Assert.AreEqual(notaFiscalItem.BaseIcms, itemPedido.ValorItemPedido);
        }

        [TestMethod()]
        public void BrindeTest()
        {
            var itemPedido = new PedidoItem() { Brinde = true };
            var notaFiscalItem = new NotaFiscalItem {BaseIcms = 1000};

            IcmsService.Brinde(itemPedido, notaFiscalItem);

            Assert.AreEqual(notaFiscalItem.TipoIcms, "60");
            Assert.AreEqual(notaFiscalItem.AliquotaIcms, 0.18);
            Assert.AreEqual(notaFiscalItem.ValorIcms, notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms);
        }

        [TestMethod()]
        public void ValorIcmsTest()
        {
            var notaFiscalItem = new NotaFiscalItem { BaseIcms = 1000, AliquotaIcms = 0.18 };
            IcmsService.ValorIcms(notaFiscalItem);

            Assert.AreEqual(notaFiscalItem.ValorIcms, notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms);
        }
    }
}