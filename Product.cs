public class Product
{
    public string Name { get; private set; }
    public int Price { get; private set; }
    public int Quantity { get; private set; }
    public Product(string name, int price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
    public void Buy(int value) => Quantity -= value;
    public void Replenish(int value) => Quantity += value;
    public void EditName(string name) => Name = name;
    public void EditQuantity(int value) => Quantity = value;
    public void EditPrice(int value) => Price = value;

}

