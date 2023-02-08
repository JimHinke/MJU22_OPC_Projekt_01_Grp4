using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal abstract class User
    {        
        public int uniqueID { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        protected User(string name = "", string phone = "", string email = "")
        {
            this.uniqueID = new Random().Next(0, 1000);
            this.name = name;
            this.phone = phone;
            this.email = email;
        }        
        public override string ToString()
        {
            return "ID: " + uniqueID + " Name: " + name + " Phone: " + phone + " Email: " + email;
        }
    }

    internal class Service : User
    {  
        public Service(string name, string phone, string email) : base(name, phone, email)
        {
        }   
    }

    internal class Customer : User
    {
        public Customer(string name, string phone, string email) : base(name, phone, email)
        {
            this.name = name;
        }
        public override string ToString()
        {
            return $"Name: {name}\nEmail: {email}\nPhone Number: {phone}";
        }
    }

    internal class Staff : User
    {
        public Staff(string name, string phone, string email) : base(name, phone, email)
        {
        }
    }

    internal class Admin : Staff
    {
        public Admin(string name, string phone, string email) : base(name, phone, email)
        {
        }
    }
}