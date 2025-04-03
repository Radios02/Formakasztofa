using System.Linq;
using Microsoft.EntityFrameworkCore;
using Data;

namespace Akasztofa
{
public partial class ReportPage : ContentPage
{
    public ReportPage()
    {
        InitializeComponent();
        LoadTopPlayers();
    }

    private async void LoadTopPlayers()
    {
        using var dbContext = new AkasztoDbContext();
        var topEasyPlayers = await dbContext.Players
            .Where(p => p.Difficulty == Difficulty.easy)
            .OrderBy(p => p.SolutionTime)
            .Take(3)
            .ToListAsync();

        var topHardPlayers = await dbContext.Players
            .Where(p => p.Difficulty == Difficulty.hard)
            .OrderBy(p => p.SolutionTime)
            .Take(3)
            .ToListAsync();

        TopEasyPlayersList.ItemsSource = topEasyPlayers;
        TopHardPlayersList.ItemsSource = topHardPlayers;
    }
}
}