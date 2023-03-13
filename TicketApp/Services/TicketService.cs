﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using TicketApp.Models;
using TicketApp.Models.Entities;

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
            

            Console.Clear();
            Console.WriteLine("Ticket has been created!");

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
                Console.WriteLine($"Date and time registered: {ticket.TicketDateTime}");
                Console.WriteLine($"Status: {ticket.Status} ");
                if (ticket.Comments.Any())
                {
                    Console.WriteLine("Comments:"); foreach (CommentEntity comment in ticket.Comments)
                    {
                        Console.WriteLine($"\t{comment.CommentText} \n \t{comment.CommentDateTime} \n");
                    }
                }

                
            }

        }

        public static async Task ShowSpecificTicketAsync()
        {
            var databaseService = new DatabaseService();
            Console.WriteLine("Input the email of the customerticket you wish to find");
            var email = Console.ReadLine();


            if (!string.IsNullOrEmpty(email))
            {
                var ticket = await databaseService.GetAsync(email);

                if (ticket != null)
                {
                    Console.WriteLine($"Customer ID: {ticket.Id}");
                    Console.WriteLine($"Name: {ticket.FirstName} {ticket.LastName}");
                    Console.WriteLine($"Email: {ticket.Email}");
                    Console.WriteLine($"Error Description: {ticket.Description}");
                    Console.WriteLine($"Date and time registered: {ticket.TicketDateTime}");
                    Console.WriteLine($"Status: {ticket.Status}");
                    //Console.WriteLine($"Comments: {ticket.CommentText} {ticket.CommentDateTime = DateTime.Now}");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine($"No customer with {email} exists");
            }



        }
        public static async Task UpdateTicketAsync()
        {
            
            Console.WriteLine("Input the email of the customer you wish to update");
            var email = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Ticket found! Please fill in the fields below what you want to update");


            if (!string.IsNullOrEmpty(email))
            {
                var databaseService = new DatabaseService();
                var ticket = await databaseService.GetAsync(email);
                if (ticket != null)
                {

                    Console.Write("Update status (1-3): ");
                    
                    TicketStatus status;
                    if (Enum.TryParse(Console.ReadLine(), out status) && Enum.IsDefined(typeof(TicketStatus), status))
                    {
                        ticket.Status = status;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input...");
                    }


                    await databaseService.UpdateAsync(ticket);
                    Console.Clear();
                    Console.WriteLine($"Status has been updated to {ticket.Status}!");
                }
            }
            else
            {
                Console.WriteLine($"No customer with {email} exists");
            }

        }


        public static async Task RemoveTicketAsync()
        {
            var databaseService = new DatabaseService();
            Console.WriteLine("Input the email of the customer you wish to remove");
            var email = Console.ReadLine();


            if (!string.IsNullOrEmpty(email))
            {
                await databaseService.RemoveAsync(email);
                Console.Clear();
                Console.WriteLine($"customer with {email} has been removed!");

            }
            else
            {
                Console.WriteLine($"No ticket is registered with that email!");
            }

        }

        public static async Task AddCommentToTicketAsync()
        {
            var databaseService = new DatabaseService();
            Console.WriteLine("Input the email of the customerticket you wish to find");
            var email = Console.ReadLine();


            if (!string.IsNullOrEmpty(email))
            {
                var ticket = await databaseService.GetAsync(email);

                if (ticket != null)
                {
                    Console.WriteLine("Add a comment...");
                    string comment = Console.ReadLine() ?? "";

                    await databaseService.AddCommentAsync(ticket.Id, comment);
                {
                        
                    }
                }
            }

        }
    }
}

