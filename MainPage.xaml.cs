using Microsoft.Maui.Controls;
using System;

namespace A2Layan
{
    public partial class MainPage : ContentPage
    {
        private Game game;
        private bool threeDiceMode;

        public MainPage()
        {
            InitializeComponent();

            // 1) Create a new Game instance
            game = new Game();

            // 2) Start in two‐dice mode
            threeDiceMode = false;
            DiceImage3.IsVisible = false;

            // 3) Ensure the labels start “reset”
            SumLabel.Text = "Click the button to roll the dice";
            ResultLabel.Text = "";
            DiceImage1.Source = "side_1.png";
            DiceImage2.Source = "side_1.png";
        }

        private void RollDice_Clicked(object sender, EventArgs e)
        {
            // 1) Tell Game to roll (it sets Die1/Die2/Die3 internally)
            game.RollDice(threeDiceMode);

            // 2) Read out the three dice values
            int die1 = game.Die1;
            int die2 = game.Die2;
            int die3 = game.Die3;

            int sum = die1 + die2 + die3;

            // 3) Update first two dice images
            DiceImage1.Source = $"side_{die1}.png";
            DiceImage2.Source = $"side_{die2}.png";

            // 4) Show or hide the third die and set its image
            if (threeDiceMode)
            {
                DiceImage3.IsVisible = true;
                DiceImage3.Source = $"side_{die3}.png";
            }
            else
            {
                DiceImage3.IsVisible = false;
            }

            // 5) Update labels
            SumLabel.Text = $"Total = {sum}";
            ResultLabel.Text = game.CheckWinner(sum, threeDiceMode);
        }

        private void Reset_Clicked(object sender, EventArgs e)
        {
            // 1) Clear any stored attempt count in Game
            game.ResetGame();

            // 2) Reset all three dice images to placeholder
            DiceImage1.Source = "side_1.png";
            DiceImage2.Source = "side_1.png";
            DiceImage3.Source = "placeholder.png";

            // 3) Hide the third die
            DiceImage3.IsVisible = false;

            // 4) Reset labels
            SumLabel.Text = "Click the button to roll the dice";
            ResultLabel.Text = "";
        }

        private void ToggleMode_Toggled(object sender, ToggledEventArgs e)
        {
            // 1) Flip the mode flag
            threeDiceMode = e.Value;

            // 2) Show or hide the third die immediately
            DiceImage3.IsVisible = threeDiceMode;

            // 3) Reset the board so no stale images or attempt counts remain
            Reset_Clicked(sender, e);
        }
    }
}
