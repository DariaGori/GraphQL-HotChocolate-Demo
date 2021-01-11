using GraphQL.Data;
using HotChocolate.Types.Relay;

namespace GraphQL.Attendees
{
    public record CheckInAttendeeInput(
        [ID(nameof(Session))]
        int SessionId,
        [ID(nameof(Attendee))]
        int AttendeeId);
}