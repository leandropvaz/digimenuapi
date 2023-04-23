using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class pedido_itens
{
    public Guid id { get; set; }

    public Guid pedido { get; set; }

    public Guid comanda_itens { get; set; }

    public virtual comanda_itens comanda_itensNavigation { get; set; } = null!;
}
