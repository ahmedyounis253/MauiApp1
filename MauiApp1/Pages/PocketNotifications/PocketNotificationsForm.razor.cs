
namespace MauiApp1.Pages.PocketNotifications;

public partial class PocketNotificationsForm
{
    [Inject] public HttpClient httpClient { get; set; }
    [Parameter] public string SystemFeatureType { get; set; }
    [Parameter] public EventCallback OnCancel { get; set; }
    [Parameter] public EventCallback OnValidSubmit { get; set; }
    [Parameter] public PocketNotification pocketNotification { get; set; }
   private async void OnSubmitAsync()
    {
        if (SystemFeatureType == "Add")
        {
            await httpClient.PostAsJsonAsync("API/PocketNotifications/", pocketNotification);
            pocketNotification = await httpClient.GetFromJsonAsync<PocketNotification>($"API/PocketNotifications/{pocketNotification.Id}");
        }
        else if (SystemFeatureType == "Edit")
        {
            try
            {
                await httpClient.PutAsJsonAsync("API/PocketNotifications/", pocketNotification);
                pocketNotification = await httpClient.GetFromJsonAsync<PocketNotification>($"API/PocketNotifications/{pocketNotification.Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        else if (SystemFeatureType == "Delete")
            await httpClient.DeleteAsync($"api/pocketnotifications/{pocketNotification.Id}");
        await OnValidSubmit.InvokeAsync();
    }
}
