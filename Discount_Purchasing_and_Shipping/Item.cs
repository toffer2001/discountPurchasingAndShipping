using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount_Purchasing_and_Shipping
{
    abstract class Item : ICompare
    {
        string id, name;

        public Item(string id, string name)
        {
            this.id = id;
            this.name = name;

        }

        public override string ToString()
        {
            return ($"{id} {name}");
        }

        public int Compare(Object obj, int[] qty, int[] discount)
        {
            int counter = 0;

            MarketingProduct otherProduct = (MarketingProduct)obj;

            foreach(int quantity in qty)
            {
                if (otherProduct.getQty() > quantity)
                {
                    return discount[counter];
                }
                counter++;
            }
            return 0;

        }

        public string getName()
        {
            return name;
        }

        abstract public double straightCost();

        abstract public double discountAmount(int discount);

        abstract public double discountAmountImproved();
    }
}
