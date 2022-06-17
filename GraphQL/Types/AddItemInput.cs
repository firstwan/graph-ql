using HotChocolate;

namespace GraphQL_example.GraphQL.Types
{
    public record AddItemInput(string title, string description, bool done, int listId);
}