
public class CartItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public readonly decimal Price;

    public CartItem(string name, int quantity, decimal price)
    {
        Name = name;
        Quantity = quantity;
        Price = price > 0 ? price : throw new ArgumentException("Price must be positive.");
    }
}