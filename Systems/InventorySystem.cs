public class Inventory
{
    public List<Item> items;

    public Inventory()
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

    public void ListItem()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Inventory is empty.");
        }
        else
        {
            Console.WriteLine("##########################################");
            Console.WriteLine("#               Inventory                #");
            Console.WriteLine("##########################################");

            foreach (var item in items)
            {
                Console.WriteLine($"# {item.Name.PadRight(20)} (x{item.Quantity.ToString().PadLeft(4)})           #");
            }

            Console.WriteLine("##########################################");

        }
    }
    public List<Item> GetItems()
    {
        return items;
    }
}
