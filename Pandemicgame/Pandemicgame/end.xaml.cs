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
    public partial class end : ContentPage
    {
        public end()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BIPI.Text = String.Format("BIP:  {0:0}", MainPage.BIP);
            Deaths.Text = String.Format("Deaths:  {0:0}", MainPage.D);
            Infected.Text = String.Format("Infected:  {0:0}", MainPage.I);
            Population.Text = String.Format("Population:  {0:0}", MainPage.P);
        }
    }
}