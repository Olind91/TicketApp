
using Microsoft.EntityFrameworkCore;
using TicketApp.Contexts;
using TicketApp.Models;
using TicketApp.Models.Entities;

namespace TicketApp.Services
{
    internal class DatabaseService
    {
        private readonly DataContext _context;

        public DatabaseService()
        {
            _context = new DataContext();
        }

        public async Task SaveToDatabaseAsync(Ticket ticket)
        {
            TicketEntity ticketEntity = ticket;
            _context.Add(ticketEntity);
            await _context.SaveChangesAsync();
        }


        
        
        public async Task<IEnumerable<Ticket>> GetAll()
        {
            var list = new List<Ticket>();

            foreach (var ticketEntity in await _context.Ticket.ToListAsync())
            {
                list.Add(ticketEntity);
            }
            return list;
        }


    }
}
