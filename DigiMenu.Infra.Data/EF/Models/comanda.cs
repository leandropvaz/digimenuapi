using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class comanda
{
    public int id { get; set; }

    public int mesa { get; set; }

    public string? anfitriao { get; set; }

    public int status { get; set; }

    public DateTime dataAbertura { get; set; }

    public DateTime? dataEncerramento { get; set; }

    public virtual ICollection<comanda_credito> comanda_credito { get; set; } = new List<comanda_credito>();

    public virtual mesa mesaNavigation { get; set; } = null!;

    public virtual ICollection<pedidos> pedidos { get; set; } = new List<pedidos>();
}
