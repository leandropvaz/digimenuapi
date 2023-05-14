using DigiMenu.Domain.Models;
using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class produtos : BaseEntity
{
    public int id { get; set; }

    public string descricao { get; set; } = null!;

    public int estabelecimento { get; set; }

    public decimal preco { get; set; }

    public bool ativo { get; set; }

    public int Tipo { get; set; }

    public virtual tipoProduto TipoNavigation { get; set; } = null!;

    public virtual estabelecimento estabelecimentoNavigation { get; set; } = null!;

    public virtual ICollection<pedido_itens> pedido_itens { get; set; } = new List<pedido_itens>();
}
