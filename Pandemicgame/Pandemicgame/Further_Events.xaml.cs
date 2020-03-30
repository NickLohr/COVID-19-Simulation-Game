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
    public partial class Further_Events : ContentPage
    {
        public Further_Events()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            events.Text = String.Format("{0} new cases found through high winds", MainPage.G);
            

        }
        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}