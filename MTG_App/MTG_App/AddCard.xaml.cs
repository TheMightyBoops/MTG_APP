using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MTG_App
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddCard : ContentPage
	{
        private string MTG_URL = "https://api.magicthegathering.io/v1/cards?name=";
        private HttpClient client = new HttpClient();
        public ObservableCollection<MTGCard> responseCards;
        public MTGCard SelectedObject;
       

        public AddCard ()
		{
            responseCards = new ObservableCollection<MTGCard>();
            InitializeComponent ();


            //MTGCard dummyCard = new MTGCard();
            //dummyCard.name = "dummy";
            //responseCards.Add(dummyCard);
            //searchResults.ItemsSource = responseCards;
            //BindingContext = responseCards;
            //searchResults.BindingContext = responseCards;
            this.BindingContext = responseCards;


        }

        public async void WriteToDB(Object sender, ItemTappedEventArgs e)
        {

            //searchResults.BindingContext = SelectedObject;
           
            var Card = (MTGCard) e.Item;
            await App.CardDB.SaveCardAsync(Card);
            var Text = App.CardDB.GetCardAsync(0).ToString();
            await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }

        public async void SearchForCards(Object sender, EventArgs e)
        {
            var searchingText = "searching...";
            responseCards.Clear();

            searching.Text = searchingText;

            string UserInput = searchField.Text;
            string ConcatURL = MTG_URL + UserInput;
            var url = new Uri(string.Format(ConcatURL, string.Empty));

            var response = await client.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                JObject joResponse = JObject.Parse(content);
                JArray array = (JArray)joResponse["cards"];
                var Cards = JsonConvert.DeserializeObject<List<Card>>(array.ToString());

                PutCardsInListView(Cards);
                

            }

            searching.Text = "";

        }

        public void PutCardsInListView(List<Card> jsonCards)
        {
            foreach(Card c in jsonCards)
            {
                MTGCard ModelCard = new MTGCard();
                ModelCard.name = c.name;
                ModelCard.imageURL = c.imageUrl;
                responseCards.Add(ModelCard);
            }
            
            //searchResults.ItemsSource = responseCards;
        }

        async public void AddACard(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddCard()));
        }

        async void OpenLib(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
    }
}