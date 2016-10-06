using Imposto.Core.Domain;
using Imposto.Core.Service;
using Imposto.Core.Teste.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imposto.Core.Teste.Domain
{
    [TestClass()]
    public class NotaFiscalTests
    {
        [TestMethod()]
        public void EmitirNotaFiscalTest()
        {
            //criando pedido
            var pedido = Factory.Factory.CreateInstance<Pedido, Pedido>();
            pedido.EstadoDestino = "MG";
            pedido.EstadoOrigem = "SP";
            pedido.NomeCliente = "Renato";

            //criando itens do pedido
            var pedidoItem = new PedidoItem();
            pedidoItem.CodigoProduto = "1";
            pedidoItem.Brinde = true;
            pedidoItem.NomeProduto = "nome do produto";
            pedidoItem.ValorItemPedido = 10;

            //adicionando os itens do pedido
            pedido.ItensDoPedido.Add(pedidoItem);

            //criando nota fical
            var mock = new NotaFiscalRepositoryMock();
            var ufService = new UfService("ES|MG|RJ|SP", "AC|AL|AM|AP|BA|CE|DF|ES|GO|MA|MG|MS|MT|PA|PB|PE|PI|PR|RJ|RN|RO|RR|RS|SC|SE|SP|TO");
            var descontoServices = new DescontoServices(ufService);
            var nota = new NotaFiscal(mock, descontoServices);

            nota.EmitirNotaFiscal(pedido);

            Assert.AreEqual(nota.EstadoDestino, pedido.EstadoDestino);
        }
    }
}