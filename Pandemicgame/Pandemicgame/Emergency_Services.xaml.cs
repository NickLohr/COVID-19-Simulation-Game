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
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Hospitals.Text = String.Format("{0:00}% of the hospitals are filled!", MainPage.LS*100);
            Police.Text = String.Format("{0:00}% of the police force is used!", MainPage.LP*100);
            
        }
        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}