using DigiMenu.Domain.Models;
using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class comanda : BaseEntity
{
    public int id { get; set; }

    public int mesa_estabelecimento { get; set; }

    public string? anfitriao { get; set; }

    public int status { get; set; }

    public DateTime dataAbertura { get; set; }

    public DateTime? dataEncerramento { get; set; }

    public virtual ICollection<comanda_itens> comanda_itens { get; set; } = new List<comanda_itens>();
}
