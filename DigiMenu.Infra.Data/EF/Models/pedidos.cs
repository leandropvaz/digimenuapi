using DigiMenu.Domain.Models;
using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class pedidos : BaseEntity
{
    public int id { get; set; }

    public int comanda { get; set; }

    public int status { get; set; }

    public DateTime dataPedidoFeito { get; set; }

    public string? responsavel { get; set; }

    public string? observacao { get; set; }

    public DateTime? dataPedidoEntregue { get; set; }

    public virtual comanda comandaNavigation { get; set; } = null!;

    public virtual ICollection<pedido_itens> pedido_itens { get; set; } = new List<pedido_itens>();

    public virtual status statusNavigation { get; set; } = null!;
}
