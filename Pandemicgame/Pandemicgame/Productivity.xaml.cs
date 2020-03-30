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
    public partial class Productivity : ContentPage
    {
        public Productivity()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            prod.Text = String.Format("The effiency on the workplace changed to {0:00}%", MainPage.F *100/ 2 + MainPage.N*100 / 2);
        }
        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}