using DigiMenu.Domain.Models;
using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class produtos_estabelecimento : BaseEntity
{
    public Guid id { get; set; }

    public Guid produto { get; set; }

    public Guid estabelecimento { get; set; }

    public bool ativo { get; set; }

    public virtual ICollection<comanda_itens> comanda_itens { get; set; } = new List<comanda_itens>();

    public virtual estabelecimento estabelecimentoNavigation { get; set; } = null!;

    public virtual produtos produtoNavigation { get; set; } = null!;
}
