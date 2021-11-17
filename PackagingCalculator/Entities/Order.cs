using System;
using System.Collections.Generic;

namespace PackagingCalculator.Entities
{
    public class Order
    {
        public long OrderId { get; set; }

        public List<Item> Items { get; set; }

        public double RequiredBinWidth { get; set; }
    }
}
