using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class status
{
    public int id { get; set; }

    public string descricao { get; set; } = null!;

    public virtual ICollection<pedido_itens> pedido_itens { get; set; } = new List<pedido_itens>();

    public virtual ICollection<pedidos> pedidos { get; set; } = new List<pedidos>();
}
