using HotChocolate;
using HotChocolate.Types;
using GraphQL_example.Domain.Models;
using GraphQL_example.Domain.Contexts;
using System.Linq;

namespace GraphQL_example.GraphQL.Types
{
    public class ItemListType : ObjectType<ItemList>
    {
        protected override void Configure(IObjectTypeDescriptor<ItemList> descriptor)
        {
            descriptor.Description("Used to group the do list item into groups");

            descriptor.Field(x => x.ItemDatas)
                        .ResolveWith<Resolvers>(x => x.GetItems(default!, default!))
                        .UseDbContext<AppDbContext>()
                        .Description("This is the list of to do item available for this list");
        }

        private class Resolvers
        {
            public IQueryable<ItemData> GetItems([Parent] ItemList ItemList, [ScopedService] AppDbContext context)
            {
                return context.ItemData.Where(x => x.ListId == ItemList.Id);
            }
        }
    }
}