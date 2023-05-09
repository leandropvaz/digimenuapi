using DigiMenu.Domain.Models;
using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class mesa_estabelecimento : BaseEntity
{
    public int id { get; set; }

    public int mesa { get; set; }

    public int estabelecimento { get; set; }

    public int status { get; set; }

    public bool ativo { get; set; }

    public virtual estabelecimento estabelecimentoNavigation { get; set; } = null!;

    public virtual mesa mesaNavigation { get; set; } = null!;

    public virtual status statusNavigation { get; set; } = null!;
}
