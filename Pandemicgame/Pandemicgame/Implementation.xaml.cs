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
    public partial class Implementation : ContentPage
    {
        public Implementation()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            iml.Text = String.Format("{0:00}% of the population are living by the rules!", MainPage.U*100);
        }
        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}