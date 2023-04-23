using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class status
{
    public Guid id { get; set; }

    public string descricao { get; set; } = null!;

    public virtual ICollection<comanda> comanda { get; set; } = new List<comanda>();

    public virtual ICollection<mesa_estabelecimento> mesa_estabelecimento { get; set; } = new List<mesa_estabelecimento>();
}
