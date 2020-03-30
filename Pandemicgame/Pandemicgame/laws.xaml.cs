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
    public partial class laws : ContentPage
    {
        public laws()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void ClosingsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Closings());
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void MobilityButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new mobility());
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void BordersButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new borders());
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void ExitLockButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Exit_Lock());
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void PunishmentsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Punishments());
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}