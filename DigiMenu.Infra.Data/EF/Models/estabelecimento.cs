using DigiMenu.Domain.Models;
using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class estabelecimento : BaseEntity
{
    public int id { get; set; }

    public string nome { get; set; } = null!;

    public string endereco { get; set; } = null!;

    public string cidade { get; set; } = null!;

    public string estado { get; set; } = null!;

    public string telefone { get; set; } = null!;

    public string email { get; set; } = null!;

    public virtual ICollection<mesa> mesa { get; set; } = new List<mesa>();

    public virtual ICollection<produtos> produtos { get; set; } = new List<produtos>();
}
