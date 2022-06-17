using HotChocolate;
using HotChocolate.Types;
using GraphQL_example.Domain.Models;

namespace GraphQL_example.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public ItemList OnListAdded([EventMessage] ItemList list) => list;
    }
}