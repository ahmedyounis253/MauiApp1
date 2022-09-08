namespace MauiApp1.Pages.PocketNotifications;

public partial class PocketNotificationsRoot
{
    [Inject] HttpClient httpClient {get; set;}
    List<PocketNotification> pocketNotifications { get; set; }
    private string SystemFeatureType { get; set; }
    private PocketNotification Source { get; set; }
    private bool showForm { get; set; }
    protected override async Task OnInitializedAsync()
    {

        pocketNotifications = await httpClient.GetFromJsonAsync<List<PocketNotification>>("/API/PocketNotifications");

         await  base.OnInitializedAsync();
    }
    private void ShowForm(PocketNotification pocketNotification, string SystemFeatureType)
    {
        this.SystemFeatureType = SystemFeatureType;
        Source = pocketNotification;
        showForm = true;
        StateHasChanged();

    }
    private async Task OnValidSubmit()
    {

        if (SystemFeatureType == "Add")
            pocketNotifications.Add(Source);
        else if(SystemFeatureType=="Edit")
            pocketNotifications[pocketNotifications.IndexOf(Source)] = Source;
        else if (SystemFeatureType == "Delete")
            pocketNotifications.Remove(Source);

        await OnCancel();
    }
   private async Task OnCancel()
    {

        showForm = false;
        Source = new();
        SystemFeatureType = "";

            StateHasChanged();
    }


}
