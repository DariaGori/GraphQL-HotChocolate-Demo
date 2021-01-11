using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Data
{
    public class Attendee
    {
        public int Id { get; set; }

        [Required] [StringLength(200)] public string FirstName { get; set; } = default!;

        [Required]
        [StringLength(200)]
        public string LastName { get; set; } = default!;

        [Required]
        [StringLength(200)]
        public string UserName { get; set; } = default!;

        [StringLength(256)]
        public string? EmailAddress { get; set; }

        public ICollection<SessionAttendee> SessionsAttendees { get; set; } =
            new List<SessionAttendee>();
    }
}