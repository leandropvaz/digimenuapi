using DigiMenu.Domain.Models;
using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class pedido_itens : BaseEntity
{
    public int id { get; set; }

    public int pedido { get; set; }

    public int produto { get; set; }

    public int quantidade { get; set; }

    public int status { get; set; }

    public virtual pedidos pedidoNavigation { get; set; } = null!;

    public virtual produtos produtoNavigation { get; set; } = null!;

    public virtual status statusNavigation { get; set; } = null!;
}
