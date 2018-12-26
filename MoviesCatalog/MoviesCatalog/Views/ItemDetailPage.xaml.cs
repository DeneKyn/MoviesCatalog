using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MoviesCatalog.Models;
using MoviesCatalog.ViewModels;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using static MoviesCatalog.Services.WorkWithFiles;
using static MoviesCatalog.Models.DeteilFilms;
using System.Threading.Tasks;
using Plugin.Share;

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
            using (StreamReader strr = new StreamReader(WebRequest.Create($"{AppSettings.ApiUrl}movie/{viewModel.Movie.Id}/credits?api_key={AppSettings.ApiKey}&language={AppSettings.Language}").GetResponse().GetResponseStream()))
                str = strr.ReadToEnd();
            var info = JsonConvert.DeserializeObject<MovieCastMember>(str);

            foreach (var x in info.Casts)
            {
                x.ProfilePath = "https://image.tmdb.org/t/p/w200" + x.ProfilePath;                
                
            }

            ActorsListView.ItemsSource = info.Casts;
            ActorPoster.Opacity = 0;            
            ActorPoster.FadeTo(1, 2000);
            ActorPoster.RelScaleTo(1.3, 2000);            
        }

        public void ShareBlog()
        {

            string message;          
            message = $"{Resource.Share1} - {viewModel.DetailMovie.title} \n {Resource.Share2} {viewModel.DetailMovie.release_date} {Resource.Share3} - {viewModel.DetailMovie.vote_average} {Resource.Share4}\n {viewModel.DetailMovie.poster_path}";
            CrossShare.Current.Share(message);
               
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
            AnimationView.Play();
            WriteId(viewModel.Movie.Id);
            //DisplayAlert(Resource.Notification, Resource.FilmToBookmarks, "Ok");
        }

        private void PlayVideo(object sender, EventArgs e)
        {
            animationPlay.Play();
            string str;            
            using (StreamReader strr = new StreamReader(WebRequest.Create($"{AppSettings.ApiUrl}movie/{viewModel.Movie.Id}/videos?api_key={AppSettings.ApiKey}&language={AppSettings.Language}").GetResponse().GetResponseStream()))
                str = strr.ReadToEnd();
            var info = JsonConvert.DeserializeObject<Video>(str);

            if (info.results[0].key != null)
            {
                Device.OpenUri(new Uri("https://www.youtube.com/watch?v=" + info.results[0].key));
            }
            else
            {
                DisplayAlert("Warning", "Трейлера нет на YouTube!", "Ok");
            }
        }
    }
}