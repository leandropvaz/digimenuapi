using DigiMenu.Domain.Models;
using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class produtos : BaseEntity
{
    public int id { get; set; }

    public string descricao { get; set; } = null!;

    public decimal preco { get; set; }

    public bool ativo { get; set; }

    public int Tipo { get; set; }

    public virtual tipoProduto TipoNavigation { get; set; } = null!;

    public virtual ICollection<produtos_estabelecimento> produtos_estabelecimento { get; set; } = new List<produtos_estabelecimento>();
}
