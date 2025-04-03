using Data;

namespace Akasztofa
{
    public partial class MainPage : ContentPage
    {
        private readonly Game game;

        public MainPage(Game game)
        {
            InitializeComponent();
            this.game = game;
            LoadDifficultyOptions();
            DifficultyPicker.ItemsSource = Enum.GetValues(typeof(Difficulty));
        }


        private void LoadDifficultyOptions()
        {
            var difficultyOptions = Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToList();
            DifficultyPicker.ItemsSource = difficultyOptions.Select(d => d.ToString()).ToList();
        }


        private void DifficultyPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

            var selectedDifficulty = (Difficulty)DifficultyPicker.SelectedIndex;
        }


        private async void StartGameClicked(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(NameEntry.Text))
            {
                await DisplayAlert("Hiba", "Kérjük, add meg a neved!", "OK");
                return;
            }


            if (DifficultyPicker.SelectedIndex == -1)
            {
                await DisplayAlert("Hiba", "Kérjük, válassz nehézségi szintet!", "OK");
                return;
            }

            string playerName = NameEntry.Text;
            var selectedDifficulty = (Difficulty)DifficultyPicker.SelectedItem;


            game.Kezdes(selectedDifficulty);

            var gamePage = new GamePage(game, playerName);
            await Navigation.PushAsync(gamePage);
        }
    }
}
