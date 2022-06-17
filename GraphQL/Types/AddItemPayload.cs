using HotChocolate;
using GraphQL_example.Domain.Models;

namespace GraphQL_example.GraphQL.Types
{
    public record AddItemPayload(ItemData item);
}