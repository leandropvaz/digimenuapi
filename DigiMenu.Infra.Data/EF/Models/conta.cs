﻿using DigiMenu.Domain.Models;
using System;
using System.Collections.Generic;

namespace DigiMenu.Infra.Data.EF.Models;

public partial class conta : BaseEntity
{
    public Guid id { get; set; }

    public Guid comanda { get; set; }

    public decimal valor { get; set; }

    public DateTime dataFechamento { get; set; }
}
