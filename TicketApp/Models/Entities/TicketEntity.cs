using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TicketApp.Models.Entities
{
    internal class TicketEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string CustomerFirstName { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string CustomerLastName { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string CustomerEmail { get; set; } = null!;

        [Column(TypeName = "char(13)")]
        public string? CustomerPhone { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; } = null!;

        public DateTime TicketDateTime { get; set; }


        //FK
        public int Status { get; set; }
        

        


        public static implicit operator Ticket(TicketEntity entity)
        {
            return new Ticket
            {
                Id = entity.Id,
                FirstName = entity.CustomerFirstName,
                LastName = entity.CustomerLastName,
                Email = entity.CustomerEmail,
                PhoneNumber = entity.CustomerPhone,               
                Description = entity.Description,
                Status = (TicketStatus)entity.Status,
                TicketDateTime = entity.TicketDateTime,

            };
        }

        public static implicit operator TicketEntity(Ticket entity)
        {
            return new TicketEntity
            {
                Id = entity.Id,
                CustomerFirstName = entity.FirstName,
                CustomerLastName = entity.LastName,
                CustomerEmail = entity.Email,
                CustomerPhone = entity.PhoneNumber,
                Description = entity.Description,                             
                TicketDateTime = entity.TicketDateTime,


               

            };
        }
    }
}
