using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.Models.Entities;

namespace TicketApp.Models
{
    internal class Ticket
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; } = null!;
        public string Description { get; set; } = null!;
        public TicketStatus Status { get; set; }

        public DateTime TicketDateTime { get; set; }
        public string CommentText { get; set; } = null!;
        public DateTime CommentDateTime { get; set; }
        public Ticket()
        {
            Status = TicketStatus.NotStarted;

        }
    }
}
