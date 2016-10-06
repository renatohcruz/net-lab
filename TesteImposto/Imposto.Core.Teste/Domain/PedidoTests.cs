using System.Collections.Generic;
using Imposto.Core.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imposto.Core.Teste.Domain
{
    [TestClass()]
    public class PedidoTests
    {
        [TestMethod()]
        public void PedidoTest()
        {
            var pedido = Factory.Factory.CreateInstance<Pedido, Pedido>();
            var list = new List<PedidoItem>(); 

            Assert.AreEqual(pedido.ItensDoPedido.GetType(), list.GetType());
        }
    }
}