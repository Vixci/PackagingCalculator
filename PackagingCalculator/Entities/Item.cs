using System;
namespace PackagingCalculator.Entities
{
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
