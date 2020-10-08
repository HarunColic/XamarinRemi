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
    public partial class DodajBodove : ContentPage
    {
        private List<string> _Imena;
        private List<int> _Bodovi;
        public DodajBodove(List<string> Imena, List<int> Bodovi)
        {
            InitializeComponent();

            _Bodovi = Bodovi;
            _Imena = Imena;

            foreach (var i in Imena) {
                Labels.Children.Add(new Label { Text = i });
                Labels.Children.Add(new Entry { Keyboard = Keyboard.Numeric});
            }

            var dugme = new Button { Text = "Dodaj" };
            dugme.Clicked += this.Button_Clicked;

            Labels.Children.Add(dugme);
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            var inputi = Labels.Children.OfType<Entry>().ToList();

            for(int i = 0; i < _Bodovi.Count(); i++)
            {

                _Bodovi[i] += int.Parse(inputi.ElementAt(i).Text);
            }

            await Navigation.PushAsync(new Tabela(this._Imena, this._Bodovi));
        }
    }
}