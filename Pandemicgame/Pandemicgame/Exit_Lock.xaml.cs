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
    public partial class Exit_Lock : ContentPage
    {
        public Exit_Lock()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            ExitLockSlider.Value = MainPage.A;
        }
        private void Slider_Moved(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            DisplayLabel.Text = String.Format("The Exit Lock is at {0:0}", value);
            MainPage.dBIP += -1+MainPage.A/100 + 1-value/100;
            MainPage.A = value;
            
        }
        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}