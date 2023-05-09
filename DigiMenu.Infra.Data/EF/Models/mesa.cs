using DigiMenu.Domain.Models;
using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class mesa : BaseEntity
{
    public int id { get; set; }

    public string numero { get; set; } = null!;

    public bool ativo { get; set; }

    public virtual ICollection<mesa_estabelecimento> mesa_estabelecimento { get; set; } = new List<mesa_estabelecimento>();
}
