using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MTG_App
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<MTGCard> cards;
        bool showScreenRText = false;
        public MainPage()
        {
           

            InitializeComponent();


            try
            {
                GetDBCards();
            }
            catch (Exception e)
            {
                emptyLibrary.Text = "Click Add to Start Creating Your Library...";
            }

            

        }

        async public void GetDBCards()
        {

            var cardsTemp = await App.CardDB.GetCardsAsync();
            cards = new ObservableCollection<MTGCard>(cardsTemp);
            this.BindingContext = cards;
            if (cards == null)
            {
                emptyLibrary.Text = "Click Add to Start Creating Your Library...";
            }

            foreach(MTGCard c in cards)
            {
                if(!showScreenRText)
                {
                    c.name = "";
                }
            }

        }

        async void SetTappedCardAndReturnView(Object sender, ItemTappedEventArgs e)
        {
            var TempCard = (MTGCard) e.Item;
            for(int i= 0; i < cards.Count; ++i)
            {
                if(cards[i].name == TempCard.name)
                {
                   App.IndexClicked = i;
                }
            }

            var View = new CardView();
            View.BindingContext = TempCard;

            await Navigation.PushModalAsync(View);
        }


        async public void AddCard(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddCard()));
        }

        async void OpenLib(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }

        public void ToggleCardNames(object sender, EventArgs e)
        {
            if(showScreenRText == true)
            {
                showScreenRText = false;
            }
            else
            {
                showScreenRText = true;
            }

            try
            {
                GetDBCards();
            }
            catch (Exception e2)
            {
                emptyLibrary.Text = "Click Add to Start Creating Your Library...";
            }
        }
    }
}
