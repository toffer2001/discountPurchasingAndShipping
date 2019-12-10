using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Discount_Purchasing_and_Shipping
{
    class MarketingProduct : Item
    {

        double cost;
        int quantity;
        string quality;

        // MARKETING Product Bulk Pricing
        // Expensive items
        int[] expensiveQty = new int[3] { 50, 30, 15 };
        int[] expensiveDiscount = new int[3] { 20, 10, 5 };

        // Medium
        int[] medQty = new int[3] { 20, 10, 5 };
        int[] medDiscount = new int[3] { 12, 8, 3 };

        // Cheap items
        int[] cheapQty = new int[3] { 150, 100, 50 };
        int[] cheapDiscount = new int[3] { 20, 10, 5 };

        // SHIPPING zone shipping discount
        int[] distance = new int[3] { 1000, 500, 100 }; // miles
        int[] pricing = new int[3] { 50, 35, 20 };      // per box

        public MarketingProduct(string id, string name, double cost, int qty, string quality)
            : base(id, name)
        {
            this.cost = cost;
            quantity = qty;
            this.quality = quality;
        }

        public override string ToString()
        {
            return ($"{base.ToString()}: cost {cost:C}, quantity {quantity}");
        }

        public double getCost()
        {
            return cost;
        }

        public int getQty()
        {
            return quantity;
        }

        public string getQuality()
        {
            return quality;
        }

        // cost of item  with no discount
        public override double straightCost()
        {
            return (cost * quantity);
        }

        // cost of item WITH discount
        public override double discountAmount(int discount)
        {
            double amountToDiscount;
            amountToDiscount = (double)quantity * cost * discount / 100;

            return amountToDiscount;
        }

        
        // cost of item WITH discount better override
        public override double discountAmountImproved()
        {
            double volumeDiscountRate;

            switch (quality)
            {
                case "expensive":
                    printMarketingDiscounts(expensiveQty, expensiveDiscount);
                    volumeDiscountRate = getDiscountRate(expensiveQty, expensiveDiscount);
                    break;

                case "medium":
                    printMarketingDiscounts(medQty, medDiscount);
                    volumeDiscountRate = getDiscountRate(medQty, medDiscount);
                    break;

                case "cheap":
                    printMarketingDiscounts(cheapQty, cheapDiscount);
                    volumeDiscountRate = getDiscountRate(cheapQty, cheapDiscount);
                    break;

                default:
                    volumeDiscountRate = -1;
                    break;
            }
                    return volumeDiscountRate;
        }

        private int getDiscountRate(int[] qty, int[] discount) {

            int counter = 0;

            foreach (int q in qty)
            {
                if (quantity > q)
                {
                    return discount[counter];
                }
                else
                {
                    counter++;
                }
            }
            return 0;
    }

        // helper method to print respective discount for marketing
        private void printMarketingDiscounts(int[] qty, int[] discount)
        {
            WriteLine("Discount options:");
            Write("    ");

            for (int i = 0; i < qty.Length; i++)
            {
                Write($" {qty[i]} at {discount[i]:0.00} %  ");
            }
        }


    }
}
