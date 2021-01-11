using GraphQL.Data;
using HotChocolate.Data.Filters;

namespace GraphQL.Sessions
{
    // Define which fields on the entity cannot be used for filtering
    public class SessionFilterInputType : FilterInputType<Session>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Session> descriptor)
        {
            descriptor.Ignore(t => t.Id);
            descriptor.Ignore(t => t.TrackId);
        }
    }
}