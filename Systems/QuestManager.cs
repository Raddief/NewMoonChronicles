using System.Collections.Generic; // baru

public class QuestManager
{
    private List<Quest> activeQuests;

    public QuestManager()
    {
        activeQuests = new List<Quest>();
    }

    public void AddQuest(Quest quest)
    {
        activeQuests.Add(quest);
    }

    public void DisplayActiveQuests()
    {
        Console.WriteLine("Active Quests:");
        foreach (var quest in activeQuests)
        {
            Console.WriteLine($"- {quest.Title}: {quest.Status}");
        }
    }
}