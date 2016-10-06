using System;
using System.Collections.Generic;
using Imposto.Core.Data.Contracts;
using Imposto.Core.Service;
using Imposto.Core.Data.Repository;
using System.Xml.Serialization;

namespace Imposto.Core.Domain
{
    [Serializable]
    public class NotaFiscal
    {
        public int Id { get; set; }
        public int NumeroNotaFiscal { get; set; }
        public int Serie { get; set; }
        public string NomeCliente { get; set; }
        public string EstadoDestino { get; set; }
        public string EstadoOrigem { get; set; }
        public List<NotaFiscalItem> ItensDaNotaFiscal { get; set; }
        [XmlIgnore]
        private INotaFiscalRepository NotaFiscalRepository { get; set; }
        [XmlIgnore]
        private Cfop Cfop { get; set; }
        [XmlIgnore]
        private DescontoServices DescontoServices { get; set; }

        public NotaFiscal()
        {
            Cfop = new Cfop();
            DescontoServices = new DescontoServices();
            ItensDaNotaFiscal = new List< NotaFiscalItem>();
            NotaFiscalRepository = Factory.Factory.CreateInstance<INotaFiscalRepository, NotaFiscalRepository>();
        }

        public NotaFiscal(INotaFiscalRepository notaFiscalRepository, DescontoServices descontoServices)
        {
            NotaFiscalRepository = notaFiscalRepository;
            DescontoServices = descontoServices;
            ItensDaNotaFiscal = new List<NotaFiscalItem>();
            Cfop = new Cfop();
        }

        public void EmitirNotaFiscal(Pedido pedido)
        {
            NumeroNotaFiscal = NotaFiscalRepository.PegarProximoNumeroNotaFiscal();
            Serie = new Random().Next(int.MaxValue);
            NomeCliente = pedido.NomeCliente;
            EstadoDestino = pedido.EstadoDestino;
            EstadoOrigem = pedido.EstadoOrigem;

            foreach (var itemPedido in pedido.ItensDoPedido)
            {
                var notaFiscalItem = new NotaFiscalItem
                {
                    Cfop = Cfop.ObterValor(EstadoOrigem, EstadoDestino),
                    NomeProduto = itemPedido.NomeProduto,
                    CodigoProduto = itemPedido.CodigoProduto
                };

                IcmsService.TipoIcms(this, notaFiscalItem);
                IcmsService.BaseIcms(itemPedido, notaFiscalItem);
                IcmsService.ValorIcms(notaFiscalItem);
                IcmsService.Brinde(itemPedido, notaFiscalItem);
                IpiService.CalculoIpi(itemPedido, notaFiscalItem);
                DescontoServices.Calcular(this, notaFiscalItem);

                ItensDaNotaFiscal.Add(notaFiscalItem);
            }            
        }
    }
}
