﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.Models
{
    public class ProdutoModel
    {
        public int id { get; set; }

        public string nome { get; set; } = null!;

        public string? descricao { get; set; }

        public int estabelecimento { get; set; }

        public decimal preco { get; set; }

        public bool ativo { get; set; }

        public int Tipo { get; set; }

    }
}
