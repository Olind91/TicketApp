using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp.Models.Entities
{
    public enum TicketStatus
    {
        NotStarted = 1,
        InProgress = 2,
        Complete = 3
    }

    internal class StatusEntity
    {
        [Key]
        public int Id { get; set; }
        public TicketStatus Status { get; set; }
    }
}
