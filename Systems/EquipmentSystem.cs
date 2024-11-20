public class Equipment
{
    private bool equipped = false;
    public List<Item> items;

    public Equipment()
    {
        items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        var existingItem = items.Find(i => i.Name == item.Name);
        if (existingItem != null)
        {
            existingItem.AddQuantity(item.Quantity);
        }
        else
        {
            items.Add(item);
        }
    }

    public void RemoveItem(string itemName, int quantity)
    {
        var item = items.Find(i => i.Name == itemName);
        if (item != null)
        {
            item.RemoveQuantity(quantity);
            if (item.Quantity == 0)
            {
                items.Remove(item);
            }
        }
    }

    public Item FindItem(string itemName)
    {
        return items.Find(i => i.Name == itemName)!;
    }

    public int GetItemQuantity(string itemName)
    {
        var item = items.Find(i => i.Name == itemName);
        return item != null ? item.Quantity : 0;
    }

    public void UseItem(string itemName)
    {
        var item = items.Find(i => i.Name == itemName);
        if (item != null)
        {
            item.Use();
            RemoveItem(itemName, 1);
        }
        else
        {
            Console.WriteLine($"Item {itemName} not found in inventory.");
        }
    }

    public void InspectItem(string itemName)
    {
        var item = items.Find(i => i.Name == itemName);
        if (item != null)
        {
            item.Inspect();
        }
        else
        {
            Console.WriteLine($"Item {itemName} not found in inventory.");
        }
    }

    public void ListItem(Player player)
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Equipment inventory is empty.");
        }
        else
        {
            Console.WriteLine("##########################################");
            Console.WriteLine("#              Equipments                #");
            Console.WriteLine("##########################################");

            foreach (var item in items)
            {
                Console.WriteLine($"# {item.Name.PadRight(20)} (x{item.Quantity.ToString().PadLeft(4)})           #");
            }

            Console.WriteLine("##########################################");

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Equip an item");
            Console.WriteLine("2. Unequip an item");
            Console.Write("Enter your choice: ");
            string? input = Console.ReadLine();
            if (input == "1")
            {
                EquipItem(player);
            }
            else if (input == "2")
            {
                UnequipItem(player);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
    public List<Item> GetItems()
    {
        return items;
    }

    public void EquipItem(Player player)
    {
        if (equipped == true)
        {
            Console.WriteLine("An item is already equipped.");
            return;
        }

        Console.Write("Enter the name of the item you want to equip (0 to cancel): ");
        string? itemName = Console.ReadLine();
        var item = items.Find(i => i.Name == itemName);

        if (item != null)
        {
            item.Use(player);
            equipped = true;
        }
        else if (itemName == "0")
        {
            Console.WriteLine("Cancelled item usage.");
        }
        else
        {
            Console.WriteLine($"Item {itemName} not found in inventory.");
        }
    }

    public void UnequipItem(Player player)
    {
        if (equipped == false)
        {
            Console.WriteLine("No item is equipped.");
            return;
        }

        Console.Write("Enter the name of the item you want to unequip (0 to cancel): ");
        string? itemName = Console.ReadLine();
        var item = items.Find(i => i.Name == itemName);
        
        if (item != null)
        {
            item.Unuse(player);
            equipped = false;
        }
        else if (itemName == "0")
        {
            Console.WriteLine("Cancelled item usage.");
        }
        else
        {
            Console.WriteLine($"Item {itemName} not found in inventory.");
        }
    }
}
