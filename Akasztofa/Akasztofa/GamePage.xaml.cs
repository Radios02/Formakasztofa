using static System.Runtime.InteropServices.JavaScript.JSType;

public partial class GamePage : ContentPage
{
    private Game _game;

    public GamePage(Jatek game)
    {
        InitializeComponent();
        _game = game;
        UpdateUI();
    }

    private void OnGuessClicked(object sender, EventArgs e)
    {
        string betu = LetterEntry.Text;
        if (_game.Tippel(betu))
        {
            UpdateUI();
        }

        if (_game.JatekVege())
        {
            // Mentjük el az adatokat az adatbázisba
            var jatekos = new Jatekos
            {
                Nev = "Játékos Név", // Itt cseréld ki a név mezőre
                MegoldasiIdo = _game.MegoldasiIdo,
                Nehezseg = _game.Nehezseg
            };
            MentsdElJatekosAdat(jatekos);
            DisplayAlert("Gratulálunk!", "Nyertél!", "OK");
        }
    }

    private void UpdateUI()
    {
        CurrentWordLabel.Text = _game.Kimenet;
        TimeLabel.Text = $"Idő: {_game.MegoldasiIdo.TotalSeconds} másodperc";
    }

    private async Task MentsdElJatekosAdat(Jatekos jatekos)
    {
        using var dbContext = new GameDbContext();
        dbContext.Jatekosok.Add(jatekos);
        await dbContext.SaveChangesAsync();
    }
}
