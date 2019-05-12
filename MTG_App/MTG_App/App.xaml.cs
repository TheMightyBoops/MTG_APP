
using System;
using System.IO;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;




[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MTG_App
{
    public partial class App : Application
    {
        static CardDB cardDB;

        public static CardDB CardDB
        {
            get
            {
                if (cardDB == null)
                {
                    cardDB = new CardDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Cards.db3"));
                }
                return cardDB;
            }
        }

        public static int IndexClicked { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
           
        }

        public static Page GetPage()
        {
            return new NavigationPage(new AddCard());
        }
    }
}
