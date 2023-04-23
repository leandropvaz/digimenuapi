using DigiMenu.Domain.Models;
using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class comanda_itens : BaseEntity
{
    public Guid id { get; set; }

    public Guid comanda { get; set; }

    public Guid produto { get; set; }

    public virtual comanda comandaNavigation { get; set; } = null!;

    public virtual ICollection<pedidos_itens> pedidos_itens { get; set; } = new List<pedidos_itens>();

    public virtual produtos_estabelecimento produtoNavigation { get; set; } = null!;
}
