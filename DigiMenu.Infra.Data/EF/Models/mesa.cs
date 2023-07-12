using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class mesa
{
    public int id { get; set; }

    public string numero { get; set; } = null!;

    public bool ativo { get; set; }

    public int estabelecimento { get; set; }

    public virtual ICollection<comanda> comanda { get; set; } = new List<comanda>();

    public virtual estabelecimento estabelecimentoNavigation { get; set; } = null!;
}
