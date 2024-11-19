public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }

    public Item(string name, string description, int quantity = 1)
    {
        Name = name;
        Description = description;
        Quantity = quantity;
    }

    public void Use()
    {
        // Implement the logic for using the item
        Console.WriteLine($"Using {Name}");
    }

    public void Use(Player player)
    {
        if (Name == "Potion")
        {
            Console.WriteLine($"Using {Name}. Restores 20 HP.");
            player.Heal(20); // Call the Heal method in Player
        }
        else if (Name == "Elixir")
        {
            Console.WriteLine($"Using {Name}. Restores 50 HP.");
            player.Heal(50); // Call the Heal method in Player
        }
        else
        {
            Console.WriteLine($"Using {Name}. No specific effect defined.");
        }
    }

    public void Inspect()
    {
        // Implement the logic for inspecting the item
        Console.WriteLine($"{Name}: {Description}");
    }

    public void AddQuantity(int amount)
    {
        Quantity += amount;
    }

    public void RemoveQuantity(int amount)
    {
        Quantity -= amount;
        if (Quantity < 0)
        {
            Quantity = 0;
        }
    }
}