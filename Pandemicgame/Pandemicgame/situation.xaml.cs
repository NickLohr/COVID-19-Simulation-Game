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
    public partial class situation : ContentPage
    {
        public situation()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void HospitalizationsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Hospitalizations());
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void VaccinationDevelopmentButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page1());
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void EmergencyServicesButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page2());
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void FurtherEventsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Further_Events());
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}