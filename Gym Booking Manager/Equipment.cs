using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;

namespace Gym_Booking_Manager
{
    internal class Equipment : Resources
    {
        private EquipmentCatagory equipmentCategory;

        public Equipment(string name, Calendar calendar = null) : base(name,calendar)
        {

        }
        public enum EquipmentCatagory
        {
            Dumbells,
            Barbells,
            Katlebells
        }
    }
}
