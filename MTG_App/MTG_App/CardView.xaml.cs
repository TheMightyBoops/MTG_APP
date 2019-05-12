using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MTG_App
{


    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardView : ContentPage
	{
        ObservableCollection<MTGCard> cards;
        MTGCard ShownCard;
        public CardView ()
		{
           
            InitializeComponent ();
            ShownCard = (MTGCard) this.BindingContext;
            int Index = App.IndexClicked;
            //GetDBCards(Index);
        }

        async public void GetDBCards(int index)
        {

            var cardsTemp = await App.CardDB.GetCardsAsync();
            cards = new ObservableCollection<MTGCard>(cardsTemp);
            this.BindingContext = cards;
            //bug fix
            foreach(MTGCard card in cards)
            {
                if(ShownCard.imageURL == card.imageURL)
                {
                    ShownCard = card;
                }
            }

            //ShownCard = cards[index];
            viewCard.BindingContext = ShownCard;

        }

        async public void BackToMain(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }

        async public void RemoveCard(object sender, EventArgs e)
        {
            ShownCard = (MTGCard)this.BindingContext;
            await App.CardDB.DeleteCardAsync(ShownCard);
            await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }

        async public void AddCard(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddCard()));
        }

        async void OpenLib(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }


    }
}