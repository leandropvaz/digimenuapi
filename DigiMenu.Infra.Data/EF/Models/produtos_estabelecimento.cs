using DigiMenu.Domain.Models;
using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class produtos_estabelecimento : BaseEntity
{
    public int id { get; set; }

    public int produto { get; set; }

    public int estabelecimento { get; set; }

    public bool ativo { get; set; }

    public virtual estabelecimento estabelecimentoNavigation { get; set; } = null!;

    public virtual produtos produtoNavigation { get; set; } = null!;
}
