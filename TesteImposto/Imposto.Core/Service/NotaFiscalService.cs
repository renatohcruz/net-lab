using Imposto.Core.Data.Contracts;
using Imposto.Core.Data.Repository;
using Imposto.Core.Domain;

namespace Imposto.Core.Service
{
    public class NotaFiscalService
    {
        private readonly NotaFiscal _notaFiscal;
        private readonly INotaFiscalRepository _notaFiscalRepository;

        public NotaFiscalService()
        {
            _notaFiscal = new NotaFiscal();
            _notaFiscalRepository = Factory.Factory.CreateInstance<INotaFiscalRepository, NotaFiscalRepository>();
        }

        public void GerarNotaFiscal(Pedido pedido)
        {
            _notaFiscal.EmitirNotaFiscal(pedido);

            using (_notaFiscalRepository)
            {
                _notaFiscalRepository.SalvarXml(_notaFiscal);
                _notaFiscalRepository.Salvar(_notaFiscal);
            }
        }
    }
}
