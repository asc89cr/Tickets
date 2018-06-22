using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Numer of Tickets: ");
            int ticketCount = int.Parse(Console.ReadLine());
            Console.Write("Enter Number of Customer: ");
            int customerCount = int.Parse(Console.ReadLine());

            var result = GetTickets(ticketCount, customerCount);

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i].CustomerName);
                Console.WriteLine("Has the tickets:");
                for (int k = 0; k < result[i].Tickets.Count; k++)
                {
                    Console.WriteLine(result[i].Tickets[k].TicketName);
                }
            }

            Console.ReadLine();
        }

        static List<Customer> GetTickets(int tickets, int customers)
        {
            int TicketCount = 1;
            List<Customer> result = new List<Customer>();


            for (int i = 1; i <= customers; i++)
            {
                result.Add(new Customer { CustomerName = "Customer #" + i });
            }


            //Tickets are divisible by the number of customers  (Even)
            if (tickets % customers == 0)
            {
                for (int customer = 0; customer < result.Count; customer++)
                {
                    for (int i = 1; i <= 2; i++)
                    {
                        if (i == 1)
                        {
                            result[customer].Tickets = new List<Ticket>();
                            result[customer].Tickets.Add(new Ticket { TicketName = "Ticket #" + TicketCount });
                        }
                        else
                        {
                            int newTicketNumber = customer + 1 + customers;
                            result[customer].Tickets.Add(new Ticket { TicketName = "Ticket #" + newTicketNumber.ToString() });
                            TicketCount++;
                        }

                    }
                }

            }
            else
            {
                int deliveredTicket = 1;

                do
                {
                    for (int customer = 0; customer < result.Count; customer++)
                    {
                        if (tickets > 0)
                        {
                            if (result[customer].Tickets == null)
                                result[customer].Tickets = new List<Ticket>();
                            result[customer].Tickets.Add(new Ticket { TicketName = "Ticket #" + deliveredTicket });
                            deliveredTicket++;
                            tickets--;
                        }
                    }


                } while (tickets != 0);
            }




            return result;
        }
    }

    internal class Ticket
    {
        internal string TicketName { get; set; }
    }

    internal class Customer
    {
        internal string CustomerName { get; set; }
        internal List<Ticket> Tickets { get; set; }
    }
}
