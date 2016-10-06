using Imposto.Core.Domain;

namespace Imposto.Core.Service
{
    public static class IpiService
    {
        public static void CalculoIpi(PedidoItem itemPedido, NotaFiscalItem notaFiscalItem)
        {
            notaFiscalItem.BaseCalculoIpi = itemPedido.ValorItemPedido;
            notaFiscalItem.AliquotaIpi = 0;

            if (!itemPedido.Brinde)
                notaFiscalItem.AliquotaIpi = 10;

            notaFiscalItem.ValorIpi = notaFiscalItem.BaseCalculoIpi * notaFiscalItem.AliquotaIpi;
        }
    }
}
