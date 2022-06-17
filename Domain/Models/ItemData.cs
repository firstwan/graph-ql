
namespace GraphQL_example.Domain.Models
{
    public class ItemData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public int ListId { get; set; }


        // Relations
        public virtual ItemList ItemList { get; set; }
    }
}