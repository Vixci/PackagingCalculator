using System;
using System.Collections.Generic;
using PackagingCalculator.Entities;

namespace PackagingCalculator.Helpers
{
    public class BinWidthCalculator : IBinWidthCalculator
    {
        public double calculateMinimumBinWidth(List<Item> items)
        {
            double minBinWidth = 0;

            foreach (Item item in items)
            {
                double width = getWidthProduct(item.Type.ToString());

                if (item.ToString() == "mug" && item.Quantity < 4)
                {
                    minBinWidth += width;
                }
                else {
                    minBinWidth += (width * (Math.Floor((double) item.Quantity / 4) + item.Quantity % 4));
                }
            }
            return minBinWidth;
        }

        //why? see note
        //TODO: Check right data type instead of double
        private double getWidthProduct(string name)
        {
            switch (name)
            {
                case "mug": return 94;
                case "photoBook": return 19;
                case "canvas": return 16;
                case "cards": return 4.7;
                case "calendar": return 10;
                default: return 0;
            }
        }
    }
}
