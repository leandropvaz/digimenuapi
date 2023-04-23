using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class pedidos
{
    public Guid id { get; set; }

    public string responsavel { get; set; } = null!;

    public Guid status { get; set; }

    public DateTime dataPedido { get; set; }

    public virtual ICollection<pedidos_itens> pedidos_itens { get; set; } = new List<pedidos_itens>();
}
