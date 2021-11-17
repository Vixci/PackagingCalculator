using System;
namespace PackagingCalculator.Entities
{
    public class Item
    {
        public long ItemId { get; set; }
        public long OrderId { get; set; }
        public ProductType Type { get; set; }
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
