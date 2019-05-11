using System;
using System.Collections.Generic;
using System.Text;

namespace Mvc01.Models
{
    public class Ticket
    {
        public static int NextId = 1; // Class-scope (Shared) member
        public int Id { get; set; } // Instance members
        public bool IsCanceled { get; set; } = false;
        public Ticket() // private --> prevent object creation via "new" keyword
        {
            Id = NextId++;
        }

        public void Calcel() => IsCanceled = true; // instance method, access to intance fields
        //public void Reset() => NextId = 1; // instance method --> static fields
        public static void Reset() => NextId = 1; // instance method --> static fields
        // static method --//---> instance menbers
        public static Ticket Create() => new Ticket(); // factory method
    }

    public class TicketSample
    {
        public void Demo()
        {
            var t1 = new Ticket();
            var t2 = new Ticket();
            t1.Calcel();
            Ticket.Reset();
            var t3 = Ticket.Create();
        }
    }
}
