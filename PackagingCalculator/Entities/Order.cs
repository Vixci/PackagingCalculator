using System;
using System.Collections.Generic;

namespace PackagingCalculator.Entities
{
    public class Order
    {
        public string OrderID { get; set; }

        public List<Item> Items { get; set; }

        public int RequiredBinWidth { get; set; }
    }

    public class Item
    {
        public ProductType ProductType { get; set; }

        public int Quantity { get; set; }
    }

    public enum ProductType
    {
        photobook,
        calendar,
        canvas,
        cards,
        mug
    }
}
