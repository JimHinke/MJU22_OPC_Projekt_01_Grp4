using Gym_Booking_Manager;
using System.Runtime.CompilerServices;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //User userContext;

            Service gurra = new Service("Gurrovic", "0123-45678", "gurrovic@mölk.se");
            Console.WriteLine(gurra);            
        }
        // Static methods for the program
    }
}