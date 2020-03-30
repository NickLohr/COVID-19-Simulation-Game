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
    public partial class Punishments : ContentPage
    {
        public Punishments()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            PunishmentSlider.Value = Math.Pow(10,MainPage.B*2.5);

        }
        private void Slider_Moved(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            DisplayLabel.Text = String.Format("The fine amount is at {0:0}$",value);
            MainPage.dBIP -= MainPage.B;
            MainPage.B = Math.Log10(value) / 2.5;
            MainPage.dBIP += MainPage.B;

        }
        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}