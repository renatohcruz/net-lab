using System;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Imposto.Core.Data.Contracts;

namespace Imposto.Core.Data.Repository
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private TesteEntities _testeEntities;

        public NotaFiscalRepository()
        {
            _testeEntities = new TesteEntities();
        }

        public int PegarProximoNumeroNotaFiscal()
        {
            var numeroNotaFiscal = _testeEntities.NotaFiscal.Max(x => x.NumeroNotaFiscal);
            return (int) (numeroNotaFiscal == null ? 1 : numeroNotaFiscal + 1);
        }

        public void SalvarXml(Domain.NotaFiscal notaFiscal)
        {
            var serializer = new XmlSerializer(notaFiscal.GetType());
            var arquivo = string.Format(ConfigurationManager.AppSettings["EnderecoXML"], Guid.NewGuid());

            using (var writer = new StreamWriter(arquivo))
            {
                serializer.Serialize(writer, notaFiscal);
            }
        }

        public void Salvar(Domain.NotaFiscal notaFiscal)
        {
            var pNotaFiscalIdParameter = new ObjectParameter("pId", 0);
            _testeEntities.Database.BeginTransaction();

            try
            {
                _testeEntities.P_NOTA_FISCAL(
                    pNotaFiscalIdParameter,
                    notaFiscal.NumeroNotaFiscal,
                    notaFiscal.Serie,
                    notaFiscal.NomeCliente,
                    notaFiscal.EstadoDestino,
                    notaFiscal.EstadoOrigem
                );

                foreach (var notaFiscalItem in notaFiscal.ItensDaNotaFiscal)
                {
                    _testeEntities.P_NOTA_FISCAL_ITEM(
                        0,
                        (int)pNotaFiscalIdParameter.Value,
                        notaFiscalItem.Cfop,
                        notaFiscalItem.TipoIcms,
                        (decimal)notaFiscalItem.BaseIcms,
                        (decimal)notaFiscalItem.AliquotaIcms,
                        (decimal)notaFiscalItem.ValorIcms,
                        (decimal)notaFiscalItem.BaseCalculoIpi,
                        (decimal)notaFiscalItem.AliquotaIpi,
                        (decimal)notaFiscalItem.ValorIpi,
                        (decimal)notaFiscalItem.Desconto,
                        notaFiscalItem.NomeProduto,
                        notaFiscalItem.CodigoProduto
                    );
                }
            }
            catch (Exception)
            {
                _testeEntities.Database.CurrentTransaction.Rollback();
                throw;
            }
            finally
            {
                _testeEntities.Database.CurrentTransaction.Commit();
            }
        }

        public void Dispose()
        {
            _testeEntities.Dispose();
            _testeEntities = null;
        }
        
    }
}
