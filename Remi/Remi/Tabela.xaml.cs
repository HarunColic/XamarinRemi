using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Remi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tabela : ContentPage
    {
        private List<string> _Imena;
        private List<int> _Bodovi;
        private int _Runda;
        public Tabela(List<string> Imena)
        {
            InitializeComponent();

            this._Runda = 1;
            this._Imena = Imena;
            this._Bodovi = new List<int>();

            foreach(var i in Imena)
            {
                this._Bodovi.Add(0);
            }


            foreach (var i in Imena)
            {
                Ime.Add(new ViewCell {View = new Label { Text = i + ":" + "       0" }});
            }
            Runda.Text = "Runda: " + _Runda.ToString();
        }
        public Tabela(List<string> Imena, List<int> Bodovi)
        {
            InitializeComponent();

            this._Imena = Imena;
            this._Bodovi = Bodovi;
            this._Runda++;

            for (int i = 0; i < Imena.Count(); i++)
            {
                Ime.Add(new ViewCell {View = new Label { Text = Imena.ElementAt(i) + ":      " + Bodovi.ElementAt(i) }});
            }
            Runda.Text = "Runda: " + _Runda.ToString();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DodajBodove(this._Imena, this._Bodovi));
        }
    }
}