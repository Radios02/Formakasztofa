using Data;

namespace Akasztofa
{
    public partial class GamePage : ContentPage
    {
        private readonly Game _game;
        private readonly string _playerName;

        public GamePage(Game game, string playerName)
        {
            InitializeComponent();
            _game = game;
            _playerName = playerName;
            UpdateUI();
        }

        private void OnGuessClicked(object sender, EventArgs e)
        {
            string betu = LetterEntry.Text?.ToLower();

            if (string.IsNullOrEmpty(betu))
            {
                DisplayAlert("Hiba", "Kérjük, adj meg egy betűt!", "OK");
                return;
            }

            if (_game.Tippel(betu))
            {
                UpdateUI();
            }

            if (_game.JatekVege())
            {
                var jatekos = new Player
                {
                    Name = _playerName,  
                    SolutionTime = _game.MegoldasiIdo,
                    Difficulty = _game.Nehezseg == Difficulty.easy ? Difficulty.easy : Difficulty.hard
                };
                MentsdElJatekosAdat(jatekos);

                DisplayAlert("Gratulálunk!", $"Nyertél! A játék ideje: {_game.MegoldasiIdo.TotalSeconds:F2} másodperc", "OK");

                Navigation.PopToRootAsync();
            }
        }


        private void UpdateUI()
        {

            CurrentWordLabel.Text = _game.Kimenet;


            TimeLabel.Text = $"Idő: {_game.MegoldasiIdo.TotalSeconds:F2} másodperc";
        }


        private async Task MentsdElJatekosAdat(Player jatekos)
        {
            using (var dbContext = new AkasztoDbContext())
            {
                dbContext.Players.Add(jatekos);  
                await dbContext.SaveChangesAsync();  
            }
        }
    }
}
