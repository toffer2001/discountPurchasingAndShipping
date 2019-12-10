using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount_Purchasing_and_Shipping
{
    class ShippingBox : Item
    {
        int quantity;
        int distance;
        double length, width, height, weight;

        // SHIPPING zone shipping discount
        int[] distanceDiscount = new int[3] { 1000, 500, 100 }; // miles
        int[] pricing = new int[3] { 50, 35, 20 };      // per box

        public ShippingBox(string id, string name, int qty, int distance, double l, double w, double h, double weight)
            : base(id, name)
        {
            this.distance = distance;
            quantity = qty;
            length = l;
            width = w;
            height = h;
            this.weight = weight;
        }

        public override string ToString()
        {
            return ($"{base.ToString()}: {quantity} boxes, distance {distance} miles " +
                $"\nSize: {length} x {width} x {height}, weight: {weight}");
        }

        // cost of item flat rate $35/box
        public override double straightCost()
        {
            return (quantity * 35);
        }

        // cost of item WITH discount
        public override double discountAmount(int discount)
        {
            double amountToDiscount;
            amountToDiscount = (double)quantity  * discount / 100;

            return amountToDiscount;
        }

        public int getDistance()
        {
            return distance;
        }

        public int getQty()
        {
            return quantity;
        }

        // cost of item WITH discount better override
        public override double discountAmountImproved()
        {
            int counter = 0;
            foreach (int quantity in distanceDiscount)
            {
                if (distance > quantity)
                {
                    return distanceDiscount[counter];
                }
                else
                {
                    counter++;
                }
            }
            return 10; // min price
        }

    }
}
