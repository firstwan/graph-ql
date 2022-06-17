using GraphQL_example.Domain.Contexts;
using GraphQL_example.Domain.Models;
using System.Linq;
using HotChocolate;
using HotChocolate.Data;

namespace GraphQL_example.GraphQL
{
    public class Query
    {
        // Will return all of our todo list items
        // We are injecting the context of our dbConext to access the db
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemData> GetItems([ScopedService] AppDbContext context)
        {
            return context.ItemData;
        }


        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemList> GetLists([ScopedService] AppDbContext context)
        {
            return context.ItemList;
        }
    }
}