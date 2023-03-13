
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Xml.Linq;
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

        #region Save to DB
        public async Task SaveToDatabaseAsync(Ticket ticket)
        {
            TicketEntity ticketEntity = ticket;
            _context.Add(ticketEntity);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Get All
        public async Task<IEnumerable<Ticket>> GetAll()
        {

            var list = new List<Ticket>();


            foreach (var ticketEntity in await _context.Ticket.Include(x => x.Comments).ToListAsync())
            {
                list.Add(ticketEntity);

            }

            return list;
        }
        /* var _ticket = await _context.Ticket.Include(x => x.Comments).ToListAsync();

         return _ticket.Select(_ticket => new Ticket
         {
             Id = _ticket.Id,
             Description = _ticket.Description,
             TicketDateTime = _ticket.TicketDateTime,
             FirstName = _ticket.CustomerFirstName,
             LastName = _ticket.CustomerLastName,
             Email = _ticket.CustomerEmail,
             PhoneNumber = _ticket.CustomerPhone,
             Status = (TicketStatus)_ticket.Status,

             Comments = _ticket.Comments.Select(x => new CommentEntity
             {
                 Id = x.Id,
                 CommentText = x.CommentText,
                 CommentDateTime = x.CommentDateTime,
                 TicketId = x.TicketId,
             }).ToList()
         });*/



        #endregion

        #region Get specific
        public async Task<Ticket> GetAsync(string email)
        {
            var ticketEntity = await _context.Ticket.FirstOrDefaultAsync(x => x.CustomerEmail == email);
            



            if (ticketEntity != null)
                return ticketEntity;

            else
                return null!;
        }
        #endregion

        #region Update
        public async Task UpdateAsync(Ticket entity)
        {
            var ticketEntity = await _context.Ticket.FirstOrDefaultAsync(x => x.CustomerEmail == entity.Email);
            if (ticketEntity != null)
            {
                if (entity.Status >= TicketStatus.NotStarted && entity.Status <= TicketStatus.Complete)
                {
                    ticketEntity.Status = (int)entity.Status;
                }
                _context.Update(ticketEntity);
                await _context.SaveChangesAsync();

            }
            
        }
        #endregion

        #region Remove
        public async Task RemoveAsync(string email)
        {
            var ticketEntity = await _context.Ticket.FirstOrDefaultAsync(x => x.CustomerEmail == email);
            if (ticketEntity != null)
            {
                _context.Remove(ticketEntity);
                await _context.SaveChangesAsync();
            }

        }
        #endregion
        public async Task AddCommentAsync(int ticketId, string comment)
        {
            var ticketEntity = await _context.Ticket.FindAsync(ticketId);

            if (ticketEntity != null)
            {
                var commentEntity = new CommentEntity
                {
                    CommentText = comment,
                    CommentDateTime = DateTime.Now,                   
                    Ticket = ticketEntity
                    

                };
                _context.Comment.Add(commentEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
