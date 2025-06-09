
using Microsoft.Maui.Controls;

namespace A2Layan
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Wrap MainPage in a NavigationPage to get the navigation bar at the top
            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Colors.Purple,   // optional: set nav‐bar background
                BarTextColor = Colors.White             // optional: set title text color
            };
        }
    }
}
