using Microsoft.Extensions.Configuration;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Akasztofa
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadDifficultyOptions();
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
            string selectedDifficulty = DifficultyPicker.SelectedItem.ToString();

            var game = new Game(Configuration);
            game.Kezdes(selectedDifficulty);

            var gamePage = new GamePage(game, playerName);
            await Navigation.PushAsync(gamePage);
        }
    }
}
