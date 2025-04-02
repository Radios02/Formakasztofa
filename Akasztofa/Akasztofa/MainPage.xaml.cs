using Microsoft.Maui.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Windows.Gaming.Input;

private void StartGameClicked(object sender, EventArgs e)
{
    var jatek = new Game(Configuration);
    jatek.Kezdes(DifficultyPicker.SelectedItem.ToString());

    Navigation.PushAsync(new GamePage(jatek));
}
