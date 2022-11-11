#region OCP_before

//class Product
//{
//    public Guid Id { get; set; }
//    public string Name { get; set; }
//    public decimal Price { get; set; }
//    public decimal Weight { get; set; }
//}

//class Order
//{
//    public List<Product> items { get; set; }
//    public string shipping { get; set; }



//    public decimal GetTotal() => items.Sum(p => p.Price);

//    public decimal GetTotalWeight() => items.Sum(p => p.Weight);

//    public void SetShippingType(string type) => shipping = type;

//    public decimal GetShippingCost()
//    {
//        if (shipping == "ground")
//        {
//            if (GetTotal() > 100)
//                return 0;

//            return Math.Max(10, GetTotalWeight() * 1.5m);
//        }

//        if (shipping == "air")
//            return Math.Max(20, GetTotalWeight() * 3);

//        throw new ArgumentException(nameof(shipping));
//    }

//    public DateTime GetShippingDate()
//    {
//        if (shipping == "ground")
//            return DateTime.Now.AddDays(7);

//        if (shipping == "air")
//            return DateTime.Now.AddDays(1);

//        throw new ArgumentException(nameof(shipping));
//    }
//}

#endregion

#region OCP_AFTER

class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal Weight { get; set; }
}


interface IShipping
{
    DateTime GetDate(Order order);
    decimal GetCost(Order order);
}

class Ground : IShipping
{
    public decimal GetCost(Order order)
    {
        if (order.GetTotal() > 100)
            return 0;

        return Math.Max(10, order.GetTotalWeight() * 1.5m);
    }

    public DateTime GetDate(Order order)
    {
        return DateTime.Now.AddDays(7);
    }
}

class Air : IShipping
{
    public decimal GetCost(Order order)
    {
        return Math.Max(20, order.GetTotalWeight() * 3);
    }

    public DateTime GetDate(Order order)
    {
        return DateTime.Now.AddDays(1);
    }
}




class Order
{
    public List<Product> items = new();
    public IShipping shipping;



    public decimal GetTotal() => items.Sum(p => p.Price);

    public decimal GetTotalWeight() => items.Sum(p => p.Weight);

    public void SetShippingType(IShipping type) => shipping = type;

    public decimal GetShippingCost() => shipping.GetCost(this);

    public DateTime GetShippingDate() => shipping.GetDate(this);
}

#endregion