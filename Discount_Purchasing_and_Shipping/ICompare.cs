using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount_Purchasing_and_Shipping
{
    interface ICompare
    {
        //int Compare(object obj, int[] qty, int[] discount);

        double straightCost();

        double discountAmount(int discount);

        double discountAmountImproved();
    }
}
