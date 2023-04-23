using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class pedidos_itens
{
    public Guid id { get; set; }

    public Guid pedido { get; set; }

    public Guid comanda_itens { get; set; }

    public virtual comanda_itens comanda_itensNavigation { get; set; } = null!;

    public virtual pedidos pedidoNavigation { get; set; } = null!;
}
