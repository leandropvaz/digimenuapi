using DigiMenu.Domain.Models;
using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class comanda : BaseEntity
{
    public Guid id { get; set; }

    public Guid mesa_estabelecimento { get; set; }

    public string? anfitriao { get; set; }

    public Guid status { get; set; }

    public DateTime dataAbertura { get; set; }

    public DateTime? dataEncerramento { get; set; }

    public virtual ICollection<comanda_itens> comanda_itens { get; set; } = new List<comanda_itens>();

    public virtual mesa_estabelecimento mesa_estabelecimentoNavigation { get; set; } = null!;

    public virtual status statusNavigation { get; set; } = null!;
}
