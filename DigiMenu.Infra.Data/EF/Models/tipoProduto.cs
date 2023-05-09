using DigiMenu.Domain.Models;
using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class tipoProduto : BaseEntity
{
    public int id { get; set; }

    public string descricao { get; set; } = null!;

    public virtual ICollection<produtos> produtos { get; set; } = new List<produtos>();
}
