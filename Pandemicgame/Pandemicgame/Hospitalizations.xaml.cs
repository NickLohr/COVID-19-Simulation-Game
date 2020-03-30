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
    public partial class Hospitalizations : ContentPage
    {
        public Hospitalizations()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            death.Text = String.Format("{0:0} already died!", MainPage.D);
            susceptile.Text = String.Format("{0:0} are still susceptile", MainPage.H);
            hospital.Text = String.Format("{0:0} need a hospital", MainPage.I * MainPage.h);
            revocered.Text = String.Format("{0:0} are cured", MainPage.C);
        }
        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}