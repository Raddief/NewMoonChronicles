public class InventorySystem
{
    private List<string> items = new List<string>();

    public void AddItem(string item)
    {
        items.Add(item);
        Console.WriteLine($"{item} added to inventory.");
    }
}
