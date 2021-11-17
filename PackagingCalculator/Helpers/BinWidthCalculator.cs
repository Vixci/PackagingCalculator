using System;
using System.Collections.Generic;
using PackagingCalculator.Entities;

namespace PackagingCalculator.Helpers
{
    public class BinWidthCalculator : IBinWidthCalculator
    {
        public double calculateMinimumBinWidth(ICollection<Item> items)
        {
            double minBinWidth = 0;

            foreach (Item item in items)
            {
                double width = getWidthProduct(item.Type);

                if (item.Type.Equals(ProductType.mug))
                {
                    width = width * Math.Floor((double)(item.Quantity - 1) / 4 + 1);
                }

                minBinWidth += width;

            }
            return minBinWidth;
        }

        //why? see note
        //TODO: Check right data type instead of double
        private double getWidthProduct(ProductType type)
        {
            switch (type)
            {
                case ProductType.mug: return 94;
                case ProductType.photobook: return 19;
                case ProductType.canvas: return 16;
                case ProductType.cards: return 4.7;
                case ProductType.calendar: return 10;
                default: return 0;
            }
        }
    }
}
