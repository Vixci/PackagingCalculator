using System;
using System.Collections.Generic;
using PackagingCalculator.Entities;

namespace PackagingCalculator.Helpers
{
    public interface IBinWidthCalculator
    {
        double calculateMinimumBinWidth(List<Item> items);
    }
}
