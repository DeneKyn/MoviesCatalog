using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoviesCatalog.Views;
using MoviesCatalog.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MoviesCatalog
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //Resource.Culture = new System.Globalization.CultureInfo("AppSe");

            //AppSettings.Language = "en";
            //WorkWithFiles.WriteSettings("en");
            WorkWithFiles.ReadSettings();
            Resource.Culture = new System.Globalization.CultureInfo(AppSettings.Language);
            MainPage = new MainPage();
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
    }
}
