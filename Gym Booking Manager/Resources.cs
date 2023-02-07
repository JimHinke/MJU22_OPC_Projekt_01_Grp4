using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class Resources
    {
        public string name { get; set; }
        public Calendar calendar { get; set; }

        public Resources(string name ="", Calendar calendar =null)
        {
            this.name = name;
            this.calendar = calendar;
        }

        public override string ToString()
        {
            return $"{name}";
        }
    }
}
