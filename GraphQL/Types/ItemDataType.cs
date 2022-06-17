using HotChocolate.Types;
using GraphQL_example.Domain.Models;
using GraphQL_example.Domain.Contexts;
using HotChocolate;
using System.Linq;

namespace GraphQL_example.GraphQL.Types
{
    public class ItemDataType : ObjectType<ItemData>
    {
        protected override void Configure(IObjectTypeDescriptor<ItemData> descriptor)
        {
            descriptor.Description("Used to define todo item for a specific list");

            descriptor.Field(x => x.ItemList).Ignore();
        }
    }
}
