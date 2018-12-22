using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MoviesCatalog.Models;
using MoviesCatalog.ViewModels;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using static MoviesCatalog.Services.WorkWithFiles;


namespace MoviesCatalog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        //ObservableCollection<MovieCastMember> actors;
        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;            

            string str;
            
            using (StreamReader strr = new StreamReader(WebRequest.Create($"{AppSettings.ApiUrl}movie/{viewModel.Movie.Id}/credits?api_key={AppSettings.ApiKey}&language=ru").GetResponse().GetResponseStream()))
                str = strr.ReadToEnd();
            var info = JsonConvert.DeserializeObject<MovieCastMember>(str);

            foreach (var x in info.Casts)
            {
                x.ProfilePath = "https://image.tmdb.org/t/p/w200" + x.ProfilePath;
            }
                ActorsListView.ItemsSource = info.Casts;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var actor = args.SelectedItem as Cast;
            if (actor == null)
                return;

            await Navigation.PushAsync(new ActorDetailPage(new ActorDetailViewModel(actor)));

            // Manually deselect item.
            ActorsListView.SelectedItem = null;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var movie = new Movie
            {
                Name = "Item 1",                
            };

            viewModel = new ItemDetailViewModel(movie);
            BindingContext = viewModel;
        }

        public void AddBookmarks()
        {
            WriteId(viewModel.Movie.Id);
            string temp = "Матеша сосёт";
            DisplayAlert("Уведомление", temp, "Ok");
        }
    }
}