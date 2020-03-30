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
    public partial class Happiness : ContentPage
    {
        public Happiness()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            happy.Text = String.Format("The citizens have an average happiness of {0:00} %.", MainPage.F * 100);
        }
        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}