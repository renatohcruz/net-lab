using Imposto.Core.Data.Contracts;
using System;
using Imposto.Core.Domain;

namespace Imposto.Core.Teste.Mock
{
    class NotaFiscalRepositoryMock : INotaFiscalRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int PegarProximoNumeroNotaFiscal()
        {
            return 10;
        }

        public void Salvar(NotaFiscal notaFiscal)
        {
            throw new NotImplementedException();
        }

        public void SalvarXml(NotaFiscal notaFiscal)
        {
            throw new NotImplementedException();
        }
    }
}
