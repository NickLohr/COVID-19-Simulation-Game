using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pandemicgame
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public string TestLabelText { get; set; }


        async void PeopleButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new people());
            NavigationPage.SetHasNavigationBar(this, false);
        }
        async void SituationButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new situation());
            NavigationPage.SetHasNavigationBar(this, false);
        }
        async void LawsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new laws());
            NavigationPage.SetHasNavigationBar(this, false);
        }
        async void PredictionButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new prediction());
            NavigationPage.SetHasNavigationBar(this, false);
        }



        public static double I, P, H, D, C, A, U, M, G, LS, LP, d, r, F, N, B, S, W, dt, h, b,m,ttt, totaltime,BIP,dBIP;

        public static bool foreigners, natives, supplies, es, nes, sch, par, rest, done;
        public static DateTime TL = DateTime.Now;
        public static DateTimeOffset der = new DateTimeOffset(TL.Year, TL.Month, TL.Day, TL.Hour, TL.Minute, TL.Second, TimeSpan.Zero);
        public MainPage()
        {
            
            
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            I = 100;
            done = false;
            BIP = 1000000000;
            dBIP = 0; 
            D = 0;
            P = 7000000;
            C = 0;
            H = P - I - C;
            A = 1000;
            U = 0.9;
            m = 1;
            M = Math.Log10(A) / m;
            G = 0;
            LS = 0.1;
            LP = 0.1;
            d = 0.0006;
            r = 0.08;
            F = 1;
            N = 1;
            B = 0.1;
            S = 0;
            W = 1; //alles ist offen
            h = 0.02;
            ttt = 0;
            totaltime = 50;
            b = 40000;
            Gameloop();
            System.Diagnostics.Debug.WriteLine("Help so far ok");
        }
        public void Gameloop()
        {
          
            
            Device.StartTimer(TimeSpan.FromSeconds(1), Repeater);
        }
        public bool Repeater()
        {
            
            DateTime TN = DateTime.Now;
            DateTimeOffset dto = new DateTimeOffset(TN.Year, TN.Month, TN.Day, TN.Hour, TN.Minute, TN.Second, TimeSpan.Zero);
            //System.Diagnostics.Debug.WriteLine("Not so far ok");

            
            for (ulong tp = (ulong) der.ToUnixTimeSeconds(); tp <= (ulong)dto.ToUnixTimeSeconds(); tp++)
            {
                Calculater();
                
            }
            
            Device.BeginInvokeOnMainThread(() =>
            {
                BIPI.Text = String.Format("BIP:  {0:0}", BIP);
                Deaths.Text = String.Format("Deaths:  {0:0}", D);
                Infected.Text = String.Format("Infected:  {0:0}", I);
                Population.Text = String.Format("Population:  {0:0}", P);
            });
            TL = TN;
            return true;
        }
        public (double, double, double, double) Calculater()

        {
            System.Random ran = new System.Random(50);

            int b = ran.Next();
            G = b%5;
            if (ttt >= totaltime & !done)
            {
                Navigation.PushAsync(new end());
                done = true;
            }
            double dI, dC, dN;
            //System.Diagnostics.Debug.WriteLine(dI);
            F = 1 - (1 - N) / 4 - B / 4 - S / 4 - (1 - W) / 4;
            dN = -1 + W;
            LP = B / U;
            if (LP > 1)
            {
                LP = 1;
                U = U * 0 - 9; //reduziert
            }
            if (LP < 0)
            {
                LP = 0;
            }
            System.Diagnostics.Debug.WriteLine(B.ToString());
            U = 0.9 - (1 - F) / 4 - (1 - N) / 3 + Math.Log(B) / (10 * LP);
            if (U >= 1)
            {
                U = 1;
            }
            


            LS = Math.Min(1, I * h / b);
            if (LS >= 1)
            {
                //System.Diagnostics.Debug.WriteLine("ueberlastung!!!");
                d = d * 2;
                r = r * 0.5;
                LS = 1;
            }
            else if (LS < 0)
            {
                LS = 0;
            }
            dC = I * r;


            dI = -dC - I * d + U * I * ((Math.Max(5, Math.Min(A, 50)) + Math.Log(A)) * H / P) / (50) + I * (1 - U) * ((Math.Max(5, Math.Min(A, 50)) + 2 * Math.Log(A) + 50) * H / P / 50) + G + M * H / P;
            //dH = -dI - dC;

            double dt = 0.001;
            ttt += dt;
            BIP -= 1000000 * dBIP * dt;
            D += I * d * dt;
            //H =H + dH * dt;
            I = I + dI * dt;
            C = C + dC * dt;
            P += G;
            //D = D + d * I * LS;
            H = P - I - C - D;
            N = N + dN * dt;
            if (LS == 1)
            {
                d = d / 2;
                r = r / 0.5;
            }
            //System.Diagnostics.Debug.WriteLine(dI);

            return (I, C, H, D);

        }
    }


}
