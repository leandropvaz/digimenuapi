using DigiMenu.Domain.Models;
using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class mesa_estabelecimento : BaseEntity
{
    public Guid id { get; set; }

    public Guid mesa { get; set; }

    public Guid estabelecimento { get; set; }

    public Guid status { get; set; }

    public bool ativo { get; set; }

    public virtual ICollection<comanda> comanda { get; set; } = new List<comanda>();

    public virtual estabelecimento estabelecimentoNavigation { get; set; } = null!;

    public virtual mesa mesaNavigation { get; set; } = null!;

    public virtual status statusNavigation { get; set; } = null!;
}
