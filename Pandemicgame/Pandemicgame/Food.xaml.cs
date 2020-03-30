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
    public partial class Food : ContentPage
    {
        public Food()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            if (MainPage.N > 0.5)
            {
                food.Text = String.Format("There is still enough food for some time.");
            }
            else if (MainPage.N <= 0) {
                food.Text = String.Format("There is no food left!!");
            }
            else
            {
                food.Text = String.Format("The food is running out!");
            }
        }
        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}