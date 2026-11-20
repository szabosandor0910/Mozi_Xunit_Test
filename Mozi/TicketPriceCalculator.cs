using System;
using System.Collections.Generic;
using System.Text;

namespace Mozi
{
    public class TicketPriceCalculator
    {
        public int CalculatePrice(int age, bool isWeekend, bool is3D)
        {
            if (age < 0 || age > 120)
            {
                return -1;
            }

            if (age <= 5)
            {
                return 0;
            }

            int price = isWeekend ? 2490 : 1990;

            if (is3D)
            {
                price += 500;
            }

            if (age <= 14)
            {
                return price / 2;
            }

            if (age >= 65)
            {
                return price * 65 / 100;
            }

            return price;
        }
    }
}
