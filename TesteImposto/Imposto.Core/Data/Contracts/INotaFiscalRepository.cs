using System;

namespace Imposto.Core.Data.Contracts
{
    public interface INotaFiscalRepository : IDisposable
    {
        void SalvarXml(Domain.NotaFiscal notaFiscal);
        void Salvar(Domain.NotaFiscal notaFiscal);
        int PegarProximoNumeroNotaFiscal();
    }
}
