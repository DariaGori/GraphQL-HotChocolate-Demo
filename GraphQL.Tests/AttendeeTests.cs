using System;
using System.Threading.Tasks;
using GraphQL.Attendees;
using GraphQL.Data;
using GraphQL.Types;
using HotChocolate;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Snapshooter.Xunit;
using Xunit;

namespace GraphQL.Tests
{
    public class AttendeeTests
    {
        [Fact]
        public async Task Attendee_Schema_Unchanged()
        {
            // Initial schema prototype
            ISchema schema = await new ServiceCollection()
                .AddPooledDbContextFactory<ApplicationDbContext>(
                    options => options.UseInMemoryDatabase("Data Source=conferences.db"))
                .AddGraphQL()
                .AddQueryType(d => d.Name("Query"))
                .AddType<AttendeeQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                .AddType<AttendeeMutations>()
                .AddType<AttendeeType>()
                .AddType<SessionType>()
                .AddType<SpeakerType>()
                .AddType<TrackType>()
                .EnableRelaySupport()
                .BuildSchemaAsync();
            
            schema.Print().MatchSnapshot();
        }
        
        // Mutation test
        [Fact]
        public async Task RegisterAttendee()
        {
            IRequestExecutor executor = await new ServiceCollection()
                .AddPooledDbContextFactory<ApplicationDbContext>(
                    options => options.UseInMemoryDatabase("Data Source=conferences.db"))
                .AddGraphQL()
                .AddQueryType(d => d.Name("Query"))
                .AddType<AttendeeQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                .AddType<AttendeeMutations>()
                .AddType<AttendeeType>()
                .AddType<SessionType>()
                .AddType<SpeakerType>()
                .AddType<TrackType>()
                .EnableRelaySupport()
                // Set execution against the current schema
                .BuildRequestExecutorAsync();
            
            IExecutionResult result = await executor.ExecuteAsync(@"
                 mutation RegisterAttendee {
                     registerAttendee(
                         input: {
                             emailAddress: ""michael@chillicream.com""
                                 firstName: ""michael""
                                 lastName: ""staib""
                                 userName: ""michael3""
                             })
                     {
                         attendee {
                             id
                         }
                     }
                 }");
            
            result.ToJson().MatchSnapshot();
        }
    }
}
