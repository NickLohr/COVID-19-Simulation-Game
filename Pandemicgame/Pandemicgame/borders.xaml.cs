using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pandemicgame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class borders : ContentPage
    {
        public borders()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            if (MainPage.foreigners)
            {
                Foreigners.Text = String.Format("Foreigners can pass border (tap to permit)");
                Foreigners.BackgroundColor = Color.Green;
                
            }
            if (MainPage.natives)
            {
                Natives.Text = String.Format("Natives can pass border (tap to permit)");
                Natives.BackgroundColor = Color.Green;
            }
            if (MainPage.supplies)
            {
                Supplies.Text = String.Format("Supplies can pass border (tap to permit)");
                Supplies.BackgroundColor = Color.Green;
            }

        }
        private void ForeignersButton_Clicked(object sender, EventArgs e)
        {
            if (!MainPage.foreigners)
            {
                (sender as Button).Text = String.Format("Foreigners can pass border (tap to permit)");
                (sender as Button).BackgroundColor = Color.Green;
                MainPage.foreigners = !MainPage.foreigners;
                MainPage.W += 0.33;
                MainPage.dBIP += 1;
            }
            else
            {
                (sender as Button).Text = String.Format("Foreigners can pass border (tap to deny)");
                (sender as Button).BackgroundColor = Color.Red;
                MainPage.foreigners = !MainPage.foreigners;
                MainPage.W -= 0.33;
                MainPage.dBIP -= 1;
            }
           
        }
        private void NativesButton_Clicked(object sender, EventArgs e)
        {

            if (!MainPage.natives)
            {
                (sender as Button).Text = String.Format("Natives can pass border (tap to permit)");
                (sender as Button).BackgroundColor = Color.Green;
                MainPage.natives = !MainPage.natives;
                MainPage.W -= 0.33;
                MainPage.dBIP += 1.5;
            }
            else
            {
                (sender as Button).Text = String.Format("Natives can pass border (tap to deny)");
                (sender as Button).BackgroundColor = Color.Red;
                MainPage.natives = !MainPage.natives;
                MainPage.W += 0.33;
                MainPage.dBIP -= 1.5;
            }
        }
        private void SuppliesButton_Clicked(object sender, EventArgs e)
        {
            
            if (!MainPage.supplies)
            {
                (sender as Button).Text = String.Format("Supplies can pass border (tap to permit)");
                (sender as Button).BackgroundColor = Color.Green;
                MainPage.supplies = !MainPage.supplies;
                MainPage.W -= 0.33;
                MainPage.dBIP += 2;
            }
            else
            {
                (sender as Button).Text = String.Format("Supplies can pass border (tap to deny)");
                (sender as Button).BackgroundColor = Color.Red;
                MainPage.supplies = !MainPage.supplies;
                MainPage.W += 0.33;
                MainPage.dBIP -= 2;
            }
        }
        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}