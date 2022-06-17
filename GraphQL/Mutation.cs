using System.Threading;
using System.Threading.Tasks;
using GraphQL_example.Domain.Contexts;
using GraphQL_example.Domain.Models;
using GraphQL_example.GraphQL.Types;
using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;

namespace GraphQL_example.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddListPayload> AddList(
            AddListInput input, 
            [ScopedService] AppDbContext context, 
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var list = new ItemList
            {
                Name = input.name
            };

            context.ItemList.Add(list);
            context.SaveChanges();


            // Emit the subscription after save the changes
            await eventSender.SendAsync(nameof(Subscription.OnListAdded), list, cancellationToken);

            return new AddListPayload(list);
        }

        [UseDbContext(typeof(AppDbContext))]
        public  AddItemPayload AddItem(AddItemInput input, [ScopedService] AppDbContext context)
        {
            var item = new ItemData 
            {
                Title = input.title,
                Description = input.description,
                Done = input.done,
                ListId = input.listId
            };

            context.ItemData.Add(item);
            context.SaveChanges();

            return new AddItemPayload(item);
        }
    }
}