namespace DigiMenu.Domain.Models
{
    public class ComandaModel
    {
        public int id { get; set; }

        public int mesa_estabelecimento { get; set; }

        public string? anfitriao { get; set; }

        public int status { get; set; }

        public DateTime dataAbertura { get; set; }

        public DateTime? dataEncerramento { get; set; }

        public virtual ICollection<PedidoModel> pedidos { get; set; } = new List<PedidoModel>();


    }
}
