using Imposto.Core.Service;
using System;
using System.Data;
using System.Windows.Forms;
using Imposto.Core.Domain;

namespace TesteImposto
{
    public partial class FormImposto : Form
    {
        private readonly Pedido _pedido = new Pedido();

        public FormImposto()
        {
            InitializeComponent();
            dataGridViewPedidos.AutoGenerateColumns = true;                       
            dataGridViewPedidos.DataSource = GetTablePedidos();
            ResizeColumns();
        }

        private void ResizeColumns()
        {
            double mediaWidth = dataGridViewPedidos.Width / dataGridViewPedidos.Columns.GetColumnCount(DataGridViewElementStates.Visible);

            for (int i = dataGridViewPedidos.Columns.Count - 1; i >= 0; i--)
            {
                var coluna = dataGridViewPedidos.Columns[i];
                coluna.Width = Convert.ToInt32(mediaWidth);
            }   
        }

        private object GetTablePedidos()
        {
            DataTable table = new DataTable("pedidos");
            table.Columns.Add(new DataColumn("Nome do produto", typeof(string)));
            table.Columns.Add(new DataColumn("Codigo do produto", typeof(string)));
            table.Columns.Add(new DataColumn("Valor", typeof(decimal)));
            table.Columns.Add(new DataColumn("Brinde", typeof(bool)));
                     
            return table;
        }

        private void buttonGerarNotaFiscal_Click(object sender, EventArgs e)
        {
            try
            {
                var service = new NotaFiscalService();
                DataTable table = (DataTable)dataGridViewPedidos.DataSource;

                ValidacaoUf(txtEstadoOrigem.Text, "Atenção! Por favor, informe um estado de origem válido.");
                ValidacaoUf(txtEstadoDestino.Text, "Atenção! Por favor, informe um estado de destino válido.");
                ValidacaoQuantidadeItensPedido(table, "Atenção! Por favor, informe 1 item de pedido.");

                _pedido.EstadoOrigem = txtEstadoOrigem.Text;
                _pedido.EstadoDestino = txtEstadoDestino.Text;
                _pedido.NomeCliente = textBoxNomeCliente.Text;

                foreach (DataRow row in table.Rows)
                {
                    _pedido.ItensDoPedido.Add(
                        new PedidoItem()
                        {
                            Brinde = !Convert.IsDBNull(row["Brinde"]) && Convert.ToBoolean(row["Brinde"]),
                            CodigoProduto = ValidacaoNuloouVazio(row["Codigo do produto"].ToString(), "Atenção! Por favor, informe o codigo do produto."),
                            NomeProduto = ValidacaoNuloouVazio(row["Nome do produto"].ToString(), "Atenção! Por favor, informe o nome do produto."),
                            ValorItemPedido = ValidacaoValor(row["Valor"].ToString(), "Atenção! Por favor, informe um valor de produto válido.")
                        });
                }

                service.GerarNotaFiscal(_pedido);
                MessageBox.Show("Operação efetuada com sucesso");
                InicializarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
           
        }

        private void InicializarFormulario()
        {
            textBoxNomeCliente.Text = "";
            txtEstadoOrigem.Text = "";
            txtEstadoDestino.Text = "";

            dataGridViewPedidos.DataSource = GetTablePedidos();
        }

        #region Validações
        private void ValidacaoUf(string estado, string mensagem)
        {
            if (!new UfService().EhUnidadeFederacao(estado))
            {
                throw new InvalidOperationException(mensagem);
            }
        }

        private double ValidacaoValor(string valor, string mensagem)
        {
            try
            {
                return Convert.ToDouble(valor);
            }
            catch (Exception)
            {
                throw new InvalidOperationException(mensagem);
            }

        }

        private string ValidacaoNuloouVazio(string valor, string mensagem)
        {
            if(string.IsNullOrEmpty(valor))
                throw new InvalidOperationException(mensagem);

            return valor;
        }

        private void ValidacaoQuantidadeItensPedido(DataTable table, string mensagem)
        {
            if (table == null) throw new InvalidOperationException(mensagem);
            if (table.Rows.Count == 0)
                throw new InvalidOperationException(mensagem);
        }

        #endregion
    }
}
