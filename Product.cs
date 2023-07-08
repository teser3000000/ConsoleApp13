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
    public void Sale(int value)
    {
        Quantity -= value;
    }

}

