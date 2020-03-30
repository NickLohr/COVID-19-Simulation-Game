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
    public partial class Closings : ContentPage
    {
        public Closings()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            if (MainPage.es)
            {
                Essential_Stores.Text = String.Format("essential stores (tap to open)");
                Essential_Stores.BackgroundColor = Color.Green;
                
                
            }
            if (MainPage.nes)
            {
                Non_Essential_Stores.Text = String.Format("Non essential stores (tap to open)");
                Non_Essential_Stores.BackgroundColor = Color.Green;

            }
            if (MainPage.sch)
            {
                Schools.Text = String.Format("Schools (tap to open)");
                Schools.BackgroundColor = Color.Green;
            }
            if (MainPage.par)
            {
                Parks.Text = String.Format("Parks (tap to open)");
                Parks.BackgroundColor = Color.Green;
            }
            if (MainPage.rest)
            {
                Restaurants.Text = String.Format("Restaurants (tap to open)");
                Restaurants.BackgroundColor = Color.Green;
            }
        }
        private void EssentialStoresButton_Clicked(object sender, EventArgs e)
        {
            if (!MainPage.es)
            {
                (sender as Button).Text = String.Format("Essential stores (tap to open)");
                (sender as Button).BackgroundColor = Color.Green;
                MainPage.es = !MainPage.es;
                MainPage.dBIP += 1.1;
                MainPage.S += 0.5;
            }
            else
            {
                (sender as Button).Text = String.Format("Essential stores (tap to close)");
                (sender as Button).BackgroundColor = Color.Red;
                MainPage.es = !MainPage.es;
                MainPage.dBIP -= 1.1;
                MainPage.S -= 0.5;
            }
            
        }
        private void NonEssentialStoresButton_Clicked(object sender, EventArgs e)
        {
          
            if (!MainPage.nes)
            {
                (sender as Button).Text = String.Format("Non essential stores (tap to open)");
                (sender as Button).BackgroundColor = Color.Green;
                MainPage.nes = !MainPage.nes;
                MainPage.dBIP += 0.9;
                MainPage.S += 0.4;
            }
            else
            {
                (sender as Button).Text = String.Format("Non essential stores (tap to close)");
                (sender as Button).BackgroundColor = Color.Red;
                MainPage.nes = !MainPage.nes;
                MainPage.dBIP -= 0.9;
                MainPage.S -= 0.4;

            }

        }
        private void SchoolsButton_Clicked(object sender, EventArgs e)
        {
            
            if (!MainPage.sch)
            {
                (sender as Button).Text = String.Format("Schools (tap to open)");
                (sender as Button).BackgroundColor = Color.Green;
                MainPage.sch = !MainPage.sch;
                MainPage.dBIP += 0.3;
                MainPage.S += 0.1;
            }
            else
            {
                (sender as Button).Text = String.Format("Schools (tap to close)");
                (sender as Button).BackgroundColor = Color.Red;
                MainPage.sch = !MainPage.sch;
                MainPage.dBIP -= 0.3;
                MainPage.S -= 0.1;
            }
        }
        private void ParksButton_Clicked(object sender, EventArgs e)
        {
           
            if (!MainPage.par)
            {
                (sender as Button).Text = String.Format("Parks (tap to open)");
                (sender as Button).BackgroundColor = Color.Green;
                MainPage.par = !MainPage.par;
                MainPage.dBIP += 0.5;
                MainPage.S += 0.1;
            }
            else
            {
                (sender as Button).Text = String.Format("Parks (tap to close)");
                (sender as Button).BackgroundColor = Color.Red;
                MainPage.par = !MainPage.par;
                MainPage.dBIP -= 0.5;
                MainPage.S -= 0.1;
            }
        }
        private void RestaurantsButton_Clicked(object sender, EventArgs e)
        {
            (sender as Button).Text = String.Format("Restaurants (tap to open)");
            (sender as Button).BackgroundColor = Color.Green;
            if (!MainPage.rest)
            {
                (sender as Button).Text = String.Format("Restaurants (tap to open)");
                (sender as Button).BackgroundColor = Color.Green;
                MainPage.rest = !MainPage.rest;
                MainPage.dBIP += 1;
                MainPage.S += 0.3;
            }
            else
            {
                (sender as Button).Text = String.Format("Restaurants (tap to close)");
                (sender as Button).BackgroundColor = Color.Red;
                MainPage.rest = !MainPage.rest;
                MainPage.dBIP -= 1;
                MainPage.S -= 0.3;

            }


        }
            private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

    }
}