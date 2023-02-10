using Gym_Booking_Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Booking_Manager.Interfaces;




namespace Gym_Booking_Manager
{
    internal interface IReservable
    {
        void MakeReservation(string owner);
        void CancelReservation();
        void ViewTimeTable(); // start and end as arguments?
    }
}