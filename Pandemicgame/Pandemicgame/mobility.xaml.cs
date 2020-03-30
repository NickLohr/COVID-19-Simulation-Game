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
    public partial class mobility : ContentPage
    {
        public mobility()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            MobilitySlider.Value = MainPage.m * 100;
            
        }
        private void Slider_Moved(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            DisplayLabel.Text = String.Format("The Mobility is at {0:0}", value);
            MainPage.m = value/100;
            MainPage.M = Math.Log10(MainPage.A) / MainPage.m;
            MainPage.dBIP += -(100 - value);
        }
        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}