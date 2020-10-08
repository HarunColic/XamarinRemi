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
    public partial class Names : ContentPage
    {
        private int _NumOfPlayers;
        public Names(int NumOfPlayers)
        {
            InitializeComponent();

            this._NumOfPlayers = NumOfPlayers;


            for(int i = 0; i < NumOfPlayers; i++)
            {

                Entries.Children.Add(new Entry());
            }

            Button dugme = new Button();

            dugme.Clicked += this.Button_Clicked;
            dugme.Text = "OK";

            Entries.Children.Add(dugme);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            List<string> Imena = new List<string>();

            var inputs = Entries.Children.OfType<Entry>();

            foreach(var i in inputs)
            {
                Imena.Add(i.Text);
            }

            await Navigation.PushAsync(new Tabela(Imena));
        }
    }
}