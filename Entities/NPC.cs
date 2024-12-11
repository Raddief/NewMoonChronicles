public class NPC //baru
{
    public string Name { get; set; }
    public string Dialogue { get; set; }
    public List<Quest> Quests { get; set; }

    public NPC(string name, string dialogue)
    {
        Name = name;
        Dialogue = dialogue;
        Quests = new List<Quest>();
    }

    public void Talk()
    {
        Console.WriteLine($"{Name}: {Dialogue}");
    }

    public void OfferQuest(Quest quest)
    {
        Quests.Add(quest);
        Console.WriteLine($"{Name} offers you a quest: {quest.Title}");
    }
}