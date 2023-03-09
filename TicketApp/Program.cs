
using TicketApp.Services;



while (true)
{
    Console.Clear();
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("1. Create new ticket");
    Console.WriteLine("2. Show all tickets");
    Console.WriteLine("3. Show a specific ticket");
    Console.WriteLine("4. Update an existing ticket");
    Console.WriteLine("5. Remove a ticket");


    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            await TicketService.CreateTicketAsync();
            break;


        case "2":
            Console.Clear();
            await TicketService.ShowAllTicketsAsync();

            break;



        case "3":
            Console.Clear();
            await TicketService.ShowSpecificTicketAsync();
            break;


        case "4":
            Console.Clear();
            await TicketService.UpdateTicketAsync();
            break;


        case "5":
            Console.Clear();
            await TicketService.RemoveTicketAsync();
            break;
    }
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}


