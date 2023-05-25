namespace Cart_Test;

public class CartTests
{
    private Cart cart;

    [SetUp]
    public void Setup()
    {       
        cart = new Cart("user1");
        Console.WriteLine("SetUp: ");
    }

    [TearDown]
    public void TearDown()
    {
        Console.WriteLine ("ShutDown: ");
    }

    [Test]
    public void TestAddItem()
    {        
        cart.AddItem("item1", 2, 20.0m);
        Console.WriteLine("TestAddItem:");
        Assert.AreEqual(1, cart.Items.Count);
        Assert.AreEqual("item1", cart.Items[0].Name);
        Assert.AreEqual(2, cart.Items[0].Quantity);
        Assert.AreEqual(20.0m, cart.Items[0].Price);
    }

    [Test]
    public void TestRemoveItem()
    {
        Console.WriteLine("TestRemoveIte:");
        cart.AddItem("item1", 2, 20.0m);
        cart.RemoveItem("item1");
        Assert.AreEqual(0, cart.Items.Count);
    }

    [Test]
    public void TestCartAmount()
    {
        Console.WriteLine("TestCartAmount:");
        cart.AddItem("item1", 2, 20.0m);
        cart.AddItem("item2", 1, 5.0m);
        Assert.AreEqual(45.0m, cart.CartAmount());
    }

    [Test]
    public void TestRemoveItemNotFound()
    {
        Console.WriteLine("TestRemoveItemNotFound:");
        cart.AddItem("item1", 2, 20.0m);
        Assert.Throws<ArgumentException>(() => cart.RemoveItem("item2"));
    }

    [Test]
    public void TestCartItemPriceNegative()
    {
        Console.WriteLine("TestCartItemPriceNegativ:");
        Assert.Throws<ArgumentException>(() => new CartItem("item1", 1, -10.0m));
    }
}
