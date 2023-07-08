public class Product
{
    public string Name { get; private set; }
    public float Price { get; private set; }
    public int Quantity { get; private set; }
    public Product(string name, float price, int quantity)
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

