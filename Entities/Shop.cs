using System;
using System.Collections.Generic;

public class Shop
{
    private List<Item> shopInventory;

    public Shop()
    {
        shopInventory = GenerateShopInventory();
    }

    private List<Item> GenerateShopInventory()
    {
        // Generate a list of items for the shop
        List<Item> items = new List<Item>
        {
            new Item("Dusty Leather", "Restores 10 HP", 1, 5),
            new Item("Unseen Miracles", "Restores 100 MP", 1, 20),
            new Item("Spearhead", "Granite-made spearhead, decently sharp.", 1, 10)
        };
        return items;
    }

    public void DisplayShop(Player player)
    {
        while (true)
        {
            Console.WriteLine("The shopkeeper gives you a distant gaze.");
            Console.WriteLine("1. Buy items");
            Console.WriteLine("2. Sell items");
            Console.WriteLine("3. Exit shop");

            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayBuyMenu(player);
                    break;
                case "2":
                    DisplaySellMenu(player);
                    break;
                case "3":
                    Console.WriteLine("The shopkeeper averts his gaze.");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.ReadKey();
            Console.Clear();
        }
    }

    private void DisplayBuyMenu(Player player)
    {
        Console.WriteLine("Items available for purchase:");
        for (int i = 0; i < shopInventory.Count; i++)
        {
            var item = shopInventory[i];
            Console.WriteLine($"{i + 1}. {item.Name} - {item.Description} (x{item.Quantity}) - {item.Price} pennies");
        }

        Console.Write("Enter the number of the item you want to buy: ");
        if (int.TryParse(Console.ReadLine(), out int itemNumber) && itemNumber > 0 && itemNumber <= shopInventory.Count)
        {
            var item = shopInventory[itemNumber - 1];
            if (player.Inventory.GetItemQuantity("Penny") >= item.Price)
            {
                player.Inventory.RemoveItem("Penny", item.Price);
                player.Inventory.AddItem(item);
                Console.WriteLine($"You bought {item.Name} for {item.Price} pennies.");
            }
            else
            {
                Console.WriteLine("You don't have enough pennies to buy this item.");
            }
        }
        else
        {
            Console.WriteLine("Invalid item number. Please try again.");
        }
    }

    private void DisplaySellMenu(Player player)
    {
        Console.WriteLine("Your inventory:");
        player.Inventory.ListItems();

        Console.Write("Enter the name of the item you want to sell: ");
        var itemName = Console.ReadLine();
        var item = player.Inventory.FindItem(itemName);
        if (item != null)
        {
            player.Inventory.RemoveItem(itemName, 1);
            player.Inventory.AddItem(new Item("Penny", "Currency", item.Price));
            Console.WriteLine($"You sold {item.Name} for {item.Price} pennies.");
        }
        else
        {
            Console.WriteLine("Item not found in your inventory.");
        }
    }
}