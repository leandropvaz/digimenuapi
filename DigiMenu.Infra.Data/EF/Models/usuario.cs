using DigiMenu.Domain.Models;
using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class usuario : BaseEntity
{
    public int id { get; set; }

    public string nome { get; set; } = null!;

    public string? telefone { get; set; }

    public string cpf { get; set; } = null!;

    public string email { get; set; } = null!;

    public DateTime dataCadastro { get; set; }

    public string? imagem { get; set; }

    public bool? ativo { get; set; }

    public string? senha { get; set; }
}
