namespace DigiMenu.Domain.Models
{
    public class ComandaModel
    {
        public Guid id { get; set; }

        public Guid mesa_estabelecimento { get; set; }

        public string? anfitriao { get; set; }

        public Guid status { get; set; }

        public DateTime dataAbertura { get; set; }

        public DateTime? dataEncerramento { get; set; }

        public virtual ICollection<Comanda_Itens_Model> comanda_itens { get; set; } = new List<Comanda_Itens_Model>();


    }
}
