using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;

namespace Pandemicgame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class prediction : ContentPage
    {
        List<Entry> entries = new List<Entry> { };
        List<Entry> entries2 = new List<Entry> { };
        List<Entry> entries3 = new List<Entry> { };
        List<Entry> entries4 = new List<Entry> { };
        List<Entry> entries5 = new List<Entry> { };

        public static double I, P, H, D, C, A, U, M, G, LS, LP, d, r, F, N, B, S, W, dt, h, b, BIPi, dBIP;

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        public static DateTime TL = DateTime.Now;
        public void MainPage2()
        {
            //InitializeComponent();
           
            dBIP = MainPage.dBIP;
            BIPi = MainPage.BIP;
            I = MainPage.I;
            D = MainPage.D;
            P = MainPage.P;
            C = MainPage.C;
            H = P - I - C;
            A = MainPage.A;
            U = MainPage.U;
            M = MainPage.M;
            G = MainPage.G;
            LS = MainPage.LS;
            LP = MainPage.LP;
            d = MainPage.d;
            r = MainPage.r;
            F = MainPage.F;
            N = MainPage.N;
            B = MainPage.B;
            S = MainPage.S;
            W = MainPage.W; //alles ist offen
            h = MainPage.h;
            b = MainPage.b;
            //Device.StartTimer(new TimeSpan(0, 0, 1), Repeater);
            //7System.Diagnostics.Debug.WriteLine("Help so far ok");
        }
        public bool Repeater()
        {
            DateTime TN = DateTime.Now;

            for (DateTime tp = TL; tp <= TN; tp.AddSeconds(1))
            {
                Calculater();
            }

            return true;
        }
        public (double, double, double, double,double) Calculater()
        {
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

            U = 0.9 - (1 - F) / 4 - (1 - N) / 3 + 3 * B / 10 * LP;
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
            else if (LS<0)
            {
                LS = 0;
            }
            dC = I * r;


            dI = -dC - I * d + U * I * ((Math.Max(5, Math.Min(A, 50)) + Math.Log(A)) * H / P) / (50) + I * (1 - U) * ((Math.Max(5, Math.Min(A, 50)) + 2 * Math.Log(A) + 50) * H / P / 50) + G + M * H / P;
            //dH = -dI - dC;

            double dt = 0.5;
            D = D + I * d * dt;
            //H =H + dH * dt;
            I = I + dI * dt;
            C = C + dC * dt;
            //D = D + d * I * LS;
            P += G;
            H = P - I - C - D;
            N = N + dN * dt;
            if (LS == 1)
            {
                d = d / 2;
                r = r / 0.5;
            }
            //System.Diagnostics.Debug.WriteLine(dBIP);
            BIPi -= 1000000*dBIP * dt;
            return (I, C, H, D,BIPi);

        }
        public prediction()
        {
            InitializeComponent();
            MainPage2();
            NavigationPage.SetHasNavigationBar(this, false);
            double mt, mp, mv, mlp,mbibi;
            mt = 0;
            mp = 0;
            mv = 0;
            mlp = 0;
            mbibi = 0;
            for (int a = 0; a < 500; ++a)
            {
                double t, p, v, lp,bibi;

                (t, p, v, lp, bibi) = Calculater();
                if (t > mt)
                {
                    mt = t;
                }
                Entry b = new Entry((float)t)
                {
                    Color = SKColor.Parse("#123456"),
                    //Label = a.ToString(),
                    //ValueLabel = t.ToString(),

                };
                Entry c = new Entry((float)p)
                {
                    Color = SKColor.Parse("#123456"),
                    //Label = a.ToString(),
                    //ValueLabel = p.ToString(),

                };
                Entry q = new Entry((float)v)
                {
                    Color = SKColor.Parse("#123456"),
                    //Label = a.ToString(),
                    //ValueLabel = v.ToString(),

                };
                Entry wq = new Entry((float)lp)
                {
                    Color = SKColor.Parse("#123456"),
                    //Label = a.ToString(),
                    //ValueLabel = v.ToString(),

                };
                Entry bibb = new Entry((float)bibi)
                {
                    Color = SKColor.Parse("#123456"),
                    //Label = a.ToString(),
                    //ValueLabel = v.ToString(),

                };

                entries.Add(b);
                entries2.Add(c);
                entries3.Add(q);
                entries4.Add(wq);
                entries5.Add(bibb);
                mp = p;
                mv = v;
                mlp = lp;
                mbibi = bibi;
            }

            Infected.Text = "Infected          max: " + String.Format("{0:0}", mt);
            Health.Text = "healthy           at the end: " + String.Format("{0:0}", mv);
            Death.Text = "Deaths            total: " + String.Format("{0:0}", mlp);
            Cured.Text = "Cured           total: " + String.Format("{0:0}", mp);
            BIP.Text = "BIP           at the end: " + String.Format("{0:0}", mbibi);

            System.Diagnostics.Debug.WriteLine("now updating charts");
            Chart1.Chart = new LineChart() { Entries = entries, LineMode = Microcharts.LineMode.Straight };
            Chart2.Chart = new LineChart() { Entries = entries2, LineMode = Microcharts.LineMode.Straight };
            Chart3.Chart = new LineChart() { Entries = entries3, LineMode = Microcharts.LineMode.Straight };
            Chart4.Chart = new LineChart() { Entries = entries4, LineMode = Microcharts.LineMode.Straight };
            Chart5.Chart = new LineChart() { Entries = entries5, LineMode = Microcharts.LineMode.Straight };
            System.Diagnostics.Debug.WriteLine("upd charts");
        }
    }
}