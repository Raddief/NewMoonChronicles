public class Inventory
{
    private List<Item> items;

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

    public void ListItems()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Inventory is empty.");
        }
        else
        {
            Console.WriteLine("Inventory:");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name} (x{item.Quantity})");
            }
        }
    }
}