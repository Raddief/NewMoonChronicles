public class Quest //baru
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; } // "Active", "Completed", "Failed"

    public Quest(string title, string description)
    {
        Title = title;
        Description = description;
        Status = "Active";
    }

    public void CompleteQuest()
    {
        Status = "Completed";
    }

    public void FailQuest()
    {
        Status = "Failed";
    }
}