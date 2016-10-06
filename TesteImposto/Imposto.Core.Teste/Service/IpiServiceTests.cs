using Imposto.Core.Domain;
using Imposto.Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imposto.Core.Teste.Service
{
    [TestClass()]
    public class IpiServiceTests
    {
        [TestMethod()]
        public void CalculoIpiTest()
        {
            var itemPedido = new PedidoItem() { ValorItemPedido = 1000, Brinde = true };
            var notaFiscalItem = new NotaFiscalItem();

            IpiService.CalculoIpi(itemPedido, notaFiscalItem);

            Assert.AreEqual(notaFiscalItem.BaseCalculoIpi, itemPedido.ValorItemPedido);
            Assert.AreEqual(notaFiscalItem.AliquotaIpi, 0);
            Assert.AreEqual(notaFiscalItem.ValorIpi, notaFiscalItem.BaseCalculoIpi * notaFiscalItem.AliquotaIpi);


            itemPedido.Brinde = false;
            IpiService.CalculoIpi(itemPedido, notaFiscalItem);

            Assert.AreEqual(notaFiscalItem.BaseCalculoIpi, itemPedido.ValorItemPedido);
            Assert.AreEqual(notaFiscalItem.AliquotaIpi, 10);
            Assert.AreEqual(notaFiscalItem.ValorIpi, notaFiscalItem.BaseCalculoIpi * notaFiscalItem.AliquotaIpi);

        }
    }
}