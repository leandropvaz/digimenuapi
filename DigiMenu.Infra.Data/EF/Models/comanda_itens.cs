using DigiMenu.Domain.Models;
using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class comanda_itens : BaseEntity
{
    public int id { get; set; }

    public int comanda { get; set; }

    public int produto { get; set; }

    public virtual comanda comandaNavigation { get; set; } = null!;
}
