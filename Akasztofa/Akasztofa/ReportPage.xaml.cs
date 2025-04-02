public partial class ReportPage : ContentPage
{
    public ReportPage()
    {
        InitializeComponent();
        LoadTopPlayers();
    }

    private async void LoadTopPlayers()
    {
        using var dbContext = new GameDbContext();
        var topEasyPlayers = await dbContext.Jatekosok
            .Where(j => j.Nehezseg == "Konnyu")
            .OrderBy(j => j.MegoldasiIdo)
            .Take(3)
            .ToListAsync();

        var topHardPlayers = await dbContext.Jatekosok
            .Where(j => j.Nehezseg == "Nehez")
            .OrderBy(j => j.MegoldasiIdo)
            .Take(3)
            .ToListAsync();

        TopEasyPlayersList.ItemsSource = topEasyPlayers;
        TopHardPlayersList.ItemsSource = topHardPlayers;
    }
}
