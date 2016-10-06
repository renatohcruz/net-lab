﻿using System.Collections.Generic;

namespace Imposto.Core.Domain
{
    public class Pedido
    {
        public string EstadoDestino { get; set; }
        public string EstadoOrigem { get; set; }
        public string NomeCliente { get; set; }
        public List<PedidoItem> ItensDoPedido { get; set; }

        public Pedido()
        {
            ItensDoPedido = new List<PedidoItem>(); 
        }
    }
}
