using DigiMenu.Domain.Models;
using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class comanda_credito : BaseEntity
{
    public int id { get; set; }

    public int comanda { get; set; }

    public decimal valor { get; set; }

    public string? responsavel { get; set; }

    public virtual comanda comandaNavigation { get; set; } = null!;
}
