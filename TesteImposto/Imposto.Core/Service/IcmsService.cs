using Imposto.Core.Domain;

namespace Imposto.Core.Service
{
    public static class IcmsService
    {
        public static void TipoIcms(NotaFiscal notaFiscal, NotaFiscalItem notaFiscalItem)
        {
            if (notaFiscal.EstadoDestino.ToLower() == notaFiscal.EstadoOrigem.ToLower())
            {
                notaFiscalItem.TipoIcms = "60";
                notaFiscalItem.AliquotaIcms = 0.18;
            }
            else
            {
                notaFiscalItem.TipoIcms = "10";
                notaFiscalItem.AliquotaIcms = 0.17;
            }
        }

        public static void BaseIcms(PedidoItem itemPedido, NotaFiscalItem notaFiscalItem)
        {
            if (notaFiscalItem.Cfop == "6.009")
            {
                notaFiscalItem.BaseIcms = itemPedido.ValorItemPedido * 0.90; //redução de base
            }
            else
            {
                notaFiscalItem.BaseIcms = itemPedido.ValorItemPedido;
            }
        }

        public static void Brinde(PedidoItem itemPedido, NotaFiscalItem notaFiscalItem)
        {
            if (!itemPedido.Brinde) return;
            notaFiscalItem.TipoIcms = "60";
            notaFiscalItem.AliquotaIcms = 0.18;
            notaFiscalItem.ValorIcms = notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms;
        }

        public static void ValorIcms(NotaFiscalItem notaFiscalItem)
        {
            notaFiscalItem.ValorIcms = notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms;
        }

        
    }
}
