Cart cart = new Cart("user1");
cart.AddItem("item1", 2, 5.0m);
cart.AddItem("item2", 1, 10.0m);
cart.AddItem("item3", 1, 15.0m);
cart.DisplayCart();

cart.RemoveItem("item1");
cart.RemoveItem("item3"); 
Console.WriteLine("New cart amount: " + cart.CartAmount()); 
    
