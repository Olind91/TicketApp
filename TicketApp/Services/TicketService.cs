using TicketApp.Models;


namespace TicketApp.Services
{
    public class TicketService
    {
        
        public static async Task CreateTicketAsync()
        {
            var databaseService = new DatabaseService();
            var ticket = new Ticket();

            Console.Write("Firstname: ");
            ticket.FirstName = Console.ReadLine() ?? "";

            Console.Write("Lastname: ");
            ticket.LastName = Console.ReadLine() ?? "";

            Console.Write("Email: ");
            ticket.Email = Console.ReadLine() ?? "";

            Console.Write("Phonenumber: ");
            ticket.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Error Description: ");
            ticket.Description = Console.ReadLine() ?? "";

            ticket.TicketDateTime = DateTime.Now;

            

            //Save to DB
            await databaseService.SaveToDatabaseAsync(ticket);

        }

        public static async Task ShowAllTicketsAsync()
        {
            var databaseService = new DatabaseService();
            var tickets = await databaseService.GetAll();

            foreach (Ticket ticket in tickets)
            {
                Console.WriteLine($"Customer ID: {ticket.Id}");
                Console.WriteLine($"Name: {ticket.FirstName} {ticket.LastName}");
                Console.WriteLine($"Email: {ticket.Email}");
                Console.WriteLine($"Phonenumber: {ticket.PhoneNumber}");
                Console.WriteLine($"Error Description: {ticket.Description}");
                Console.WriteLine($"Date and time: {ticket.TicketDateTime}");
                Console.WriteLine("");
            }

        }

        public static async Task ShowSpecificTicketAsync()
        {

            


        }
        public static async Task UpdateTicketAsync()
        {
            
                    
        }


        public static async Task RemoveTicketAsync()
        {
           
        }
    }
}

