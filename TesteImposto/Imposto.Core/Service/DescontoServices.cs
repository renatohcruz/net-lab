using Imposto.Core.Domain;

namespace Imposto.Core.Service
{
    public class DescontoServices
    {
        private readonly UfService _uf;

        public DescontoServices()
        {
            _uf = new UfService();
        }

        public DescontoServices(UfService uf)
        {
            _uf = uf;
        }

        public  void Calcular(NotaFiscal notaFiscal, NotaFiscalItem notaFiscalItem)
        {
            if (!_uf.EhUnidadeFederacaoSudeste(notaFiscal.EstadoDestino)) return;
            notaFiscalItem.Desconto = 0.10;
            notaFiscalItem.BaseIcms *= (1 - notaFiscalItem.Desconto);
        } 
    }
}
