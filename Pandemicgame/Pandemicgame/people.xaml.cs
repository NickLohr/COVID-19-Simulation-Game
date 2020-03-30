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
    public partial class people : ContentPage
    {
        public people()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void FoodButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Food());
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void HappinessButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Happiness());
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void ImplementationButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Implementation());
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void ProductivityButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Productivity());
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}