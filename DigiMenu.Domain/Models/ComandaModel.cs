namespace DigiMenu.Domain.Models
{
    public class ComandaModel
    {
        public int id { get; set; }

        public int mesa { get; set; }

        public string? anfitriao { get; set; }

        public int status { get; set; }

        public DateTime dataAbertura { get; set; }

        public DateTime? dataEncerramento { get; set; }

        public virtual ICollection<Comanda_Credito_Model> comanda_credito { get; set; } = new List<Comanda_Credito_Model>();

        public virtual ICollection<PedidoModel> pedidos { get; set; } = new List<PedidoModel>();


    }
}
