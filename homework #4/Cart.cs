
public class Cart
{
    private readonly string userId;
    private readonly List<CartItem> items;

    public Cart(string userId)
    {
        this.userId = userId;
        items = new List<CartItem>();

    }
    public IReadOnlyList<CartItem> Items => items.AsReadOnly();

    public decimal CartAmount()
    {
        decimal total = 0;
        foreach (var item in items)
        {
            total += item.Quantity * item.Price;
        }
        return total;
    }
    public void DisplayCart()
    {
        Console.WriteLine($"Cart for user {userId}:");
        foreach (var item in items)
        {
            Console.WriteLine($"- {item.Quantity}x {item.Name} at {item.Price:C}");
        }
        Console.WriteLine($"Total cart amount: {CartAmount():C}");
    }
    public void AddItem(string itemName, int quantity, decimal price)
    {
        var existingItem = items.Find(item => item.Name == itemName);
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            var newItem = new CartItem(itemName, quantity, price);
            items.Add(newItem);
        }
    }

    public void RemoveItem(string itemName)
    {
        var existingItem = items.Find(item => item.Name == itemName);
        if (existingItem != null)
        {
            items.Remove(existingItem);
        }
        else
        {
            throw new ArgumentException("Item not found in the cart.");
        }
    }
}