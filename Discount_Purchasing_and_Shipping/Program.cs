using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Discount_Purchasing_and_Shipping
{
    class Program
    {
        static void Main(string[] args)
        {

        // hardcode marketing products
        Item[] items = new Item[4];
            //items[0] = new MarketingProduct("P123", "coffee mug", 12.29, 100, "expensive");
            //items[1] = new MarketingProduct("P987", "magnet, large", 3.29, 100, "expensive");
            //items[2] = new MarketingProduct("P547", "stuffed bear", 11.99, 30, "medium");
            //items[3] = new MarketingProduct("P879", "note cube", 2.50, 100, "cheap");

            items[0] = new MarketingProduct("P123", "coffee mug", 12.29, 40, "expensive");
            items[1] = new MarketingProduct("P987", "magnet, large", 3.29, 10, "expensive");
            items[2] = new MarketingProduct("P547", "stuffed bear", 11.99, 8, "medium");
            items[3] = new MarketingProduct("P879", "note cube", 2.50, 90, "cheap");

            // MARKETING Product Bulk Pricing
            // Expensive items
            int[] expensiveQty = new int[3] { 50, 30, 15};
            int[] expensiveDiscount = new int[3] { 20, 10, 5};

                // Medium
            int[] medQty = new int[3] { 20, 10, 5};
            int[] medDiscount = new int[3] { 12, 8, 3};

                // Cheap items
            int[] cheapQty = new int[3] { 150, 100, 50};
            int[] cheapDiscount = new int[3] { 20, 10, 5};

            // SHIPPING zone shipping discount
            int[] distance = new int[3] { 1000, 500, 100 }; // miles
            int[] pricing = new int[3] { 50, 35, 20 };      // per box

            WriteLine("SDEV 2410 Final Project by Kristoffer Keene\n");

            WriteLine("First Part: Purchasing Products");

            foreach(Item item in items)
            {
                WriteLine(item);
                determineQuality(item, expensiveQty, expensiveDiscount, medQty, medDiscount, cheapQty, cheapDiscount);
                WriteLine();
            }

            WriteLine("Summary:");
            WriteLine($"   Straight Cost: {totalStraightCost:C}");
            WriteLine($"Volume Discounts: {totalVolumeDiscount:C}");
            WriteLine($"   Cart Discount: {totalCartDiscount:C}");

            WriteLine("\nPart B: Shipping\n");

            // hardcode shipping boxes
            Item[] boxes = new Item[4];
            //boxes[0] = new ShippingBox("S678", "Miami FL", 10, 2000, 11.5, 8.5, 4, 5.2);
            //boxes[1] = new ShippingBox("S449", "Chicago IL", 25, 800, 5, 5, 5, 12.3);
            //boxes[2] = new ShippingBox("S721", "Denver CO", 30, 150, 6.5, 6.5, 3, 2.5);
            //boxes[3] = new ShippingBox("S678", "SLC UT", 50, 30, 14, 8, 1, 1.5);

            boxes[0] = new ShippingBox("S678", "Miami FL", 10, 9000, 11.5, 8.5, 4, 5.2);
            boxes[1] = new ShippingBox("S449", "Chicago IL", 25, 400, 5, 5, 5, 12.3);
            boxes[2] = new ShippingBox("S721", "Denver CO", 30, 150, 6.5, 6.5, 3, 2.5);
            boxes[3] = new ShippingBox("S678", "SLC UT", 50, 30, 14, 8, 1, 1.5);

             
            foreach (Item item in boxes)
            {
                WriteLine(item);
                printShippingDiscounts(distance, pricing);
                determineShipping(item, distance, pricing);
                WriteLine();
            }

            WriteLine("Summary:");
            WriteLine($"Zone shipping costs: {totalZoneShipping:C}");
            WriteLine($"     Flat rate cost: {totalFlatRate:C}");

            //pause
            WriteLine("\nPress any key to continue");
            ReadKey();
        }

        //marketing
        public static double totalStraightCost = 0;
        public static double totalVolumeDiscount = 0;
        public static double totalCartDiscount = 0;

        //shipping
        public static double totalZoneShipping = 0;
        public static double totalFlatRate = 0;

        // method matches marketing product type to the use helper method with respective quality type discount
        public static void determineQuality(Item item, int[] q1, int[] d1, int[] q2, int[] d2, int[] q3, int[] d3)
        {
            double volumeDiscount;
            double costAfterVolumeDiscount;
            int volumeDiscountRate;
            double cartDiscount;
            double costAfterCartDiscount;

            MarketingProduct product = (MarketingProduct)item;
            switch (product.getQuality())
            {
                case "expensive":
                    printMarketingDiscounts(q1, d1);
                    volumeDiscountRate = getDiscountRate(q1, d1, product.getQty());

                    // straight cost
                    WriteLine($"\nCost with no discount: {product.straightCost():C}");

                    // volume discount
                    volumeDiscount = product.discountAmount(volumeDiscountRate);
                    WriteLine($"Volume rate: {volumeDiscountRate:0.00} %, discount: {volumeDiscount:C}");
                    costAfterVolumeDiscount = product.straightCost() - volumeDiscount;
                    WriteLine($"Cost after Volume discount {costAfterVolumeDiscount:C}");

                    // whole cart discount
                    cartDiscount = wholeCartDiscount(product.straightCost());
                    WriteLine($"Whole cart discount: {cartDiscount:C}");
                    costAfterCartDiscount = product.straightCost() - cartDiscount;
                    WriteLine($"Cost after cart discount {costAfterCartDiscount:C}");

                    // totals
                    totalStraightCost += product.straightCost();
                    totalVolumeDiscount += costAfterVolumeDiscount;
                    totalCartDiscount += costAfterCartDiscount;
                    break;

                case "medium":
                    printMarketingDiscounts(q2, d2);
                    volumeDiscountRate = getDiscountRate(q2, d2, product.getQty());

                    // straight cost
                    WriteLine($"\nCost with no discount: {product.straightCost():C}");

                    // volume discount
                    volumeDiscount = product.discountAmount(volumeDiscountRate);
                    WriteLine($"Volume rate: {volumeDiscountRate:0.00} %, discount: {volumeDiscount:C}");
                    costAfterVolumeDiscount = product.straightCost() - volumeDiscount;
                    WriteLine($"Cost after Volume discount {costAfterVolumeDiscount:C}");

                    // whole cart discount
                    cartDiscount = wholeCartDiscount(product.straightCost());
                    WriteLine($"Whole cart discount: {cartDiscount:C}");
                    costAfterCartDiscount = product.straightCost() - cartDiscount;
                    WriteLine($"Cost after cart discount {costAfterCartDiscount:C}");

                    // totals
                    totalStraightCost += product.straightCost();
                    totalVolumeDiscount += costAfterVolumeDiscount;
                    totalCartDiscount += costAfterCartDiscount;
                    break;

                case "cheap":
                    printMarketingDiscounts(q3, d3);
                    volumeDiscountRate = getDiscountRate(q3, d3, product.getQty());
                    
                    // straight cost
                    WriteLine($"\nCost with no discount: {product.straightCost():C}");

                    // volume discount
                    volumeDiscount = product.discountAmount(volumeDiscountRate);
                    WriteLine($"Volume rate: {volumeDiscountRate:0.00} %, discount: {volumeDiscount:C}");
                    costAfterVolumeDiscount = product.straightCost() - volumeDiscount;
                    WriteLine($"Cost after Volume discount {costAfterVolumeDiscount:C}");

                    // whole cart discount
                    cartDiscount = wholeCartDiscount(product.straightCost());
                    WriteLine($"Whole cart discount: {cartDiscount:C}");
                    costAfterCartDiscount = product.straightCost() - cartDiscount;
                    WriteLine($"Cost after cart discount {costAfterCartDiscount:C}");

                    // totals
                    totalStraightCost += product.straightCost();
                    totalVolumeDiscount += costAfterVolumeDiscount;
                    totalCartDiscount += costAfterCartDiscount;
                    break;

                default:
                    WriteLine("Quality type doesn't match");
                    break;
            }
        }

        // helper method to print respective discount for marketing
        private static void printMarketingDiscounts(int[] qty, int[] discount)
        {
            WriteLine("Discount options:");
            Write("    ");

            for(int i = 0; i < qty.Length; i++)
            {
                Write($" {qty[i]} at {discount[i]:0.00} %  ");
            }
        }

        // discounted rate for Marketing
        private static int getDiscountRate(int[] qty, int[] discount, int productQty)
        {
            int counter = 0;
            foreach(int quantity in qty)
            {
                if(productQty > quantity)
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

        // whole cart discount for marketing
        private static double wholeCartDiscount(double cost)
        {
            double discount = .1;
            return cost * discount;
        }

        // discount for shipping
        public static void determineShipping(Item item, int[] distanceDiscount, int[] pricing)
        {
            int shippingDiscountRate;
            int shippingCost;
            double flatRate;

            ShippingBox shippingProduct = (ShippingBox)item;

            shippingDiscountRate = getShippingDiscountRate(distanceDiscount, pricing, shippingProduct.getDistance());
            Write($"\nZone rate: {shippingDiscountRate:C}");
            shippingCost = shippingDiscountRate * shippingProduct.getQty();
            Write($", ship cost: {shippingCost:C}");
            totalZoneShipping += shippingCost;
            flatRate = shippingProduct.straightCost();
            WriteLine($"\nFlat rate cost: {flatRate:C}");
            totalFlatRate += flatRate;

        }

        // helper method to print respective discount for shipping
        private static void printShippingDiscounts(int[] qty, int[] discount)
        {
            WriteLine("Zone options:");
            Write("    ");

            for (int i = 0; i < qty.Length; i++)
            {
                Write($" {qty[i]} miles at {discount[i]:C}  ");
            }
        }

        // discounted rate for Shipping
        private static int getShippingDiscountRate(int[] qty, int[] discount, int distance)
        {
            int counter = 0;
            foreach (int quantity in qty)
            {
                if (distance > quantity)
                {
                    return discount[counter];
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
