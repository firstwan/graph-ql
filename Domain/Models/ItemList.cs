using System.Collections.Generic;

namespace GraphQL_example.Domain.Models
{
    public class ItemList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        

        // Relations
        public virtual ICollection<ItemData> ItemDatas { get; set; }


        public ItemList()
        {
            ItemDatas = new HashSet<ItemData>();
        }
    }
}