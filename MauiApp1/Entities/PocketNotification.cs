namespace MauiApp1.Entities;

public  class PocketNotification:BaseEntity
{
    public bool IsSendNotificationEnable { get; set; }
    public int TheDaysSinceThePocketIsCreated { get; set; }
}
